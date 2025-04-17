using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Newtonsoft.Json;

namespace Corretor.ApiCalls
{
    public class OpenAi
    {
        private readonly string _apiKey = DotNetEnv.Env.GetString("OPENAI_API_KEY");
        private readonly string _apiUrl = "https://api.openai.com/v1/chat/completions";
        public OpenAi() { }

        public async Task<string> ObtemRespostasCorretas(string questoes)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new{ role = "system", content = "Você é um corretor de atividades. Responda apenas as alternativas corretas. Exemplo: 1A, 2B"},
                        new{ role = "user", content = questoes }
                    },
                    temperature = 0.5,
                    max_tokens = 2000
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);

                    string resposta = jsonResponse.choices[0].message.content.ToString();

                    return resposta;
                }
                else
                {
                    return $"Erro na requisição: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"Erro ao chamar a API: {ex.Message}";
            }
        }


    }
}
