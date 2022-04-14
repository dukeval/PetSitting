using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Pets")]
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public User Owner { get; set; }
        public int UserId { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}