
using SmartMotor.Data;
using SmartMotor.Models;
using SmartMotor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SmartMotor.Repository;


namespace SmartMotor.Repository
{
    public class UserRepository
    {
        #region "Declare variable"
        private IConfiguration config { get; set; }


        public string JwtKey { get; set; }

        public string JwtIssuer { get; set; }

        public string JwtAudience { get; set; }

        public string JwtExpireMinute { get; set; }
        #endregion


        public UserRepository(IConfiguration _config)
        {
            var section = _config.GetSection("settings").Get<ClsSetting>();

            this.JwtKey = section.JwtKey.ToString();
            this.JwtIssuer = section.JwtIssuer.ToString();
            this.JwtAudience = section.JwtAudience.ToString();
            this.JwtExpireMinute = section.JwtExpireMinute.ToString();

        }

        public Users Authenticate(string username)
        {
            Users _user = new Users();

            UserAuhenService _Inquser = new UserAuhenService();
            var user = _Inquser.Inquiry(username);


            if (user == null)
            {
                return null;
            }
            else
            {
                foreach (User item in user)
                {

                    var claims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Sub,  item.LogonName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                    var expires = DateTime.Now.AddMinutes(Convert.ToDouble(JwtExpireMinute));
                    var token = new JwtSecurityToken(
                           issuer: JwtIssuer,
                           audience: JwtAudience,
                           claims: claims,
                           expires: expires,
                           signingCredentials: creds
                       );

                    var tokenHandler = new JwtSecurityTokenHandler();
                    _user.Username = item.LogonName.ToString();
                    _user.Password = "";
                    _user.RoleName = item.IsRole.ToString();
                    _user.Token = tokenHandler.WriteToken(token);
                    break;
                }
            }

            return _user;
        }

    }
}
