using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSystem.Models
{
    public class Category
    {
        private ICollection<BlogPost> posts;

        public Category()
        {
            this.BlogPosts = new HashSet<BlogPost>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<BlogPost> BlogPosts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
