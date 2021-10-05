using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartMotor.Data;
using SmartMotor.Models;
using SMTPremium.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Services
{
    public class GpsInfoService : BaseService, IGpsInfo
    {
        private ISession _session;

        public ISession Session { get { return _session; } }
        public GpsInfoService(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }



        public void Create(GpsInfo gps)
        {
            string _username = _session.GetString("_username").ToString();
            using (var db = GetContext())
            {
                try
                {
                    var _gps = db.TGpsInfos.FirstOrDefault(a => a.GpsId == gps.GpsId);

                    if (_gps == null)
                    {
                        var entity = new TGpsInfo();

                        entity.GpsId = gps.GpsId;
                        entity.GpsStatus = "A";
                        entity.GpsRegister = DateTime.Now;
                        entity.ModifiedBy = _username.ToString();
                        entity.ModifiedDate = DateTime.Now;

                        db.TGpsInfos.Add(entity);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                { 
                
                }
          
            }
        }
        public void Destroy(GpsInfo data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GpsInfo> Read()
        {
            return GetAll();
        }

        public void Update(GpsInfo data)
        {
            string _username = _session.GetString("_username").ToString();

            using (var db = GetContext())
            {
                var _gps = db.TGpsInfos.First(a => a.GpsId == data.GpsId);
                _gps.GpsStatus = (data.GpsStatus.Status == "InActive" ? "I":"A");
                _gps.ModifiedBy = _username;
                _gps.ModifiedDate = DateTime.Now;
                db.SaveChanges();
            }
        }

        public IList<GpsInfo> GetAll()
        {
            using (var db = GetContext())
            {
                var status = db.VwGpsStatuses.ToList();

                var result = db.TGpsInfos.ToList().Select(o =>
                {
                    var g = status.FirstOrDefault(c => c.StatusCode == o.GpsStatus);
                   
                    return new GpsInfo
                    {
                        SID = o.Sid,
                        GpsId = o.GpsId,
                        Gps_Register = Convert.ToDateTime(o.GpsRegister),
                        OrderPerfixID = o.OrderPerfixId,
                        UseDate = Convert.ToDateTime(o.UseDate),
                        GpsStatus = new GpsStatus()
                        {
                            Status_Code = g.StatusCode,
                            Status = g.Status
                        }
                    };
                }).ToList();

                return result;
            }
        }

        public IEnumerable<string> GetGpsStatus()
        {
            List<string> result = new List<string>();

            using (var context = GetContext())
            {
                context.Database.OpenConnection();

                try
                {
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "dbo.GetGpsStatus";
                        command.CommandType = CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            var entities = new List<PaymentSummary>();
                            while (reader.Read())
                            {
                                string GpsStatus = reader["GpsStatus"].ToString();
                                result.Add(GpsStatus);
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

        public void UpdateGpsStatus(string gpsid, string status)
        {
            string _username = _session.GetString("_username").ToString();

            using (var db = GetContext())
            {
                var _gps = db.TGpsInfos.FirstOrDefault(a => a.GpsId == gpsid);
                _gps.GpsStatus = (status == "InActive" ? "I" : "A");
                _gps.ModifiedBy = _username;
                _gps.ModifiedDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
