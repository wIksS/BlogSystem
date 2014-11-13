namespace BlogSystem.Data
{
    using BlogSystem.Data.Repositories;
    using BlogSystem.Models;

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class BlogSystemData : IBlogSystemData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public BlogSystemData()
            : this(new BlogSystemDbContext())
        {
        }

        public BlogSystemData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<BlogPost> Posts
        {
            get { return this.GetRepository<BlogPost>(); }
        }

        public IRepository<Category> Categories 
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<Page> Pages
        {
            get { return this.GetRepository<Page>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
