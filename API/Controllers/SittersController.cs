using System;
using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace PetSitting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SittersController : ControllerBase
    {
        private readonly DataContext context;

        public SittersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult GetSitters()
        {
            return Ok();
        }

        [HttpGet("{sitterName}")]
        public ActionResult GetSitter(string sitterName)
        {
            return Ok();
        }
    }
}