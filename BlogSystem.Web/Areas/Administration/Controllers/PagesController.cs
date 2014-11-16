

namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using BlogSystem.Models;
    using System.Collections;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Model = BlogSystem.Models.Page;
    using ViewModel = BlogSystem.Web.Areas.Administration.ViewModels.PageViewModel;
    using Kendo.Mvc.UI;
    using BlogSystem.Data;
    using System.Web.Mvc;
    using System.Linq;

    public class PagesController : KendoGridAdministrationController
    {
        public PagesController(IBlogSystemData data)
            : base(data)
        {
        }

        // GET: Administration/Pages
        public ActionResult Index()
        {
            return View();
        }

        protected override IEnumerable GetData()
        {
            return this.Data
                .Pages
                .All()
                .Where(p => p.ApplicationUser.UserName == User.Identity.Name)
                .Project()
                .To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Pages.Find(id) as T;
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
            var page = Mapper.Map<Page>(model);
            page.ApplicationUser = Data.Users.All().First(u => u.UserName == User.Identity.Name);
            this.Data.Pages.Add(page);
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
                var page = this.Data.Pages.Find(model.Id.Value);

                this.Data.SaveChanges();

                this.Data.Pages.Delete(page);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }
        // GET: Administration/Pages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,Content")] Page page)
        {
            if (ModelState.IsValid)
            {
                page.ApplicationUser = Data.Users.All().First(u => u.UserName == User.Identity.Name);
                Data.Pages.Add(page);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(page);
        }
    }
}
