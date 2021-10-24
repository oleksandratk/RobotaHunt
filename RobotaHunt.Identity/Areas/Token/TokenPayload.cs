using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RobotaHunt.Identity
{
    public class TokenPayload
    {
        [JsonProperty("jti")]
        public Guid Id { get; set; }

        [JsonProperty("aud")]
        public string Audience { get; set; }

        [JsonProperty("iat")]
        public long IssuedAt { get; set; }

        [JsonProperty("exp")]
        public long ExpiresAt { get; set; }

        [JsonProperty("iss")]
        public string Issuer { get; set; }

        [JsonProperty("unique_name")]
        public string UniqueName { get; set; }

    }
}