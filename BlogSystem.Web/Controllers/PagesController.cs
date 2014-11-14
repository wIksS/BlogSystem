using BlogSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogSystem.Web.ViewModels;
using BlogSystem.Web.ViewModels.Page;

namespace BlogSystem.Web.Controllers
{
    public class PagesController : BaseController
    {
        public PagesController(IBlogSystemData data)
            :base(data)
        { }

        // GET: Pages
        public ActionResult Index(string pageTitle)
        {
            var page = this.Data.Pages.All().FirstOrDefault(p => p.Title == pageTitle);
            if(page != null)
            {
                var pageViewModel = Mapper.Map<PageViewModel>(page);
                return View(pageViewModel);
            }

            return HttpNotFound();
        }

        public ActionResult ListPages(string user)
        {
            var pages = this.Data.Pages.All().Project().To<NavigationElement>().ToList();
            ViewBag.User = user;

            return PartialView("_ListPages", pages);
        }
    }
}