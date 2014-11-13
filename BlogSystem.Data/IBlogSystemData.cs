namespace BlogSystem.Data
{
    using BlogSystem.Data.Repositories;
    using BlogSystem.Models;
    using System.Data.Entity;

    public interface IBlogSystemData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<BlogPost> Posts { get; }

        IRepository<Category> Categories { get; }

        IRepository<Page> Pages { get; }

        DbContext Context { get; }

        int SaveChanges();

    }
}