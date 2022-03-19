using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PetSitting.Models;
using API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using API.DTO;

namespace PetSitting.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // private List<User> users = new List<User> { new User { Name = "Jude",
        //                                                    Age = 20,
        //                                                    City = "Bellvile",
        //                                                    State = "NJ",
        //                                                    Pets = new List<string> { "Beaver" }
        //                                                 },
        //                                         new User{Name="Beatrice",
        //                                                  Age=35,
        //                                                  City="Newark",
        //                                                  State="GA",
        //                                                  Pets= new List<string>{"Dog, Cat,Parrot"}} };
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
            var users = await context.Users.ToListAsync();
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
            //users.Add(user);
            //return Ok(users);
            return BadRequest();
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