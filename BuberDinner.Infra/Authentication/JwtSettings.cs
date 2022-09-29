using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuberDinner.Infra.Authentication
{
    public class JwtSettings
    {
        public const string Section_Name = "JwtSettings";
        public string Secret { set; get; }
        public int ExpiryMinutes { set; get; }
        public string Issuer { set; get; }
        public string Audience { set; get; }
    }
}