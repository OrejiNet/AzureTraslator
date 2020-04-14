using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AzureTranslator
{
    public class AzureTranslatorServices : IAzureTranslatorBody
    {

        static string key = "28519d16c554449dadce0c5a25578c46";
        static string EndPoint = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0";
        static string ConvertTo = "&to=en";
    
    
        public async Task<List<AzureTranslatorModel>> Excecute(List<AzureRequestBody> requestBodies)
        {
            try
            {
                var body = requestBodies;
                var requestBodyOject = JsonConvert.SerializeObject(requestBodies);

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Post;
                    request.RequestUri = new Uri($"{EndPoint}{ConvertTo}");
                    request.Content = new StringContent(requestBodyOject, Encoding.UTF8, "application/json");
                    request.Headers.Add("Ocp-Apim-Subscription-Key", key);


                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();

                        var model = JsonConvert.DeserializeObject<List<AzureTranslatorModel>>(responseBody);
                        return model;
                    }

                    return new List<AzureTranslatorModel>();
                }
            }
            catch (Exception )
            {

                return new List<AzureTranslatorModel>();
            }

        }
    
    
    }





    
}
