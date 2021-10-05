using SmartMotor.Data;
using SmartMotor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Services
{
    interface IGpsInfo
    {
        IEnumerable<GpsInfo> Read();

        IList<GpsInfo> GetAll();

        void Create(GpsInfo data);
        void Update(GpsInfo data);
        void Destroy(GpsInfo data);

        void UpdateGpsStatus(string gpsid, string status);

        public IEnumerable<string> GetGpsStatus();
    }
}
