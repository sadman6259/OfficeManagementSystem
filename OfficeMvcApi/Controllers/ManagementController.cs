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
    public class ManagementController : Controller
    {
        private OfficeDbEntities db = new OfficeDbEntities();

        // GET: /Management/
        public ActionResult Index()
        {
          //  return View(emp);
            var managements = db.Managements.Include(m => m.Additional).Include(m => m.Bill).Include(m => m.Clark).Include(m => m.Employee);
            return View(managements.ToList());
        }

        // GET: /Management/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Managements.Find(id);
            if (management == null)
            {
                return HttpNotFound();
            }
            return View(management);
        }

        // GET: /Management/Create
        public ActionResult Create()
        {
            ViewBag.AdditionalId = new SelectList(db.Additionals, "Id", "Month");
            ViewBag.BillId = new SelectList(db.Bills, "Id", "Month");
            ViewBag.ClarkId = new SelectList(db.Clarks, "Id", "TotalSalary");
            ViewBag.EmpId = new SelectList(db.Employees, "Id", "TotalSalary");
            return View();
        }

        // POST: /Management/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,SponsoredAmount,SellingAmount,EmpId,ClarkId,BillId,AdditionalId,Profit")] Management management )
        {

            if (ModelState.IsValid)
            {
                db.Managements.Add(management);
                db.SaveChanges();
          //      var profit = Convert.ToInt32(management.Employee.TotalSalary - management.Clark.TotalSalary - management.Bill.TotalBills - management.Additional.TotalAdditional);
          //      management.Profit = profit;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.AdditionalId = new SelectList(db.Additionals, "Id", "Month", management.Additional.TotalAdditional);
            ViewBag.BillId = new SelectList(db.Bills, "Id", "Month", management.Bill.TotalBills);
            ViewBag.ClarkId = new SelectList(db.Clarks, "Id", "TotalSalary", management.Clark.TotalSalary);
            ViewBag.EmpId = new SelectList(db.Employees, "Id", "TotalSalary", management.Employee.TotalSalary);
            return View(management);
        }

        // GET: /Management/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Managements.Find(id);
            if (management == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdditionalId = new SelectList(db.Additionals, "Id", "Month", management.AdditionalId);
            ViewBag.BillId = new SelectList(db.Bills, "Id", "Month", management.BillId);
            ViewBag.ClarkId = new SelectList(db.Clarks, "Id", "Name", management.ClarkId);
            ViewBag.EmpId = new SelectList(db.Employees, "Id", "Name", management.EmpId);
            return View(management);
        }

        // POST: /Management/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,SponsoredAmount,SellingAmount,EmpId,ClarkId,BillId,AdditionalId,Profit")] Management management)
        {
            if (ModelState.IsValid)
            {
                db.Entry(management).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdditionalId = new SelectList(db.Additionals, "Id", "Month", management.AdditionalId);
            ViewBag.BillId = new SelectList(db.Bills, "Id", "Month", management.BillId);
            ViewBag.ClarkId = new SelectList(db.Clarks, "Id", "Name", management.ClarkId);
            ViewBag.EmpId = new SelectList(db.Employees, "Id", "Name", management.EmpId);
            return View(management);
        }

        // GET: /Management/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Management management = db.Managements.Find(id);
            if (management == null)
            {
                return HttpNotFound();
            }
            return View(management);
        }

        // POST: /Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Management management = db.Managements.Find(id);
            db.Managements.Remove(management);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Input()
        {
           // Management man = new Management();
            return View("Input");
        }
        [HttpPost]
        public ActionResult Input(int id)
        {

            return View("Index");
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
