using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RobotaHunt.Identity
{
    public class AccountUser : IdentityUser<Guid, AccountUserLogin, AccountUserRole, AccountUserClaim>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? ResetToken { get; set; }
        public Guid? ApiKey { get; set; }
        public DateTimeOffset? ResetTokenExpirationTime { get; set; }

    }
}
