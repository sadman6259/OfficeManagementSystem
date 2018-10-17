using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OfficeMvcApi;

namespace OfficeMvcApi.Controllers
{
    public class ClarkController : Controller
    {
        private OfficeDbEntities db = new OfficeDbEntities();

        // GET: /Clark/
        public ActionResult Index()
        {
            return View(db.Clarks.ToList());
        }

        // GET: /Clark/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clark clark = db.Clarks.Find(id);
            if (clark == null)
            {
                return HttpNotFound();
            }
            return View(clark);
        }

        // GET: /Clark/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Clark/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Salary,Position,TotalSalary")] Clark clark)
        {
       //   var sum = db.Clarks.Sum(i => i.Salary);
       //    clark.TotalSalary = sum;
            if (ModelState.IsValid)
            {
                db.Clarks.Add(clark);
                db.SaveChanges();

                var sum = db.Clarks.Sum(i => i.Salary);
                clark.TotalSalary = sum;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clark);
        }

        // GET: /Clark/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clark clark = db.Clarks.Find(id);
            if (clark == null)
            {
                return HttpNotFound();
            }
            return View(clark);
        }

        // POST: /Clark/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Salary,Position,TotalSalary")] Clark clark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clark);
        }

        // GET: /Clark/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clark clark = db.Clarks.Find(id);
            if (clark == null)
            {
                return HttpNotFound();
            }
            return View(clark);
        }

        // POST: /Clark/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clark clark = db.Clarks.Find(id);
            db.Clarks.Remove(clark);
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
