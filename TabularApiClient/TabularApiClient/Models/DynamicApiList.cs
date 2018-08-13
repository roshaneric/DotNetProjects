using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace TabularApiClient.Models
{
    public class DynamicApiList
    {
        public string ApiUrl { get; set; }
        public string Message { get; set; }
        public string Exchange { get; set; }
        public JArray ApiList { get; set; }
        public JObject ApiObject { get; set; }
    }
}