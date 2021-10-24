using System;
using Newtonsoft.Json;

namespace RobotaHunt.Identity
{
    public class TokenWrapper
    {
        public TokenWrapper(string token, long expires, long issued, string username = "")
        {
            AccessToken = token;
            ExpiresIn = (int)(expires - issued);
            Username = username;
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; } = "bearer";

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonIgnore]
        public long RenewalTime => DateTimeOffset.UtcNow.AddSeconds(0.9 * ExpiresIn).ToUnixTimeMilliseconds();

    }
}