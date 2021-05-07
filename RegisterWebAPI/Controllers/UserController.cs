using System;
using System.Threading.Tasks;
using Familyregister.Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using RegisterWebAPI.Repository;


namespace RegisterWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository userServiceRepository;

        public UserController(IUserRepository userServiceRepository)
        {
            this.userServiceRepository = userServiceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetPasswordOfUser([FromQuery] string username)
        {
            try
            {
                User userWithPassword = await userServiceRepository.GetUserWithPassword(username);
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