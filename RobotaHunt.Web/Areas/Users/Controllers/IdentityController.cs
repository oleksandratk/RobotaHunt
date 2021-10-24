using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;
using RobotaHunt.Web.Users.Etc;
using Newtonsoft.Json;

namespace RobotaHunt.Web.Users
{
    public class IdentityController : Controller
    {
        [AllowAnonymous]
        [OutputCache(NoStore = true, Location = OutputCacheLocation.None)]
        public ActionResult Login()
        {
            return View("/Areas/Users/Views/Shared/Login.cshtml");
        }
        
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(BaseLoginModel model)
        {
            ValidateRequestHeader(model.UserName);
            AccountUserDto user = UserApiManager.Find(model.UserName, model.Password);

            if (user == null)
                return Json(new LoginResponseModel
                {
                    IsLoggedIn = false
                });

            TokenWrapper wrapper = SignIn(model.UserName, model.Password);
            if (wrapper == null)
                return Json(new LoginResponseModel {IsLoggedIn = false});

            if (string.IsNullOrWhiteSpace(wrapper.AccessToken))
                return Json(new LoginResponseModel {IsLoggedIn = false});

            return Json(new LoginResponseModel
            {
                IsLoggedIn = true,
                AccessToken = wrapper.AccessToken,
                RenewalTime = wrapper.RenewalTime
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult Register()
        {
            return null;
        } 
        
        private TokenWrapper SignIn(string username, string password)
        {
            try
            {
                string result = TokenHelper.GetToken(username, password);
                TokenWrapper wrapper = JsonConvert.DeserializeObject<TokenWrapper>(result);
                if (string.IsNullOrEmpty(wrapper.AccessToken))
                    return null;

                return string.IsNullOrWhiteSpace(wrapper.AccessToken) ? null : wrapper;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Validates a header that is generated in Login razor view and sent with request to this MVC Controller endpoints.
        /// </summary>
        private void ValidateRequestHeader(string userName)
        {
            try
            {
                string cookieToken = "";
                string formToken = "";

                IEnumerable<string> tokenHeaders = HttpContext.Request.Headers.GetValues("RequestVerificationToken");
                if (tokenHeaders != null && tokenHeaders.Any())
                {
                    string[] tokens = tokenHeaders.First().Split(':');
                    if (tokens.Length == 2)
                    {
                        cookieToken = tokens[0].Trim();
                        formToken = tokens[1].Trim();
                    }
                }

                AntiForgery.Validate(cookieToken, formToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}