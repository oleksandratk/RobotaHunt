using System;
using Newtonsoft.Json;
using RestSharp;

namespace RobotaHunt.Web.Users
{
    public class UserApiManager
    {
        private static readonly string IdentityApiKey = ""; //TODO add key here

        public static AccountUserDto Find(string userName, string password)
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri("users\\find") //TODO add here uri to Identity
            };
            RestRequest request = new RestRequest("", Method.POST)
            {
                Timeout = 10000
            };
            request.AddHeader("Authorization", "Bearer " + IdentityApiKey);
            request.AddParameter("username", userName);
            request.AddParameter("password", password);
            var response = client.Execute(request).Content;
            return JsonConvert.DeserializeObject<AccountUserDto>(response);
        }
    }
}