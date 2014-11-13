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
    public class PagesController : AdministrationController
    {
        public PagesController(IBlogSystemData data)
            : base(data)
        {
        }

        // GET: Administration/Pages
        public ActionResult Index()
        {
            return View(Data.Pages.All().ToList());
        }

        // GET: Administration/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = Data.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
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
        public ActionResult Create([Bind(Include = "Id,Title,Content")] Page page)
        {
            if (ModelState.IsValid)
            {
                Data.Pages.Add(page);
                Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(page);
        }

        // GET: Administration/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = Data.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Administration/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content")] Page page)
        {
            if (ModelState.IsValid)
            {
                Data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(page);
        }

        // GET: Administration/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = Data.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Administration/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = Data.Pages.Find(id);
            Data.Pages.Delete(page);
            Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
