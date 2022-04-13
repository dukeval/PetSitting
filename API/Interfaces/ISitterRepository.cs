using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Models;

namespace API.Interfaces
{
    public interface ISitterRepository
    {
        Task<IEnumerable<SitterDTO>> GetSittersAsync();
        Task<SitterDTO> GetSitterAsync(string userName);
        Task<SitterDTO> CreateSitterAsync(Sitter sitter);
    }
}