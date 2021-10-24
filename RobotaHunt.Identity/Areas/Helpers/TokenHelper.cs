using System;
using Jose;
using Newtonsoft.Json;

namespace RobotaHunt.Identity
{
    public static class TokenHelper
    {
        public static TokenWrapper GenerateIdentityToken(AccountUser user)
        {
            byte[] key = Convert.FromBase64String(""); //TODO add here token secret
            string issuer = "RobotaHunt Identity";
            double expiration = double.Parse(""); //TODO add expiration time

            long issued = DateTime.UtcNow.ToUnix();
            long expires = DateTime.UtcNow.AddMinutes(expiration).ToUnix();
            TokenPayload tokenPayload = new TokenPayload
            {
                Id = Guid.NewGuid(),
                UniqueName = user.UserName,
                Issuer = issuer,
                IssuedAt = issued,
                ExpiresAt = expires
            };

            string payload = JsonConvert.SerializeObject(tokenPayload);
            string encodedToken = JWT.Encode(payload, key, JwsAlgorithm.HS256);
            return new TokenWrapper(encodedToken, expires, issued);
        }
        
        public static long ToUnix(this DateTime date)
        {
            DateTime utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (long)date.Subtract(utc0).TotalSeconds;
        }

    }
}