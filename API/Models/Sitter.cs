using System;
using System.Collections.Generic;

namespace PetSitting.Models
{
    public class Sitter : User
    {
        public int YearsOfExperience { get; set; }
        public string License { get; set; }
        public List<string> PetsSpecialty { get; set; }
    }
}