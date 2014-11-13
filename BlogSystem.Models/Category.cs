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
            this.Posts = new HashSet<BlogPost>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<BlogPost> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
