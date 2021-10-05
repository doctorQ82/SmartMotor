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
    public class NotificationService : BaseService, INotificationService
    {
        private ISession _session;
        public ISession Session { get { return _session; } }
        public NotificationService(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }


        public IEnumerable<NotificationAlert> TransactionLog(string policyNo)
        {
            List<NotificationAlert> result = new List<NotificationAlert>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetNotificationAlert";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@policyNo", policyNo));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NotificationAlert item = new NotificationAlert();
                                item.RunNo = reader["RunNo"].ToString();
                                item.policy_no = reader["policy_no"].ToString();
                                item.invoice_no = reader["invoice_no"].ToString();
                                item.due_date = reader["due_date"].ToString();
                                item.Message_Type = reader["Message_Type"].ToString();
                                item.MessageText = reader["MessageText"].ToString();
                                item.SendDate = reader["SendDate"].ToString();
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
