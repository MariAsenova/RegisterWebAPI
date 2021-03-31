using Familyregister.Data;
using Microsoft.AspNetCore.Mvc;

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
        
        
    }
}