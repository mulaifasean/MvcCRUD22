using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCRUD22.Models;

namespace MvcCRUD22.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            using (TestEntities db = new TestEntities())
            {
                return View(db.Customers.ToList());

            }
                
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            using (TestEntities db = new TestEntities())
            {
                 return View(db.Customers.Where(x => x.Id ==id).FirstOrDefault());
            }
                
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer cust)
        {
            try
            {
                // TODO: Add insert logic here
                using (TestEntities db = new TestEntities())
                {
                    db.Customers.Add(cust);
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            using (TestEntities db = new TestEntities())
            {
                return View(db.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer cust)
        {
            try
            {
                // TODO: Add update logic here
                using (TestEntities db = new TestEntities())
                {
                    db.Entry(cust).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            using (TestEntities db = new TestEntities())
            {
                return View(db.Customers.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using(TestEntities db = new TestEntities())
                {
                    Customer cust = db.Customers.Where(x => x.Id == id).FirstOrDefault();
                    db.Customers.Remove(cust);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
