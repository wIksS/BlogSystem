using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogSystem.Data;
using BlogSystem.Models;

namespace BlogSystem.Web.Areas.Administration.Controllers
{
    public class BlogPostsController : AdministrationController
    {
        public BlogPostsController(IBlogSystemData data)
            :base(data)
        { }

        // GET: Administration/BlogPosts
        public ActionResult Index()
        {
            var blogPosts = Data.Posts.All().ToList();
            return View(blogPosts);
        }

        // GET: Administration/BlogPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = Data.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: Administration/BlogPosts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(Data.Categories.All(), "Id", "Title");
            return View();
        }

        // POST: Administration/BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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

        // GET: Administration/BlogPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = Data.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(Data.Categories.All(), "Id", "Title", blogPost.CategoryId);
            return View(blogPost);
        }

        // POST: Administration/BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,CategoryId,ApplicationUserId")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                Data.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(Data.Categories.All(), "Id", "Title", blogPost.CategoryId);
            return View(blogPost);
        }

        // GET: Administration/BlogPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = Data.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: Administration/BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = Data.Posts.Find(id);
            Data.Posts.Delete(blogPost);
            Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
