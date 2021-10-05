using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotor.Models
{
    public class ClsSetting
    {
        public string token { get; set; }

        public string UserIsExists { get; set; }

        public string SyncUser { get; set; }
        
        public string LDAPUser { get; set; }

        public string JwtKey { get; set; }

        public string JwtIssuer { get; set; }

        public string JwtAudience { get; set; }

        public string JwtExpireMinute { get; set; }

        public string SecurePay { get; set; }

        public string Single { get; set; }

        public string authCodeForApiOwner { get; set; }

        public string ApiUser { get; set; }

        public string ApiPassword { get; set; }

        public string tokenPayment{ get; set; }

        public string DirectPay { get; set; }
        public string QPDelete{ get; set; }

    }
}


   