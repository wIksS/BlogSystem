using BlogSystem.Data;
using BlogSystem.Web.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace BlogSystem.Web.Controllers
{
    public class PostsController : BaseController
    {
        public PostsController(IBlogSystemData data)
            :base(data)
        { }

        // GET: BlogPosts
        public ActionResult Index(string user)
        {
            var posts = this.Data.Posts.All()
                                .Where(p => p.ApplicationUser.UserName == user)
                                .Project()
                                .To<BlogPostViewModel>()
                                .ToList();
            ViewBag.User = user;
            return View(posts);
        }
    }
}