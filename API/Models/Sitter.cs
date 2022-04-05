using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Sitter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<Pet> PetsSpecialty { get; set; }
        public int Ratings { get; set; }
        public List<Review> Reviews { get; set; }
        public int YearsOfExperience { get; set; }

        public string License { get; set; }
    }
}