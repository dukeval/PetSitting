using System;
using API.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using API.DTO;
using System.Linq;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SittersController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public SittersController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetSitters()
        {
            var sitters = await this.context.Sitters.Include(pet => pet.PetsSpecialty).ToListAsync();
            var listOfSitters = this.mapper.Map<IEnumerable<SitterDTO>>(sitters);

            return Ok(listOfSitters);
        }

        [HttpGet("{sitterName}")]
        public async Task<ActionResult> GetSitter(string sitterName)
        {
            var sitters = await this.context.Sitters.Where(x => x.UserName == sitterName).Include(pet => pet.PetsSpecialty).FirstOrDefaultAsync();
            if (sitters != null)
            {
                var sitter = this.mapper.Map<SitterDTO>(sitters);
                return Ok(sitter);
            }

            return BadRequest("Invalid user");
        }
    }
}