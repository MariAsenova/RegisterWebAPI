using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Familyregister.Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using RegisterWebAPI.Repository;

namespace RegisterWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase
    {
        private IRepository<Family> repositoryFamily;
        private IRepository<Adult> repositoryAdult;

        public FamiliesController(IRepository<Family> repositoryFamily, IRepository<Adult> repositoryAdult)
        {
            this.repositoryFamily = repositoryFamily;
            this.repositoryAdult = repositoryAdult;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync()
        {
            try
            {
                IEnumerable<Family> enumerable = await repositoryFamily.GetAll();
                return Ok(enumerable);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdultAsync([FromRoute] int id)
        {
            try
            {
                Adult byId = await repositoryAdult.GetById(id);
                return Ok(byId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPatch]
        public async Task UpdateAdultAsync([FromBody] Adult adult, [FromQuery] string streetName,
            [FromQuery] int? houseNumber)
        {
            Console.WriteLine(adult.FirstName + " " + streetName + " " + houseNumber);
            try
            {
                await repositoryAdult.Update(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task DeleteAdult([FromRoute] int id)
        {
            try
            {
                Adult byId = await repositoryAdult.GetById(id);
                await repositoryAdult.Remove(byId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddAdultAsync([FromBody] Adult adult, [FromQuery] string streetName,
            [FromQuery] int? houseNumber)
        {
            try
            {
                // TODO
                // find family, add adult to the list, update the family
                Console.WriteLine(adult.FirstName + " " + streetName + " " + houseNumber);
                await repositoryAdult.Add(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }

            return Ok();
        }
    }
}