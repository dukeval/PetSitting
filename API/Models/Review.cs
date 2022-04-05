using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerAlias { get; set; }
        public string ReviewNotes { get; set; }
        public int Rating { get; set; }

    }
}