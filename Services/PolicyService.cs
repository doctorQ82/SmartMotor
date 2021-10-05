using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartMotor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Services
{
    public class PolicyService : BaseService, IPolicyService
    {
        private ISession _session;
        public ISession Session { get { return _session; } }
        public PolicyService(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public IEnumerable<PolicyInquiryViewModel> Inquiry(string search)
        {
            if (String.IsNullOrEmpty(search))
                search = "XXXX";

            List<PolicyInquiryViewModel> result = new List<PolicyInquiryViewModel>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.FindPolicyInfo";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Search", search.ToString()));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PolicyInquiryViewModel item = new PolicyInquiryViewModel();
                                item.rnPolicy = Convert.ToInt32(reader["rnPolicy"].ToString());
                                item.policyNo = reader["policyNo"].ToString();
                                item.carRegistrationNo = reader["CarRegis"].ToString();
                                item.assuredName = reader["assuredName"].ToString();

                                item.policyStartDate = reader["policyStartDate"].ToString();
                                item.policyEndDate = reader["policyEndDate"].ToString();

                                double BasePremium = Convert.ToDouble(reader["policyBasePremium"].ToString());

                                item.policyBasePremium = DoFormat(BasePremium);
                                item.policyPremiumPerKm = reader["policyPremiumPerKm"].ToString();

                                item.gpsId = reader["gpsId"].ToString();
                                item.carModel = reader["carModel"].ToString();
                                item.PolicyType = reader["PolicyType"].ToString();
                                item.PolicyStatus = reader["PolicyStatus"].ToString();

                                result.Add(item);
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

        public IEnumerable<PolicyPaymentDetail> InqDetail(long rnPolicy)
        {
            List<PolicyPaymentDetail> result = new List<PolicyPaymentDetail>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetPolicyPaymentDetail";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@rnPolicy", rnPolicy));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PolicyPaymentDetail item = new PolicyPaymentDetail();
                                item.start_bill_date = reader["start_bill_date"].ToString();
                                item.end_bill_date = reader["end_bill_date"].ToString();
                                item.period_no = reader["period_no"].ToString();

                                item.invoice_no = reader["invoice_no"].ToString();
                                item.payment_due_date = reader["payment_due_date"].ToString();
                                item.status = reader["status"].ToString();
                                item.payment_type = reader["payment_type"].ToString();
                                item.period_no = reader["period_no"].ToString();
                                item.payment_status = reader["payment_status"].ToString();
                                item.gps_id = reader["gps_id"].ToString();
                                item.paid_date = reader["paid_date"].ToString();
                                item.total_distance = reader["total_distance"].ToString();
                                item.premium_per_km = reader["premium_per_km"].ToString();


                                double Amount = Convert.ToDouble(reader["total_amount_insurer"].ToString());

                                item.total_amount_insurer = DoFormat(Amount);

                                result.Add(item);
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

        public  string DoFormat(double myNumber)
        {
            return string.Format("{0:n2}", myNumber).Replace(".00", "");
        }
        

        public void ChangeGPS(long rnPolicy, string gpsID, string invoiceNo)
        {
            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.UpdateChnageGPS";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@rnPolicy", rnPolicy));
                        command.Parameters.Add(new SqlParameter("@invoiceNo", invoiceNo));
                        command.Parameters.Add(new SqlParameter("@gpsID", gpsID));
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {

                }
                finally {
                    context.Database.CloseConnection();
                }
            }
        }

        public IEnumerable<PolicyInquiryViewModel> InqTransaction(string search)
        {
            if (String.IsNullOrEmpty(search))
                search = "XXXX";

            List<PolicyInquiryViewModel> result = new List<PolicyInquiryViewModel>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.FindPolicyTransactionInfo";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Search", search.ToString()));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PolicyInquiryViewModel item = new PolicyInquiryViewModel();
                                item.rnPolicy = Convert.ToInt32(reader["rnPolicy"].ToString());
                                item.policyNo = reader["policyNo"].ToString();
                                item.carRegistrationNo = reader["CarRegis"].ToString();
                                item.assuredName = reader["assuredName"].ToString();

                                item.policyStartDate = reader["policyStartDate"].ToString();
                                item.policyEndDate = reader["policyEndDate"].ToString();

                                double BasePremium = Convert.ToDouble(reader["policyBasePremium"].ToString());

                                item.policyBasePremium = DoFormat(BasePremium);
                                item.policyPremiumPerKm = reader["policyPremiumPerKm"].ToString();

                                item.gpsId = reader["gpsId"].ToString();
                                item.carModel = reader["carModel"].ToString();
                                item.PolicyType = reader["PolicyType"].ToString();
                                item.PolicyStatus = reader["PolicyStatus"].ToString();

                                result.Add(item);
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

        public IEnumerable<PolicyTransaction> TransactionLog(string policyNo)
        {

            List<PolicyTransaction> result = new List<PolicyTransaction>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetPolicyAPILogs";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@policyNo", policyNo));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PolicyTransaction item = new PolicyTransaction();
                                item.LogType = reader["LogType"].ToString();
                                item.atDate = reader["atDate"].ToString();
                                item.id = reader["id"].ToString();
                                item.policyNo = reader["policyNo"].ToString();
                                item.status = reader["status"].ToString();
                                item.message = reader["message"].ToString();
                                result.Add(item);
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
    }
}
