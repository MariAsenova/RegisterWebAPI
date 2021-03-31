using System;
using System.Collections.Generic;
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
        
    }
}