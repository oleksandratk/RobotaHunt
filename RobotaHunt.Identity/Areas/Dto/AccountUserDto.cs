using System;

namespace RobotaHunt.Identity.Dto
{
    public class AccountUserDto
    {
        public Guid? ResetToken { get; set; }
        public DateTimeOffset? ResetTokenExpirationTime { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid? ApiKey { get; set; }

    }
}