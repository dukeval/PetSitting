using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Sitter : User
    {
        public int YearsOfExperience { get; set; }
        public string License { get; set; }
        public List<string> PetsSpecialty { get; set; }
    }
}