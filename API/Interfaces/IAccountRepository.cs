using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountDTO> RegisterAsync(RegistrationDTO registration);
        Task<AccountDTO> LoginAsync(LoginDTO loginUser);
    }
}