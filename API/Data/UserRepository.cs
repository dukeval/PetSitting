using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var savedUser = context.Users.Where(x => x.UserName == user.UserName && x.Name == user.Name && x.City == user.City && x.State == user.State && x.Age == user.Age)?.ToList();

            if (savedUser.Count <= 0)//!(await context.Users.ContainsAsync(user)))
            {
                context.Users.Add(user);
                await SaveAllAsync();
                return true;//"User created";
            }

            return false;//"Unable to add user, that user already exist.";
        }

        public async Task<UserDTO> GetUserAsync(string userName)
        {
            var usr = await context.Users.Include("Pets.Photos").Where(x => x.UserName == userName).FirstOrDefaultAsync();
            if (usr != null)
            {
                var newUser = mapper.Map<UserDTO>(usr);
                return newUser;
            }

            return null;//BadRequest("User not found");
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await context.Users.Include("Pets.Photos").ToListAsync();
            var newUsersList = mapper.Map<IEnumerable<UserDTO>>(users);

            return newUsersList;
        }

        public async Task<bool> SaveAllAsync()
        {
            await this.context.SaveChangesAsync();
            return true;
        }

        public Task UpdateAsync(string username, User user)
        {
            // var index = users.FindIndex(x => x.Name == userName);
            // if (index >= 0)
            // {
            //     users[index] = user;
            //     return Ok(users);
            // }

            // return BadRequest("Unable to update user");
            //return BadRequest();
            return null;
        }
    }
}