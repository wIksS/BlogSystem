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
    public class CategoriesController : AdministrationController
    {
        public CategoriesController(IBlogSystemData data)
            :base(data)
        { }
        // GET: Administration/Categories
        public ActionResult Index()
        {
            return View(Data.Categories.All().ToList());
        }

        // GET: Administration/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Data.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Administration/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administration/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.ApplicationUser = Data.Users.All().First(u => u.UserName == User.Identity.Name);
                Data.Categories.Add(category);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Administration/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Data.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] Category category)
        {
            if (ModelState.IsValid)
            {
                Data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Administration/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Data.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = Data.Categories.Find(id);
            Data.Categories.Delete(category);
            Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
