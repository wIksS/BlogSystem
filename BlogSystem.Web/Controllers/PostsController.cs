using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class PostsController : Controller
    {
        // GET: BlogPosts
        public ActionResult Index()
        {
            return View();
        }
    }
}