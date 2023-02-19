using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow
{
    public interface IChatGPT
    {
        Task<string> GetResponseAsync(string input, string model, double temperature);
    }

}
