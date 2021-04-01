using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Familyregister.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace RegisterWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase
    {
        private IFamilyService familyService;

        public FamiliesController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        // endpoint method get
        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamiliesAsync()
        {
            try
            {
                IList<Family> families = await familyService.GetFamiliesAsync();
                return Ok(families);
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
                Adult adultAsync = await familyService.GetAdultAsync(id);
                return Ok(adultAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Adult>> UpdateAdultAsync([FromBody] Adult adult)
        {
            try
            {
                await familyService.UpdateAsync(adult);
                return Ok();
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
                await familyService.RemoveAdultAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}