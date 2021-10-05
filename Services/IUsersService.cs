using SmartMotor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Services
{
    public interface IUsersService
    {
        IEnumerable<UserViewModel> Read();
        void Update(UserViewModel user);
        void Destroy(UserViewModel user);
    }
}
