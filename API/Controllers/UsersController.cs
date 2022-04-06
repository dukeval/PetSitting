using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Models;
using API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using API.DTO;
using API.Interfaces;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UsersController(DataContext context, IMapper mapper, IUserRepository userRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await this.userRepository.GetUsersAsync());
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<User>> GetUser(string userName)
        {
            var usrFound = await this.userRepository.GetUserAsync(userName);
            if (usrFound != null)
                return Ok(usrFound);

            return BadRequest("User not found");
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            var userAdded = await this.userRepository.CreateUserAsync(user);
            if (userAdded)
                return Content("User created");

            return Content("Unable to add user, that user already exist.");
        }

        [HttpPut("{userName}")]
        public async Task<ActionResult> UpdateUser(string userName, User user)
        {
            await this.userRepository.UpdateAsync(userName, user);
            return Ok();
        }
    }
}