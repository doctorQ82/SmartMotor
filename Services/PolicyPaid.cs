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
    public class PolicyPaid : BaseService, IPolicyPaid
    {
        private ISession _session;
        public ISession Session { get { return _session; } }
        public PolicyPaid(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public IEnumerable<PaymentSummary> Read(string start, string end)
        {
            start = (start == null ? "19000101" : start);
            end = (end == null ? "19000101" : end);

            string _sourcename = _session.GetString("_sourcename").ToString();

            List<PaymentSummary> paid = new List<PaymentSummary>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetPolicyPaymentPaid";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@start", start.ToString()));
                        command.Parameters.Add(new SqlParameter("@end", end.ToString()));

                        using (var reader = command.ExecuteReader())
                        {
                            var entities = new List<PaymentSummary>();
                            while (reader.Read())
                            {
                                PaymentSummary item = new PaymentSummary();
                                item._pid = Convert.ToInt32(reader["pid"].ToString());
                                item._policy_no = reader["policy_no"].ToString();
                                item._gps_id = reader["gps_id"].ToString();
                                item._period_no = Convert.ToInt32(reader["period_no"].ToString());
                                item._start_bill_date = reader["start_bill_date"].ToString();
                                item._end_bill_date = reader["end_bill_date"].ToString();
                                item._total_distance = decimal.Parse(reader["total_distance"].ToString());
                                item._current_distance = decimal.Parse(reader["current_distance"].ToString());
                                item._previous_distance = decimal.Parse(reader["previous_distance"].ToString());
                                item._total_amount = decimal.Parse(reader["total_amount"].ToString());
                                item._premium_per_km = decimal.Parse(reader["premium_per_km"].ToString());
                                item._total_discount = decimal.Parse(reader["total_discount"].ToString());
                                item._total_amount_insurer = decimal.Parse(reader["total_amount_insurer"].ToString());
                                item._payment_due_date = reader["payment_due_date"].ToString();
                                item._invoice_no = reader["invoice_no"].ToString();
                                item._payment_url = reader["payment_url"].ToString();
                                item._payment_type = reader["payment_type"].ToString();
                                item._payment_status = reader["payment_status"].ToString();
                                item._paid_date = reader["paid_date"].ToString();
                                item._tax_invoice_url = reader["tax_invoice_url"].ToString();
                                item._payment_channel = reader["payment_channel"].ToString();

                                paid.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                { 
                
                }
      

            }

            return paid;
        }

        public IEnumerable<PaymentUnPaid> UnPaidRead(string start, string end)
        {
            start = (start == null ? "19000101" : start);
            end = (end == null ? "19000101" : end);

            List<PaymentUnPaid> unpaid = new List<PaymentUnPaid>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetPolicyPaymentUnPaid";
                        command.CommandType = CommandType.StoredProcedure;
                        //command.Parameters.Add(new SqlParameter("@start", start.ToString()));
                        //command.Parameters.Add(new SqlParameter("@end", end.ToString()));

                        using (var reader = command.ExecuteReader())
                        {
                            var entities = new List<PaymentSummary>();
                            while (reader.Read())
                            {
                            PaymentUnPaid item = new PaymentUnPaid();
                            item._pid = Convert.ToInt32(reader["pid"].ToString());
                            item._policy_no = reader["policy_no"].ToString();
                            item._gps_id = reader["gps_id"].ToString();
                            item._period_no = Convert.ToInt32(reader["period_no"].ToString());
                            item._start_bill_date = reader["start_bill_date"].ToString();
                            item._end_bill_date = reader["end_bill_date"].ToString();

                            item._total_amount = decimal.Parse(reader["total_amount"].ToString());
                            item._premium_per_km = decimal.Parse(reader["premium_per_km"].ToString());

                            item._total_amount_insurer = decimal.Parse(reader["total_amount_insurer"].ToString());

                            item._payment_due_date = reader["payment_due_date"].ToString();
                            item._invoice_no = reader["invoice_no"].ToString();
                            item._payment_type = reader["payment_type"].ToString();
                            item._payment_status = reader["payment_status"].ToString();

                            item._PolicyStatus = reader["PolicyStatus"].ToString();
                            item._assuredName = reader["assuredName"].ToString();
                            item._PolicyType = reader["PolicyType"].ToString();
                            item._PaymentUrl = reader["payment_url"].ToString();
                            item._carRegistrationNo = reader["carRegistrationNo"].ToString();
                                
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

        public IEnumerable<string> PaymentStatus()
        {
            List<string> entities = new List<string>();

            using (var dataContext = GetContext())
            {
                try
                {

                    entities = dataContext.TPaymentSummaries.ToList()
                        .Select(o => o.Status
                    ).ToList();
                }
                catch (Exception ex)
                {

                }
            }

            return entities;
        }
    }
}
