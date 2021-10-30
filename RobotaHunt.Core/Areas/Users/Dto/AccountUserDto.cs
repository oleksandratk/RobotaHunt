using System;

namespace RobotaHunt.Web.Users
{
    public class AccountUserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid? ApiKey { get; set; }
        public Guid? ResetToken { get; set; }
        public DateTimeOffset? ResetTokenExpirationTime { get; set; }

    }
}