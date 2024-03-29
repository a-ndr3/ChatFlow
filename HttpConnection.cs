﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow
{
    public class HttpConnection : IConnection
    {
        [Obsolete]
        public async Task<string> GetAsync(Uri uri)
        {
            var request = WebRequest.Create(uri) as HttpWebRequest;
            using var response = await request.GetResponseAsync();
            using var stream = response.GetResponseStream();
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
        public async Task<string> GetAsyncNew(Uri uri)
        {
            var client = new HttpClient();
            var req = await client.GetAsync(uri);
            var resp = await req.Content.ReadAsStreamAsync();
            using var read = new StreamReader(resp);
            return await read.ReadToEndAsync();
        }
        public async Task<string> PostAsync(Uri uri, string data, string contentType)
        {
            var request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = contentType;
            using var requestStream = await request.GetRequestStreamAsync();
            using var writer = new StreamWriter(requestStream);
            await writer.WriteAsync(data);
            using var response = await request.GetResponseAsync();
            using var stream = response.GetResponseStream();
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
    }

}
