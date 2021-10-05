using SmartMotor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Services
{
    public abstract class BaseService
    {
        public virtual ApplicationDbContext GetContext()
        {
            return new ApplicationDbContext();
        }
    }
}
