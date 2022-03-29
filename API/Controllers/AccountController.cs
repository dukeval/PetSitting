using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetSitting.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly ITokenService tokenService;

        public AccountController(DataContext dataContext, ITokenService tokenService)
        {
            this.dataContext = dataContext;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AccountDTO>> Register(RegistrationDTO registration)
        {
            if (await UserExist(registration.Username))
                return BadRequest("Username exist.");

            if (await EmailExist(registration.Email))
                return BadRequest("Email address exist.");

            using var hmac = new HMACSHA512();

            var newAccount = new AppUser
            {
                UserName = registration.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registration.Password)),
                PasswordSalt = hmac.Key,
                LastActive = DateTime.Now,
                Email = registration.Email
            };

            dataContext.Accounts.Add(newAccount);
            await dataContext.SaveChangesAsync();

            return new AccountDTO { UserName = registration.Username, Token = tokenService.CreateToken(newAccount) };
        }

        [HttpPost("login")]
        public async Task<ActionResult<AccountDTO>> Login(LoginDTO loginUser)
        {
            var user = await dataContext.Accounts.SingleOrDefaultAsync(x => x.UserName == loginUser.Username);

            if (user == null) return Unauthorized("Invalid account");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new AccountDTO
            {
                UserName = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }

        private async Task<bool> EmailExist(string email)
        {
            return await dataContext.Accounts.AnyAsync(x => x.Email.ToLower() == email.ToLower());
        }

        private async Task<bool> UserExist(string username)
        {
            return await dataContext.Accounts.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }
    }
}