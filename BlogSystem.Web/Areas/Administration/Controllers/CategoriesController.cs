using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogSystem.Data;


namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using BlogSystem.Models;
    using System.Collections;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Model = BlogSystem.Models.Category;
    using ViewModel = BlogSystem.Web.Areas.Administration.ViewModels.CategoryViewModel;
    using Kendo.Mvc.UI;

    public class CategoriesController : KendoGridAdministrationController
    {
        public CategoriesController(IBlogSystemData data)
            : base(data)
        { }
        // GET: Administration/Categories
        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data
                .Categories
                .All()
                 .Where(p => p.ApplicationUser.UserName == User.Identity.Name)
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Categories.Find(id) as T;
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dbModel = base.Create<Model>(model);
            if (dbModel != null) model.Id = dbModel.Id;

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            //var dbModel = base.Create<Model>(model);
            //if (dbModel != null) model.Id = dbModel.Id;
            var category = Mapper.Map<Category>(model);
            category.ApplicationUser = Data.Users.All().First(u => u.UserName == User.Identity.Name);
            this.Data.Categories.Add(category);
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
                var category = this.Data.Categories.Find(model.Id.Value);

                this.Data.SaveChanges();

                this.Data.Categories.Delete(category);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
    }
}
