using System;
using RobotaHunt.Identity.Attributes;
using RobotaHunt.Identity.Constants;
using RobotaHunt.Identity.Dto;
using RobotaHunt.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace RobotaHunt.Identity
{
    [ApiController]
    [AllowAnonymous]
    [ApiBaseAuth]
    public class IdentityApiController : ControllerBase
    {
        public IdentityApiController(UserManager<AccountUser, Guid> userManager)
        {
            UserManager = userManager ?? throw new ArgumentException(nameof(userManager));
        }
        public UserManager<AccountUser, Guid> UserManager { get; set; }

        [HttpPost(ApiRoutes.FindUser)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(RequestResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RequestResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResponse))]
        public IActionResult Find([FromForm] string username, [FromForm] string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                return StatusCode(StatusCodes.Status401Unauthorized, "NO username!");

            if (string.IsNullOrWhiteSpace(password))
                return StatusCode(StatusCodes.Status401Unauthorized, "NO Password!");

            try
            {
                AccountUser user = UserManager.Find(username, password);
                if (user == null)
                    return StatusCode(StatusCodes.Status401Unauthorized,
                        $"InvalidCredentials for the user {username}.");

                AccountUserDto accountUserDto = new AccountUserDto();
                accountUserDto.Email = user.Email;
                accountUserDto.UserName = user.UserName;

                return StatusCode(StatusCodes.Status200OK, accountUserDto);
                //TODO would be nice to add some logging
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ooops, something went wrong!");
            }
        }

        [HttpPost(ApiRoutes.IdentityToken)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(RequestResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(RequestResponse))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RequestResponse))]
        public IActionResult CreateToken([FromForm] string username, [FromForm] string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                return StatusCode(StatusCodes.Status401Unauthorized, "NO username!");

            if (string.IsNullOrWhiteSpace(password))
                return StatusCode(StatusCodes.Status401Unauthorized, "NO Password!");

            try
            {
                AccountUser user = UserManager.Find(username, password);

                if (user == null)
                    return StatusCode(StatusCodes.Status401Unauthorized, "Auth FAILED");


                TokenWrapper wrapper = TokenHelper.GenerateIdentityToken(user);
                return StatusCode(StatusCodes.Status200OK, wrapper);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ooops, something went wrong!");
            }
        }
    }
}