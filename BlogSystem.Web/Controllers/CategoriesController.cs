using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogSystem.Data;
using BlogSystem.Web.ViewModels;

namespace BlogSystem.Web.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IBlogSystemData data)
            :base(data)
        { }

        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListCategories(string user)
        {
            var categories = this.Data.Categories.All().Project().To<NavigationElement>().ToList();
            ViewBag.Title = "Categories";
            ViewBag.User = user;
            return PartialView("_ListSidebar",categories);
        }
    }
}