using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TabularApiClient.Models;

namespace TabularApiClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dynamic()
        {
            var model = new DynamicApiList()
            {
                ApiUrl = "http://localhost/test",
                Exchange = "1"
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Dynamic(DynamicApiList model)
        {
            var client = new WebClient();
            client.Headers.Add("X-Exchange-ID", model.Exchange);

            var jsonString = client.DownloadString(model.ApiUrl);
            var result = JsonConvert.DeserializeObject(jsonString);
            model.ApiList = result as JArray;

            if (model.ApiList == null)
            {
               model.ApiObject = result as JObject;
            }

            return View(model);
        }

    }
}
