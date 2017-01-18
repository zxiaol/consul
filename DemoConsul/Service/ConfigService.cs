using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DemoConsul.Models;
using Consul;

namespace DemoConsul.Service
{
    public class ConfigService
    {
        public async Task<List<ConfigModel>> GetConfigsAsync()
        {
            var client = new ConsulClient((clientConfig) =>
            {
                clientConfig.Datacenter = "dc1";
                clientConfig.Address = new Uri("http://163.184.133.139:8500");

            });

            var kv = client.KV;

            var models = new List<ConfigModel>();

            var prefix = "/Config";

            var keys = await kv.Keys(prefix);

            foreach (var key in keys.Response)
            {
                var getRequest = await kv.Get(key);
                if (getRequest.StatusCode != System.Net.HttpStatusCode.NotFound
                    && getRequest.Response.Value != null)
                {
                    var model = new ConfigModel()
                    {
                        key = getRequest.Response.Key.TrimStart(prefix.ToCharArray()),
                        value = Encoding.UTF8.GetString(getRequest.Response.Value)
                    };

                    models.Add(model);
                }
            }

            return models;

        }

        public async Task<List<ConfigModel>> GetFeaturesAsync()
        {
            var client = new ConsulClient((clientConfig) =>
            {
                clientConfig.Datacenter = "dc1";
                clientConfig.Address = new Uri("http://163.184.133.139:8500");

            });

            var kv = client.KV;

            var models = new List<ConfigModel>();

            var prefix = "/FeatureToggle";

            var keys = await kv.Keys(prefix);

            foreach (var key in keys.Response)
            {
                var getRequest = await kv.Get(key);
                if (getRequest.StatusCode != System.Net.HttpStatusCode.NotFound
                    && getRequest.Response.Value != null)
                {
                    var model = new ConfigModel();

                    var fullKey = getRequest.Response.Key;

                    var shortKey = fullKey.Substring(fullKey.LastIndexOf("/")+1);

                    model.key = shortKey;
                    model.value = Encoding.UTF8.GetString(getRequest.Response.Value);

                    models.Add(model);
                }
            }

            return models;

        }

    }
}