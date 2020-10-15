using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AuthenticationJWT.Data;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using AuthenticationJWT.models;
using AuthenticationJWT.Services;
using System.Collections.Generic;

namespace AuthenticationJWT.Controllers
{
    [ApiController]
    [Route("v1/core")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("user")]
        public async Task<ActionResult<User>> CreateUser([FromServices] DataContext context, [FromBody]User body)
        {
            if (ModelState.IsValid) 
            {
                context.User.Add(body);
                await context.SaveChangesAsync();
                return body;
            } 
            else 
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("users")]
        [Authorize]
        public async Task<ActionResult<List<User>>> GetUsers([FromServices] DataContext context, [FromBody]User body)
        {
            var users = await context.User.ToListAsync();

            if (users == null) {
                return NotFound(new { message = "There are not any user"});
            }

            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUserById([FromServices] DataContext context, int id)
        {
            var users = await context.User.FirstOrDefaultAsync(x => x.Id == id);

            if (users == null) {
                return NotFound(new { message = "User not found"});
            }

            return users;
        }
    }
}