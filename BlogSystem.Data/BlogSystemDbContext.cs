using Microsoft.AspNet.Identity.EntityFramework;
using BlogSystem.Models;
using BlogSystem.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data
{
    public class BlogSystemDbContext : IdentityDbContext
    {
        public BlogSystemDbContext()
            : base("BlogSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogSystemDbContext, Configuration>());
        }

        public IDbSet<BlogPost> BlogPosts { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Page> Pages { get; set; }

       // public IDbSet<ApplicationUser> Users { get; set; }
    }
}
