using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomInfo.DAL;
using CustomInfo.Models;
using PagedList;
using PagedList.Mvc;
using DataTables.Mvc;

namespace CustomInfo.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerContext db = new CustomerContext();

        // GET: Customers
        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.Customers.OrderByDescending(x => x.CustomerName).ToPagedList(pageNumber, pageSize));
        }
        //public ActionResult Index(int? page)
        //{
        //    //List<Customer> myList = _service.GetSomeData(id);
        //    const int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //IQueryable<Customer> query = DbContext.Customers;
        //var totalCount = query.Count();

        //query = query.Skip(requestModel.Start).Take(requestModel.Length);


        //var data = query.Select(customer => new
        //{
        //   CustomerName=customer.CustomerName,
        //    City=customer.City,
        //}).ToList();
        //return Json(new DataTablesResponse(requestModel.Draw, data, totalCount), JsonRequestBehavior.AllowGet);

        //myList = myList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //var jsonData = new
        //{
        //    total = totalPages,
        //    records = domainList.Count,
        //    page,

        //    rows = myList
        //};
        // return Json(db.Customers.OrderByDescending(x => x.CustomerName).ToPagedList(pageNumber, pageSize),JsonRequestBehavior.AllowGet);
        //return Json(db.Customers.OrderByDescending(x => x.CustomerName).ToPagedList(pageNumber, pageSize));

    


        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CustomerName,City")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CustomerName,City")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
