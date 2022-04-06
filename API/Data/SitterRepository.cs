using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SitterRepository : ISitterRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public SitterRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<SitterDTO> GetSitterAsync(string userName)
        {
            var sitters = await this.context.Sitters.Where(x => x.UserName == userName).Include(pet => pet.PetsSpecialty).FirstOrDefaultAsync();
            if (sitters != null)
            {
                var sitter = this.mapper.Map<SitterDTO>(sitters);
                return sitter;
            }

            return null;
        }

        public async Task<IEnumerable<SitterDTO>> GetSittersAsync()
        {
            var sitters = await this.context.Sitters.Include(pet => pet.PetsSpecialty).ToListAsync();
            var listOfSitters = this.mapper.Map<IEnumerable<SitterDTO>>(sitters);

            return listOfSitters;
        }
    }
}