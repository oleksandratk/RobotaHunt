namespace RobotaHunt.Web.Users.Etc
{
    public class LoginResponseModel
    {
        public bool IsLoggedIn { get; set; }
        public bool IsFirstLogin { get; set; }
        public string AccessToken { get; set; }
        public long RenewalTime { get; set; }
    }

    public class BaseLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}