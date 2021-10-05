using SmartMotor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Services
{
    interface IUserAuhenService
    {
        IEnumerable<User> Inquiry(string UserName);
    }
}
