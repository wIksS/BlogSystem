using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int ApplicationUserId { get; set; }
    }
}
