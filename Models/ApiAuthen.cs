using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using SmartMotor.Data;


namespace SmartMotor.Models
{
    public class ApiAuthen
    {
        #region "Declare variable"
        private IConfiguration config { get; set; }
        private string token { get; set; }
        private string UserIsExists { get; set; }

        private string SyncUserUrl { get; set; }
        private string ApiUser { get; set; }
        private string ApiPassword { get; set; }
        #endregion



        public ApiAuthen(IConfiguration _config)
        {
            var section = _config.GetSection("settings").Get<ClsSetting>();

            this.token = section.token.ToString();
            this.UserIsExists = section.UserIsExists.ToString();
            this.SyncUserUrl = section.SyncUser.ToString();

            string _api = EncodingForBase64.Base64Decode(section.LDAPUser.ToString());
            string[] slapi = _api.Split(":");

            this.ApiUser = slapi[0].ToString();
            this.ApiPassword = slapi[1].ToString();

        }

        public bool CheckApiAuthen(string username, string password)
        {
            bool bResult = false;

            ApiToken token = GetToken(this.ApiUser.ToString(), this.ApiPassword.ToString());

            if (token.statusCode == "200")
            {
                ApiResult apiresult = CheckUserIsExists(username, password, token.authCodeForApiOwner, token.token);

                bResult = apiresult.status;
            }

            return bResult;

        }

        private ApiToken GetToken(string username, string password)
        {
            ApiToken result = new ApiToken();
            string _token = string.Empty;

            string url = this.token + String.Format("?Username={0}&Password={1}", username.ToString(), password.ToString());

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<ApiToken>(response.Content.ToString());

            }

            return result;
        }

        private ApiResult CheckUserIsExists(string username, string password,
            string authCodeForApiOwner, string Authorization)
        {
            ApiResult result = new ApiResult();
            string _token = string.Empty;

            string url = this.UserIsExists.ToString() + String.Format("?Username={0}&Password={1}", username.ToString(), password.ToString());

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("authCodeForApiOwner", authCodeForApiOwner.ToString());
            request.AddHeader("Authorization", String.Format("Bearer {0}", Authorization));
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<ApiResult>(response.Content.ToString());

            }

            return result;
        }

        public bool SyncUser(string username, string login, ref string Message)
        {
            bool bResult = false;
            ApiSyncUser sync = new ApiSyncUser();

            ApiToken token = GetToken(this.ApiUser.ToString(), this.ApiPassword.ToString());

            string url = this.SyncUserUrl.ToString() + String.Format("?Username={0}", username.ToString());

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("authCodeForApiOwner", token.authCodeForApiOwner);
            request.AddHeader("Authorization", String.Format("Bearer {0}", token.token));
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                sync = JsonConvert.DeserializeObject<ApiSyncUser>(response.Content.ToString());

                string _logonName = sync.accountInfo.logonName.ToString();
                string _displayName = sync.generalInfo.displayName.ToString();
                string _Position = sync.generalInfo.description.ToString();
                string _email = sync.generalInfo.email.ToString();
                string _groupAgent = sync.generalInfo.groupAgent;

                if (!String.IsNullOrEmpty(_logonName))
                {
                    using (var context = new ApplicationDbContext())
                    {
                        var user = context.Users.SingleOrDefault(x => x.LogonName == _logonName);

                        if (user == null)
                        {
                            try
                            {
                                var _user = new User
                                {
                                    LogonName = _logonName.ToString(),
                                    DisplayName = _displayName.ToString(),
                                    Position = _Position.ToString(),
                                    Email = _email.ToString(),
                                    GroupAgent = _groupAgent.ToString(),
                                    Created = DateTime.UtcNow,
                                    CreatedBy = login
                                };
                                context.Add(_user);
                                context.SaveChanges();

                                Message = "เพิ่มบัญชีผู้ใช้งานในระบบ";
                                bResult = false;
                            }
                            catch (Exception err)
                            {

                            }
                        }
                        else
                        {
                            Message = "มีการเพิ่มบัญชีผู้ใช้งานในระบบ";
                            bResult = false;
                        }

                    }
                }
                else
                {
                    Message = "ไม่พบบัญชีผู้ใช้งานในระบบ";
                    bResult = false;
                }
            }

            return bResult;
        }
    }
}
