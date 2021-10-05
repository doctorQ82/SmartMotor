using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Models
{
    public class WSResult
    {
        [JsonProperty(Order = 1)]
        public bool IsError { get; set; }

        [JsonProperty(Order = 2)]
        public string Key { get; set; }

        [JsonProperty(Order = 3)]
        public string Token { get; set; }

        [JsonProperty(Order = 4)]
        public string StatusCode { get; set; }

        [JsonProperty(Order = 5)]
        public string ErrorMessage { get; set; }
    }

    public class Logon
    {
        [JsonProperty(Order = 1)]
        public string Username { get; set; }

        [JsonProperty(Order = 2)]
        public string Password { get; set; }
    }

    public class DelQP
    {
        [JsonProperty(Order = 1)]
        public string qpID { get; set; }
    }

    public class QuickPayParam
    {
        [JsonProperty(Order = 1)]
        public string orderIdPrefix { get; set; }

        [JsonProperty(Order = 2)]
        public string description { get; set; }

        [JsonProperty(Order = 3)]
        public double amount { get; set; }

        [JsonProperty(Order = 4)]
        public double AddDay { get; set; }

        [JsonProperty(Order = 5)]
        public string enableStoreCard { get; set; }

        [JsonProperty(Order = 6)]
        public string recurring { get; set; }

        [JsonProperty(Order = 7)]
        public string Key { get; set; }
    }

    public class QuickPayRes
    {
        [JsonProperty("GenerateQPRes")]
        public GenerateQPRes GenerateQPRes { get; set; }
    }

    public class GenerateQPRes
    {
        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("timeStamp")]
        public string timeStamp { get; set; }

        [JsonProperty("qpID")]
        public string qpID { get; set; }

        [JsonProperty("orderIdPrefix")]
        public string orderIdPrefix { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }

        [JsonProperty("amount")]
        public string amount { get; set; }

        [JsonProperty("expiry")]
        public string expiry { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("resCode")]
        public string resCode { get; set; }

        [JsonProperty("resDesc")]
        public string resDesc { get; set; }

        [JsonProperty("hashValue")]
        public string hashValue { get; set; }
    }


}
