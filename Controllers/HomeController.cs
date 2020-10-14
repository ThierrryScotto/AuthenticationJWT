using System;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using AuthenticationJWT.models;
using AuthenticationJWT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AuthenticationJWT.Services;
using System.Threading.Tasks;

namespace AuthenticationJWT.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autheticate([FromBody]User body)
        {
            var user = UserRepository.Get(body.Username, body.Password);

            if (user == null) {
                return NotFound(new { message = "User not found" });
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new 
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
         public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";
    }
}