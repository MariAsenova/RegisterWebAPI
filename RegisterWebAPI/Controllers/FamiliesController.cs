﻿using System;
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
                IEnumerable<Family> enumerable = await repositoryFamily.GetRange(5);
                return Ok(enumerable);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
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
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateAdultAsync([FromBody] Adult adult, [FromQuery] string streetName,
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
                return StatusCode(500, e.Message);
            }

            return Ok();
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
                IEnumerable<Family> families = repositoryFamily.GetAll().GetAwaiter().GetResult();
                Family familyFound = families.FirstOrDefault(family => family.StreetName.Equals(streetName)
                                                                       && family.HouseNumber == houseNumber);
                familyFound.Adults.Add(adult);

                await repositoryFamily.Update(familyFound);
                Console.WriteLine(adult.FirstName + " " + streetName + " " + houseNumber);
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