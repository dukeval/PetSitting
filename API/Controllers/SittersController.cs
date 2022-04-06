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
using API.Interfaces;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SittersController : ControllerBase
    {
        private readonly ISitterRepository sitterRepository;
        private readonly DataContext context;
        private readonly IMapper mapper;

        public SittersController(ISitterRepository sitterRepository, DataContext context, IMapper mapper)
        {
            this.sitterRepository = sitterRepository;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetSitters()
        {
            return Ok(await this.sitterRepository.GetSittersAsync());
        }

        [HttpGet("{sitterName}")]
        public async Task<ActionResult> GetSitter(string sitterName)
        {
            var sitter = await this.sitterRepository.GetSitterAsync(sitterName);
            if (sitter != null)
            {
                return Ok(sitter);
            }

            return BadRequest("Invalid user");
        }
    }
}