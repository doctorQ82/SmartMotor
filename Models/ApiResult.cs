using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Models
{
    public class ApiResult
    {
        [JsonProperty("status")]
        public bool status { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }

    public class ApiToken
    {
        [JsonProperty("isError")]
        public bool isError { get; set; }

        [JsonProperty("authCodeForApiOwner")]
        public string authCodeForApiOwner { get; set; }

        [JsonProperty("token")]
        public string token { get; set; }

        [JsonProperty("statusCode")]
        public string statusCode { get; set; }

        [JsonProperty("errorMessage")]
        public string errorMessage { get; set; }
    }


    public class ResultInfo
    {
        [JsonProperty("status")]
        public bool status { get; set; }

        [JsonProperty("userLDAP")]
        public string userLDAP { get; set; }

        [JsonProperty("before")]
        public string before { get; set; }

        [JsonProperty("after")]
        public string after { get; set; }

        [JsonProperty("messagetype")]
        public int messagetype { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }

    public class GeneralInfo
    {
        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("displayName")]
        public string displayName { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("office")]
        public string office { get; set; }

        [JsonProperty("telephoneNumber")]
        public string telephoneNumber { get; set; }

        [JsonProperty("mobileNumber")]
        public string mobileNumber { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("memberOfGlobalSecurityGroup")]
        public string memberOfGlobalSecurityGroup { get; set; }

        [JsonProperty("groupAgent")]
        public string groupAgent { get; set; }

        [JsonProperty("homephone")]
        public string homephone { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("zipcode")]
        public string zipcode { get; set; }

        [JsonProperty("fax")]
        public string fax { get; set; }
    }

    public class AccountInfo
    {
        [JsonProperty("logonName")]
        public string logonName { get; set; }

        [JsonProperty("expireDate")]
        public string expireDate { get; set; }
    }

    public class OrganizationInfo
    {
        [JsonProperty("position")]
        public string position { get; set; }

        [JsonProperty("department")]
        public string department { get; set; }

        [JsonProperty("company")]
        public string company { get; set; }
    }

    public class ApiSyncUser
    {
        [JsonProperty("resultInfo")]
        public ResultInfo resultInfo { get; set; }

        [JsonProperty("generalInfo")]
        public GeneralInfo generalInfo { get; set; }

        [JsonProperty("accountInfo")]
        public AccountInfo accountInfo { get; set; }

        [JsonProperty("organizationInfo")]
        public OrganizationInfo organizationInfo { get; set; }
    }


}
