using System;
using System.Collections.Generic;

namespace PetSitting.Models
{
    public class UserCredential
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Profile { get; set; }
    }
}