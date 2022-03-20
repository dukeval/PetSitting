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

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public UsersController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await context.Users.Include(pet => pet.Pets).ToListAsync();
            var newUsersList = mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(newUsersList);
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<User>> GetUser(string userName)
        {
            var usr = await context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
            if (usr != null)
            {
                var newUser = mapper.Map<UserDTO>(usr);
                return Ok(newUser);
            }

            return BadRequest("User not found");
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            var savedUser = context.Users.Where(x => x.UserName == user.UserName && x.Name == user.Name && x.City == user.City && x.State == user.State && x.Age == user.Age)?.ToList();

            if (savedUser.Count <= 0)//!(await context.Users.ContainsAsync(user)))
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();

                return Content("User created");
            }

            return BadRequest("Unable to add user, that user already exist.");
        }

        [HttpPut("{userName}")]
        public async Task<ActionResult> UpdateUser(string userName, User user)
        {
            // var index = users.FindIndex(x => x.Name == userName);
            // if (index >= 0)
            // {
            //     users[index] = user;
            //     return Ok(users);
            // }

            // return BadRequest("Unable to update user");
            return BadRequest();
        }
    }
}