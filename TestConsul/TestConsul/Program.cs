using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestConsul
{
    class Program
    {
        static void Main(string[] args)
        {

            GetConfigsAsync().Wait();
        }

        private static async Task<String> GetConfigsAsync()
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(15);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Keep-Alive", "true");
            client.BaseAddress = new Uri("http://163.184.133.139:8500");
            var response = await client.GetAsync("/v1/kv/qqq").ConfigureAwait(false);

            var responseStream = response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var result = responseStream.GetAwaiter().GetResult();

            return result;
        }
    }
}
