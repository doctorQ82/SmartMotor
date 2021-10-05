using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using SmartMotor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SmartMotor.Services
{
    public class ChangePaymentService : BaseService, IChangePayment
    {
        private ISession _session;
        public ISession Session { get { return _session; } }


        #region ""
        public string UrlSecurePay { get; set; }
        public string UrlSingle { get; set; }
        public string authCodeForApiOwner { get; set; }
        public string ApiUser { get; set; }

        public string ApiPassword { get; set; }

        public string tokenPayment { get; set; }

        public string DirectPay { get; set; }

        public string QPDelete { get; set; }

        #endregion

        public ChangePaymentService(IConfiguration _config, IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;

            var config = _config.GetSection("settings").Get<ClsSetting>();
            this.UrlSecurePay = config.SecurePay;
            this.UrlSingle = config.Single;
            this.authCodeForApiOwner = config.authCodeForApiOwner;
            this.ApiUser = config.ApiUser;
            this.ApiPassword = config.ApiPassword;
            this.tokenPayment = config.tokenPayment;
            this.DirectPay = config.DirectPay;
            this.QPDelete = config.QPDelete;
        }

        public IEnumerable<ChangePaymentUnPaid> UnPaidRead()
        {

            List<ChangePaymentUnPaid> unpaid = new List<ChangePaymentUnPaid>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetPaymentSummaryInvoice";
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            var entities = new List<PaymentSummary>();
                            while (reader.Read())
                            {
                                ChangePaymentUnPaid item = new ChangePaymentUnPaid();
                                item.pid = Convert.ToInt64(reader["pid"].ToString());
                                item.Policy_no = reader["policy_no"].ToString();
                                item.start_bill_date = reader["start_bill_date"].ToString();
                                item.end_bill_date = reader["end_bill_date"].ToString();

                                item.total_distance = decimal.Parse(reader["total_distance"].ToString());
                                item.total_amount = decimal.Parse(reader["total_amount_insurer"].ToString());

                                item.payment_due_date = reader["payment_due_date"].ToString();
                                item.invoice_no = reader["invoice_no"].ToString();
                                item.payment_url = reader["payment_url"].ToString();
                                item.payment_type = reader["payment_type"].ToString();

                                item.assuredName = reader["assuredName"].ToString();
                                item.carRegistrationNo = reader["carRegistrationNo"].ToString();
                                item.qpID = reader["qpID"].ToString();
                                item.SecurePay = reader["SecurePay"].ToString();
                                item.ConcatData = reader["ConcatData"].ToString();
                                item.PayMode = reader["PayMode"].ToString();

                                item.Mobile_No = reader["Mobile_No"].ToString();
                                item.payment_status = reader["payment_status"].ToString();

                                bool IsChange = Convert.ToBoolean(reader["IsChange"].ToString());
                                bool IsQP = Convert.ToBoolean(reader["IsQP"].ToString());

                                item.IsChange = IsChange;
                                item.IsQP = IsQP;

                                item.userIdentity = reader["userIdentity"].ToString();
                                unpaid.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }


            }

            return unpaid;
        }

        public void UpdatePaymentType(long pid, string paymentUrl, string PaymentType)
        {
            using (var db = GetContext())
            {
                try
                {
                    var _payment = db.TPaymentSummaries.First(a => a.Pid == pid);
                    _payment.PaymentUrl = paymentUrl.ToString();
                    _payment.PaymentType = PaymentType.ToString();
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    db.Database.CloseConnection();
                }
            }
        }

        public void SendSMSChangePayment(long pid)
        {

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetPaymentDataSendSMS";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@pid", pid));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SendSMSSecurePay pay = new SendSMSSecurePay();
                                pay._pid = Convert.ToInt64(reader["pid"].ToString());
                                pay._invoiceno = reader["invoice_no"].ToString();
                                pay._policyNo = reader["policy_no"].ToString();
                                pay._userIdentity = reader["userIdentity"].ToString();
                                pay._total_distance = reader["total_distance"].ToString();
                                pay._total_amount = reader["total_amount"].ToString();
                                pay._payment_url = reader["payment_url"].ToString();
                                pay._DueDate = reader["DueDate"].ToString();
                                pay._Message_Type = reader["Message_Type"].ToString();
                                pay._Payment_Type = reader["Payment_Type"].ToString();
                                pay._SecurePay = reader["SecurePay"].ToString();
                                pay._SMS_Message = reader["SMS_Message"].ToString();
                                pay._Mobile_No = reader["Mobile_No"].ToString();

                                SendSMS(pay);

                                InsPaymentSummaryLog(pid, pay._invoiceno,"", "Change Payment QuickPay to SecurePay");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }


            }
        }

        private void SendSMS(SendSMSSecurePay pay)
        {
           Int64 LogID= InsertSMSLogAlert(pay);

            string Mobile_No = pay._Mobile_No.ToString();
            string SMS_Message = pay._SMS_Message.ToString();

            string P1 = pay._DueDate;
            string P2 = string.Empty;

            if (pay._Payment_Type == "1")
            {
                P2= this.UrlSecurePay + pay._SecurePay;
            }
            else if (pay._Payment_Type == "2")
            {
                P2 = pay._payment_url;
            }
            

            SMS_Message = SMS_Message.ToString().Replace("{P1}", P1.ToString());
            SMS_Message = SMS_Message.ToString().Replace("{P2}", P2.ToString());

            Message msg = new Message();
            msg.mobileNo = Mobile_No.ToString();
            msg.smsText = SMS_Message.ToString();

            string postText = JsonConvert.SerializeObject(msg);

            var client = new RestClient(this.UrlSingle);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("authCodeForApiOwner", this.authCodeForApiOwner.ToString());
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", postText, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                SMSResponse resp = JsonConvert.DeserializeObject<SMSResponse>(response.Content);
                string jsonText = JsonConvert.SerializeObject(resp);

                string sql = String.Format("update  T_SMartMotor_SMSAlert set FlagSMS = 1 , SMSDate=getdate(), JsonText = '{0}', MessageText = '{1}' WHERE LogID = '{2}'", jsonText.ToString(), SMS_Message.ToString(), LogID);
                Commit(sql);

                InsertSMSResponseLogs(resp, LogID, "Notification");
            }
        }

        public bool Commit(string sql)
        {
            bool bResult = false;

            using (var context = GetContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                bool wasOpen = command.Connection.State == ConnectionState.Open;
                if (!wasOpen) command.Connection.Open();
                try
                {
                    command.CommandText = sql.ToString();
                    command.CommandType = CommandType.Text;
                    int row = command.ExecuteNonQuery();

                    if (row > 0)
                    {
                        bResult = true;
                    }
                }
                catch (Exception ex)
                {
                    bResult = false;
                }
                finally
                {
                    if (!wasOpen) command.Connection.Close();
                }

            }

            return bResult;
        }

        public string DoFormat(double myNumber)
        {
            return string.Format("{0:n2}", myNumber).Replace(".00", "");
        }

        private void InsertSMSResponseLogs(SMSResponse resp, Int64 LogID, string MessType)
        {
            DataTable tbResponse = new DataTable();
            tbResponse.Columns.Add(new DataColumn("LogID", typeof(Int64)));
            tbResponse.Columns.Add(new DataColumn("ErrorCode", typeof(string)));
            tbResponse.Columns.Add(new DataColumn("ErrorMessage", typeof(string)));
            tbResponse.Columns.Add(new DataColumn("JobId", typeof(string)));
            tbResponse.Columns.Add(new DataColumn("MobileNumber", typeof(string)));
            tbResponse.Columns.Add(new DataColumn("MessageId", typeof(string)));
            tbResponse.Columns.Add(new DataColumn("MessagePartId", typeof(Int32)));
            tbResponse.Columns.Add(new DataColumn("MessageText", typeof(string)));
            tbResponse.Columns.Add(new DataColumn("Message_Type", typeof(string)));

            DataRow dr;

            string _ErrorCode = resp.ErrorCode.ToString();
            string _ErrorMessage = resp.ErrorMessage.ToString();
            string _JobId = resp.JobId.ToString();

            List<MsgData> MessageData = resp.MessageData;

            foreach (var data in MessageData)
            {
                string _MobileNumber = data.Number.ToString();
                List<MessagePart> MessagePart = data.MessageParts;

                foreach (var part in MessagePart)
                {
                    string _MessageId = part.MsgId.ToString();
                    int _MessagePartId = Convert.ToInt32(part.PartId.ToString());
                    string _MessageText = part.Text.ToString();

                    dr = tbResponse.NewRow();
                    dr["LogID"] = LogID;
                    dr["ErrorCode"] = _ErrorCode.ToString();
                    dr["ErrorMessage"] = _ErrorMessage.ToString();
                    dr["JobId"] = _JobId.ToString();
                    dr["MobileNumber"] = _MobileNumber.ToString();
                    dr["MessageId"] = _MessageId.ToString();
                    dr["MessagePartId"] = _MessagePartId;
                    dr["MessageText"] = _MessageText.ToString();
                    dr["Message_Type"] = MessType.ToString();

                    tbResponse.Rows.Add(dr);
                }
            }

            if (tbResponse.Rows.Count > 0)
            {

                using (var context = GetContext())
                {
                    context.Database.OpenConnection();

                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        bool wasOpen = command.Connection.State == ConnectionState.Open;
                        if (!wasOpen) command.Connection.Open();
                        try
                        {
                            command.CommandText = "sp_InsResultSMSDetail";

                            SqlParameter Parameter = new SqlParameter();
                            Parameter.ParameterName = "@tblData";
                            Parameter.SqlDbType = SqlDbType.Structured;
                            Parameter.Value = tbResponse;

                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add(Parameter);

                            int irow = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {
                            if (!wasOpen) command.Connection.Close();
                        }

                    }
                }

            }
        }

        public long InsertSMSLogAlert(SendSMSSecurePay pay)
        {
            Int64 LogID = 0;

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.InsertSMSLogAlert";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@invoice_no", pay._invoiceno));
                        command.Parameters.Add(new SqlParameter("@policy_no", pay._policyNo));
                        command.Parameters.Add(new SqlParameter("@userIdentity", pay._userIdentity));
                        command.Parameters.Add(new SqlParameter("@total_distance", pay._total_distance));
                        command.Parameters.Add(new SqlParameter("@total_amount", pay._total_amount));
                        command.Parameters.Add(new SqlParameter("@due_date", pay._DueDate));
                        command.Parameters.Add(new SqlParameter("@payment_url", pay._payment_url));
                        command.Parameters.Add(new SqlParameter("@Message_Type", pay._Message_Type));
                        command.Parameters.Add(new SqlParameter("@Payment_Type", pay._Payment_Type));
                        command.Parameters.Add(new SqlParameter("@Period", "2"));
                        command.Parameters.Add(new SqlParameter("@SMS_Message", pay._SMS_Message));

                        SqlParameter output = new SqlParameter("@LogID", SqlDbType.BigInt)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(output);

                        command.ExecuteNonQuery();
                        string id = command.Parameters["@LogID"].Value.ToString();
                        LogID = Convert.ToInt64(id);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return LogID;
        }

        public void DeleteQPLink(string qpid)
        {
            WSResult result = GetPaymentToken();

            DelQP qp = new DelQP();
            qp.qpID = qpid.ToString();
            string postText = JsonConvert.SerializeObject(qp);

            var client = new RestClient(this.QPDelete);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            string _Authorization = String.Format("Bearer {0}", result.Token);
            request.AddHeader("Authorization", _Authorization);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", postText, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
            }

         }

        private WSResult GetPaymentToken()
        {
            WSResult result = new WSResult();
            string _token = string.Empty;

            var client = new RestClient(this.tokenPayment);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            Logon log = new Logon();
            log.Username = this.ApiUser.ToString();
            log.Password = this.ApiPassword.ToString();

            string postText = JsonConvert.SerializeObject(log);
            request.AddParameter("text/json", postText.ToString(), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = JsonConvert.DeserializeObject<WSResult>(response.Content.ToString());

            }

            return result;
        }

        public IEnumerable<string> GetPaymentType()
        {
            List<string> result = new List<string>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetPaymentType";
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            var entities = new List<PaymentSummary>();
                            while (reader.Read())
                            {
                                string PaymentType  = reader["PaymentType"].ToString();
                                result.Add(PaymentType);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }


            }

            return result;
        }

        public IEnumerable<string> GetStatusPayment()
        {
            List<string> result = new List<string>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetStatusPayment";
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            var entities = new List<PaymentSummary>();
                            while (reader.Read())
                            {
                                string PaymentType = reader["PaymentType"].ToString();
                                result.Add(PaymentType);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }


            }

            return result;
        }

        public void UpdateMobile(ChangePaymentUnPaid data)
        {
            string _username = _session.GetString("_username").ToString();

            using (var context = GetContext())
            {     context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.UpdateMobileNo";
                        command.Parameters.Add(new SqlParameter("@MobileNo", data.Mobile_No));
                        command.Parameters.Add(new SqlParameter("@policyno", data.Policy_no));
                        command.Parameters.Add(new SqlParameter("@userIdentity", data.userIdentity));
                        command.Parameters.Add(new SqlParameter("@UpdatedBy", _username.ToString()));

                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteReader();
                    }
                }
                catch (Exception ex)
                {

                }
            }

        }

        public void GenQuickPay(long pid)
        {
            WSResult result = GetPaymentToken();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetPolicyCallQuickPayByPID";
                        command.Parameters.Add(new SqlParameter("@PID", pid));
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double total_amount = double.Parse(reader["total_amount"].ToString());
                                Int32 AddDay = Int32.Parse(reader["AddDay"].ToString());
                                string invoice_no = reader["invoice_no"].ToString();

                                QuickPayParam QP = new QuickPayParam();
                                QP.orderIdPrefix = invoice_no.ToString();
                                QP.description = "Premium Of Order No: " + reader["invoice_no"].ToString();
                                QP.amount = total_amount;
                                QP.AddDay = AddDay;
                                QP.enableStoreCard = "N";
                                QP.recurring = "N";
                                QP.Key = result.Key;

                                string postText = JsonConvert.SerializeObject(QP);

                                var client = new RestClient(this.DirectPay);
                                client.Timeout = -1;
                                var request = new RestRequest(Method.POST);

                                string _Authorization = String.Format("Bearer {0}", result.Token);
                                request.AddHeader("Authorization", _Authorization);
                                request.AddHeader("Content-Type", "application/json");
                                request.AddParameter("application/json", postText, ParameterType.RequestBody);
                                IRestResponse response = client.Execute(request);

                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    QuickPayRes QPRes = JsonConvert.DeserializeObject<QuickPayRes>(response.Content.ToString());

                                    UpdateQuickPayLink(pid, invoice_no, QPRes);

                                    InsPaymentSummaryLog(pid, invoice_no, QPRes.GenerateQPRes.qpID,
                                    "Change Payment SecurePay to QuickPay");
                                }

                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void UpdateQuickPayLink(long pid,string invoice_no, QuickPayRes QPRes)
        {
            DateTime dExpiry;
            DateTime.TryParseExact(QPRes.GenerateQPRes.expiry, "ddMMyyyy", new System.Globalization.CultureInfo("en-US"), DateTimeStyles.None, out dExpiry);


            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var cmd = context.Database.GetDbConnection().CreateCommand())
                    {
                        bool wasOpen = cmd.Connection.State == ConnectionState.Open;
                        if (!wasOpen) cmd.Connection.Open();
                        try
                        {
                            cmd.CommandText = "dbo.UpdatePaymentSum";
                            cmd.Parameters.Add(new SqlParameter("@invoice_no", invoice_no));
                            cmd.Parameters.Add(new SqlParameter("@payment_url", QPRes.GenerateQPRes.url));
                            cmd.Parameters.Add(new SqlParameter("@payment_type", "2"));
                            cmd.Parameters.Add(new SqlParameter("@payment_due_date", dExpiry.ToString("yyyy-MM-dd")));
                            cmd.Parameters.Add(new SqlParameter("@status", "I"));
                            cmd.Parameters.Add(new SqlParameter("@pid", pid));
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {
                            if (!wasOpen) cmd.Connection.Close();
                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void InsPaymentSummaryLog(long PID, string invoiceNo, string qpid, string LogType)
        {
            string _username = _session.GetString("_username").ToString();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var cmd = context.Database.GetDbConnection().CreateCommand())
                    {
                        bool wasOpen = cmd.Connection.State == ConnectionState.Open;
                        if (!wasOpen) cmd.Connection.Open();
                        try
                        {
                            cmd.CommandText = "dbo.InsPaymentSummaryLog";
                            cmd.Parameters.Add(new SqlParameter("@pid", PID));
                            cmd.Parameters.Add(new SqlParameter("@invoice_no", invoiceNo));
                            cmd.Parameters.Add(new SqlParameter("@qpid", qpid));
                            cmd.Parameters.Add(new SqlParameter("@LogType", LogType));
                            cmd.Parameters.Add(new SqlParameter("@UpdatedBy", _username.ToString()));
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        { 

                        }
                        finally
                        {
                            if (!wasOpen) cmd.Connection.Close();
                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
