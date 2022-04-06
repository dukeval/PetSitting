using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext context;
        private readonly ITokenService tokenService;

        public AccountRepository(DataContext context, ITokenService tokenService)
        {
            this.context = context;
            this.tokenService = tokenService;
        }

        public async Task<AccountDTO> LoginAsync(LoginDTO loginUser)
        {
            var user = await this.context.Accounts.SingleOrDefaultAsync(x => x.UserName == loginUser.Username);

            if (user == null) return null;

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != user.PasswordHash[i]) return null;
            }

            return new AccountDTO
            {
                UserName = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }

        public async Task<AccountDTO> RegisterAsync(RegistrationDTO registration)
        {
            if (await UserExist(registration.Username))
                return null;//BadRequest("Username exist.");

            if (await EmailExist(registration.Email))
                return null;//BadRequest("Email address exist.");

            using var hmac = new HMACSHA512();

            var newAccount = new AppUser
            {
                UserName = registration.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registration.Password)),
                PasswordSalt = hmac.Key,
                LastActive = DateTime.Now,
                Email = registration.Email
            };

            this.context.Accounts.Add(newAccount);
            await this.context.SaveChangesAsync();

            return new AccountDTO { UserName = registration.Username, Token = tokenService.CreateToken(newAccount) };
        }

        private async Task<bool> EmailExist(string email)
        {
            return await this.context.Accounts.AnyAsync(x => x.Email.ToLower() == email.ToLower());
        }

        private async Task<bool> UserExist(string username)
        {
            return await this.context.Accounts.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }
    }
}