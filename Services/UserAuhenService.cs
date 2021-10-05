using SmartMotor.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Services
{
    public class UserAuhenService : BaseService, IUserAuhenService
    {
        public IEnumerable<User> Inquiry(string UserName)
        {
            var entities = new List<User>();

            using (var context = GetContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    try
                    {
                        command.CommandText = "select * from Users where LogonName = @username";
                        command.Parameters.Add(new SqlParameter("@username", UserName));
                        command.CommandType = CommandType.Text;
                        context.Database.OpenConnection();

                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                User item = new User();
                                item.UserId = int.Parse(reader["UserID"].ToString());
                                item.LogonName = reader["logonName"].ToString();
                                item.DisplayName = reader["displayName"].ToString();
                                item.Position = reader["Position"].ToString();
                                item.Email = reader["email"].ToString();
                                item.GroupAgent = reader["groupAgent"].ToString();
                                item.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                                item.Created = Convert.ToDateTime(reader["Created"].ToString());
                                item.IsRole = int.Parse(reader["IsRole"].ToString());
                                item.CreatedBy = reader["CreatedBy"].ToString();

                                item.Updated = Convert.ToDateTime(reader["Created"].ToString());
                                item.UpdatedBy = reader["UpdatedBy"].ToString();

                                entities.Add(item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        context.Database.CloseConnection();
                    }

                }

            }

            return entities;
        }
    }
}
