using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Models;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task UpdateAsync(string username, User user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserAsync(string username);
        Task<bool> CreateUserAsync(User user);

    }
}