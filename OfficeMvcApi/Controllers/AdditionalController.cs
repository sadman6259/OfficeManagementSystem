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
    public class AdditionalController : Controller
    {
        private OfficeDbEntities db = new OfficeDbEntities();

        // GET: /Additional/
        public ActionResult Index()
        {
            return View(db.Additionals.ToList());
        }

        // GET: /Additional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional additional = db.Additionals.Find(id);
            if (additional == null)
            {
                return HttpNotFound();
            }
            return View(additional);
        }

        // GET: /Additional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Additional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,RentSpace,Equipments,Month,TotalAdditional")] Additional additional)
        {
         //   additional.TotalAdditional = additional.RentSpace + additional.Equipments;
            if (ModelState.IsValid)
            {
                db.Additionals.Add(additional);
                db.SaveChanges();
                additional.TotalAdditional = additional.RentSpace + additional.Equipments;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(additional);
        }

        // GET: /Additional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional additional = db.Additionals.Find(id);
            if (additional == null)
            {
                return HttpNotFound();
            }
            return View(additional);
        }

        // POST: /Additional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,RentSpace,Equipments,Month,TotalAdditional")] Additional additional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(additional);
        }

        // GET: /Additional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additional additional = db.Additionals.Find(id);
            if (additional == null)
            {
                return HttpNotFound();
            }
            return View(additional);
        }

        // POST: /Additional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Additional additional = db.Additionals.Find(id);
            db.Additionals.Remove(additional);
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
