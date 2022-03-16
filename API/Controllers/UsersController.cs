using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PetSitting.Models;
using API.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PetSitting.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> users = new List<User> { new User { Name = "Jude",
                                                           Age = 20,
                                                           City = "Bellvile",
                                                           State = "NJ",
                                                           Pets = new List<string> { "Beaver" }
                                                        },
                                                new User{Name="Beatrice",
                                                         Age=35,
                                                         City="Newark",
                                                         State="GA",
                                                         Pets= new List<string>{"Dog, Cat,Parrot"}} };
        private readonly DataContext context;

        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            var newUsersList = new List<User>();

            foreach (var item in users)
            {
                newUsersList.Add(new User { Name = item.UserName });
            }
            return newUsersList;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<User>> GetUser(string userName)
        {
            var usr = await context.Users.Where(x => x.UserName == userName).FirstOrDefaultAsync();
            if (usr != null)
            {
                return new User { Name = usr.UserName }; //users.Where(usr => usr.Name == userName).FirstOrDefault();                
            }

            return BadRequest("User not found");
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            users.Add(user);
            return Ok(users);
        }

        [HttpPut("{userName}")]
        public async Task<ActionResult> UpdateUser(string userName, User user)
        {
            var index = users.FindIndex(x => x.Name == userName);
            if (index >= 0)
            {
                users[index] = user;
                return Ok(users);
            }

            return BadRequest("Unable to update user");
        }
    }
}