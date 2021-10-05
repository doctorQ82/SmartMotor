using SmartMotor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Services
{
    interface INotificationService
    {
        IEnumerable<NotificationAlert> TransactionLog(string policyNo);

    }
}
