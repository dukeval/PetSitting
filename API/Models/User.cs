using System;
using System.Collections.Generic;

namespace PetSitting.Models
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<string> Pets { get; set; }
    }
}