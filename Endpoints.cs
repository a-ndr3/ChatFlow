using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatFlow
{
    public static class Endpoints
    {
       public static readonly string GPT3 = "https://api.openai.com/v1/engines/davinci/completions";
       public static readonly string History = "https://api.openai.com/v1/engines/davinci/search";     
    }
}
