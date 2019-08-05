using CosmosWithOData.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CosmosWithOData.UI.Brokers
{
    public class StudentsApiBroker
    {
        public async Task<StudentApiResponse> GetStudentsAsync(string nextLink = null)
        {
            string url = nextLink ?? "http://localhost:33488/api/students";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<StudentApiResponse>(jsonString);
                }

                return new StudentApiResponse();
            }
        }
    }
}
