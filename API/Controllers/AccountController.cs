using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using API.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly DataContext dataContext;
        private readonly ITokenService tokenService;

        public AccountController(IAccountRepository accountRepository, DataContext dataContext, ITokenService tokenService)
        {
            this.accountRepository = accountRepository;
            this.dataContext = dataContext;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AccountDTO>> Register(RegistrationDTO registration)
        {
            var register = await this.accountRepository.RegisterAsync(registration);
            if (register != null)
                return Ok(register);

            return BadRequest("Invalid email or username.");
        }

        [HttpPost("login")]
        public async Task<ActionResult<AccountDTO>> Login(LoginDTO loginUser)
        {
            var act = await this.accountRepository.LoginAsync(loginUser);
            if (act != null)
                return (Ok(act));

            return Unauthorized("Invalid Login Info.");
        }
    }
}