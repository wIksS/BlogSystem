namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using BlogSystem.Models;
    using System.Collections;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Model = BlogSystem.Models.BlogPost;
    using ViewModel = BlogSystem.Web.Areas.Administration.ViewModels.BlogPostViewModel;
    using Kendo.Mvc.UI;
    using BlogSystem.Data;
    using System.Web.Mvc;
    using System.Linq;
    using System;

    public class BlogPostsController : KendoGridAdministrationController
    {
        public BlogPostsController(IBlogSystemData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data
                .Posts
                .All()
                .Where(p => p.ApplicationUser.UserName == User.Identity.Name)
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Posts.Find(id) as T;
        }

        //[HttpPost]
        //public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        //{
        //    var dbModel = base.Create<Model>(model);
        //    if (dbModel != null) model.Id = dbModel.Id;

        //    return this.GridOperation(model, request);
        //}

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            //var dbModel = base.Create<Model>(model);
            //if (dbModel != null) model.Id = dbModel.Id;
            var post = Mapper.Map<BlogPost>(model);
            post.ApplicationUser = Data.Users.All().First(u => u.UserName == User.Identity.Name);
            this.Data.Posts.Add(post);
            this.Data.SaveChanges();
            return this.GridOperation(model, request);
            //base.Update<Model, ViewModel>(model, model.Id);

            //return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var page = this.Data.Posts.Find(model.Id.Value);

                this.Data.SaveChanges();

                this.Data.Pages.Delete(page);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(Data.Categories.All(), "Id", "Title");

            return View();
        }

        // POST: Administration/BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,CategoryId,ApplicationUserId")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.DateCreated = DateTime.Now;
                blogPost.ApplicationUser = Data.Users.All().First(u => u.UserName == User.Identity.Name);
                Data.Posts.Add(blogPost);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(Data.Categories.All(), "Id", "Title", blogPost.CategoryId);
            return View(blogPost);
        }
    }

}
