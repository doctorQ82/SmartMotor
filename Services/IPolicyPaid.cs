using SmartMotor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Services
{
    interface IPolicyPaid
    {
        IEnumerable<PaymentSummary> Read(string start, string end);

        IEnumerable<PaymentUnPaid> UnPaidRead(string start, string end);

        IEnumerable<string> PaymentStatus();
    }
}
