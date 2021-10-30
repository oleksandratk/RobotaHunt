using System;
using System.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace RobotaHunt.Web.Users
{
    public static class TokenHelper
    {
        public static string GetToken(string username, string password)
        {
            RestClient client = new RestClient { BaseUrl = new Uri("") };  //TODO add here url to Identity Service
            RestRequest request = new RestRequest("", Method.POST)
            {
                Timeout = 10000
            };
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            return client.Execute(request).Content;
        }

        public static string RefreshToken(string oldToken)
        {
            RestClient client = new RestClient { BaseUrl = new Uri("") };  //TODO add here url to Identity Service
            RestRequest request = new RestRequest("", Method.GET)
            {
                Timeout = 10000
            };
            request.AddParameter("Authorization", oldToken, ParameterType.HttpHeader);
            var result = client.Execute(request).Content;
            return result;
        }

        public static TokenPayload GetHeaderPayload(string authorizationHeader)
        {
            string token = authorizationHeader.Split(' ')[1];
            return GetTokenPayload(token);
        }

        public static TokenPayload GetTokenPayload(string token)
        {          
            byte[] key = Convert.FromBase64String(""); //TODO add key here

            try
            {
                string json = Jose.JWT.Decode(token, key);//Jose from AWE nuget package.
                return JsonConvert.DeserializeObject<TokenPayload>(json);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}