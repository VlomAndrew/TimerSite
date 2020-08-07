using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms.VisualStyles;
using FirstProject.Data;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    public class BossViewModelsController : Controller
    {
        private BossContext db = new BossContext();

        // GET: BossViewModels
        public ActionResult Index()
        {
            return View(db.BossViewModels.ToList());
        }

        // GET: BossViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BossViewModel bossViewModel = db.BossViewModels.Find(id);
            if (bossViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bossViewModel);
        }

        // GET: BossViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BossViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,KdCount,KdTime")] BossViewModel bossViewModel)
        {
            if (ModelState.IsValid)
            {
                bossViewModel.LastTime = DateTime.Now;
                db.BossViewModels.Add(bossViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bossViewModel);
        }

        // GET: BossViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BossViewModel bossViewModel = db.BossViewModels.Find(id);
            if (bossViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bossViewModel);
        }

        // POST: BossViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,KdCount,KdTime")] BossViewModel bossViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bossViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bossViewModel);
        }

        // GET: BossViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BossViewModel bossViewModel = db.BossViewModels.Find(id);
            if (bossViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bossViewModel);
        }

        // POST: BossViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BossViewModel bossViewModel = db.BossViewModels.Find(id);
            db.BossViewModels.Remove(bossViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
