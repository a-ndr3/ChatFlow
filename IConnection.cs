using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow
{
    public interface IConnection
    {
        Task<string> GetAsync(Uri uri);
        Task<string> PostAsync(Uri uri, string data, string contentType);
    }
}
