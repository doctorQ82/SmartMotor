using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SmartMotor.Data;
using System.Globalization;
using SmartMotor.Models;
using SmartMotor.Services;

namespace SmartMotor.Services
{
    public class UserService : BaseService, IUsersService
    {
        private static bool UpdateDatabase = false;
        private ISession _session;
        public ISession Session { get { return _session; } }
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public void Destroy(UserViewModel user)
        {
            using (var db = GetContext())
            {
                var entity = new User();

                entity.UserId = user.UserId;
                db.Users.Attach(entity);
                db.Users.Remove(entity);
                db.SaveChanges();
                //string sql = String.Format("DELETE Users WHERE UserID = '{0}'", user.UserId);
                //db.Database.ExecuteSqlRaw(sql);
                //db.SaveChanges();
            }
        }


        public IEnumerable<UserViewModel> Read()
        {
            List<UserViewModel> user = new List<UserViewModel>();

            using (var dataContext = GetContext())
            {
                try
                {
                    var sources = dataContext.CfgRoles.ToList();

                    user = dataContext.Users.ToList().Select(o =>
                    {
                        var _role = sources.FirstOrDefault(r => r.RoleId == o.IsRole);

                        return new UserViewModel
                        {
                            UserId = o.UserId,
                            LogonName = o.LogonName,
                            DisplayName = o.DisplayName,
                            Position = o.Position,
                            Email = o.Email,
                            GroupAgent = o.GroupAgent,
                            IsActive = o.IsActive,
                            Role = new RoleViewModel()
                            {
                                RoleID = _role.RoleId,
                                RoleName = _role.RoleName
                            },
                            Created = o.Created,
                            CreatedBy = o.CreatedBy,
                            Updated = o.Updated,
                            UpdatedBy = o.UpdatedBy
                        };
                    }).ToList();
                }
                catch (Exception ex)
                { 
                
                }
            }

            return user;
        }

        public void Update(UserViewModel user)
        {
            string _username = _session.GetString("_username").ToString();
            using (var db = GetContext())
            {
                try
                {
                    //var _users = db.Users.First(a => a.UserId == user.UserId);
                    //_users.IsRole = user.Role.RoleID;
                    //_users.IsActive = user.IsActive;
                    //_users.Updated = DateTime.Now;
                    //_users.UpdatedBy = _username.ToString();
                    //db.SaveChanges();

                    string sql = String.Format("UPDATE Users SET IsRole = '{0}', IsActive = '{1}' ," +
    "Updated = '{2}',  UpdatedBy = '{3}' WHERE UserID = '{4}'", user.Role.RoleID, user.IsActive, DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("en-US")), _username.ToString(), user.UserId);
                    db.Database.ExecuteSqlRaw(sql);
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
    }
}

