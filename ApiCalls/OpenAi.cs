using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;

namespace Corretor.ApiCalls
{
    public class OpenAi
    {
        private readonly string _apiKey = DotNetEnv.Env.GetString("API_KEY");
        private readonly string _apiUrl = "https://api.openai.com/v1/chat/completions";
        public OpenAi() { }




    }
}
