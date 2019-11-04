using System;
using Microsoft.IdentityModel.Tokens;

namespace DealEat.WebApp.Authentication
{
    public class TokenProviderOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes( 5 );

        public SigningCredentials SigningCredentials { get; set; }
    }
}
