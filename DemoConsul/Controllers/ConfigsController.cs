using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DemoConsul.Service;

namespace DemoConsul.Controllers
{
    public class ConfigsController : ApiController
    {
        private static ConfigService configService = new ConfigService();
        public async Task<IHttpActionResult> GetConfigs()
        {
            return Ok(await configService.GetConfigsAsync());
        }

    }
}
