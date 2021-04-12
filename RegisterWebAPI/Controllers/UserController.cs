using System;
using System.Threading.Tasks;
using Familyregister.Data;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace RegisterWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetPasswordOfUser([FromQuery] string username)
        {
            try
            {
                User userWithPassword = userService.GetUserWithPassword(username).Result;
                return Ok(userWithPassword);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}