using JwtAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("Admins")]
        [Authorize(Roles ="Admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.FirstName}, you are an {currentUser.Role}");
        }

        [HttpGet]
        [Route("Seller")]
        [Authorize(Roles = "seller")]
        public IActionResult SellerEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.FirstName}, you are a {currentUser.Role}");
        }

        [HttpGet]
        [Route("AdminsAndSellers")]
        [Authorize(Roles = "Admin,seller")]
        public IActionResult AdminAndSellerEndPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.FirstName}, you are an {currentUser.Role}");
        }
        private UserModel GetCurrentUser()
        { 
            var identity=HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
                    FirstName=userClaims.FirstOrDefault(x=>x.Type==ClaimTypes.GivenName)?.Value
                };
            }
            return null;
            
        }
    }
}
