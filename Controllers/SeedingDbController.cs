using LibraryManagementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    //[controller]
    [Route("api/seed")]
    [ApiController]
    public class SeedingDbController : ControllerBase
    {
        private readonly SeedingDbService _service;
        public SeedingDbController(SeedingDbService service)
        {
            _service = service;
        }

        [HttpPost("books")] 
        public IActionResult PopulateBooks(int numofentries)
        {
            return Ok(_service.PopulateBooks(numofentries));
        }
    }
}
