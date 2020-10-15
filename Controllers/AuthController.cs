using System.Threading.Tasks;
using AuthenticationJWT.Data;
using AuthenticationJWT.models;
using AuthenticationJWT.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationJWT.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<dynamic>> Autheticate([FromServices]DataContext context , [FromBody]User body)
        {
            var user = context.User.FirstOrDefaultAsync(x => x.Email == body.Email && x.Password == body.Password);

            if (user == null) {
                return NotFound(new { message = "User not found" });
            }

            var token = TokenService.GenerateToken(user.Result.Email, user.Result.Role);

            return new 
            {
                user = user.Result,
                token = token
            };
        }
    }
}