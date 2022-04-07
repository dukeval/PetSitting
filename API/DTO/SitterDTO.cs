using System;
using System.Collections.Generic;

namespace API.DTO
{
    public class SitterDTO
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Bio { get; set; }
        public string Picture { get; set; }
        public int Ratings { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; }
        public int YearsOfExperience { get; set; }
        public string License { get; set; }
        public ICollection<PetDTO> PetsSpecialty { get; set; }
        public DateTime LastActive { get; set; }
    }
}
