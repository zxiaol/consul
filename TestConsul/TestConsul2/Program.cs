using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Consul;

namespace TestConsul2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetConfigsAsync().Wait();
        }

        private static async Task<String[]> GetConfigsAsync()
        {
            var client = new ConsulClient((clientConfig) =>
            {
                clientConfig.Datacenter = "dc1";
                clientConfig.Address = new Uri("http://163.184.133.139:8500");

            });

            var kv = client.KV;

            var keys = await kv.Keys("/Config");

            foreach (var key in keys.Response)
            {
                var getRequest = await kv.Get(key);
                if (getRequest.StatusCode != System.Net.HttpStatusCode.NotFound 
                    && getRequest.Response.Value != null)
                {

                    var a = getRequest.Response.Key;
                    var b = System.Text.Encoding.UTF8.GetString(getRequest.Response.Value);
                    Console.WriteLine("{0}:{1}",a,b); 
                }
            }

            var results = keys.Response;

            return results;

        }
    }
}
