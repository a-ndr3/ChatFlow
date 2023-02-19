using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChatFlow
{
    public class ChatGPT3 : IChatGPT
    {
        private readonly HttpClient httpClient;
        private readonly string apiKey;
        private readonly string endpoint;

        public ChatGPT3(HttpClient httpClient, string apiKey, string endpoint)
        {
            this.httpClient = httpClient;
            this.apiKey = apiKey;
            this.endpoint = endpoint;
        }

        public async Task<string> GetResponseAsync(string input, string model = "GPT3", double temperature = 1.0)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            request.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                context = "",
                model = model,
                prompt = input,
                length = input.Length,
                temperature = temperature
            }), Encoding.UTF8, "application/json");

            using var response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get response from ChatGPT API: {response.StatusCode}, {content}");
            }

            return JObject.Parse(content)["response"].ToString();
        }
        public async Task<string[]> GetChatHistoryAsync(string sessionId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{endpoint}/conversations/{sessionId}/messages");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            using var response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get chat history from ChatGPT API: {response.StatusCode}, {content}");
            }

            return JArray.Parse(content).Select(x => x["message"].ToString()).ToArray();
        }
        public async Task<Dictionary<string, string[]>> GetAllChatsFromHistoryAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{endpoint}/conversations");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            using var response = await httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get chat history from ChatGPT API: {response.StatusCode}, {content}");
            }

            var sessions = JArray.Parse(content).Select(x => x["id"].ToString()).ToArray();

            var chatHistoryTasks = sessions.Select(sessionId => GetChatHistoryAsync(sessionId));

            var chatHistoryArray = await Task.WhenAll(chatHistoryTasks);

            var chatHistoryDict = new Dictionary<string, string[]>();

            for (int i = 0; i < sessions.Length; i++)
            {
                chatHistoryDict.Add(sessions[i], chatHistoryArray[i]);
            }

            return chatHistoryDict;
        }
    }
}
