using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinExWebApp20444290.Models;
using Microsoft.AspNet.Identity;

namespace SinExWebApp20444290.Controllers
{
    public class BusinessShippingAccountsController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        public ActionResult Index()
        {
            var userQuery = from s in db.ShippingAccounts select new { s.ShippingAccountID, s.UserName };
            string username = User.Identity.GetUserName();
            userQuery = userQuery.Where(s => s.UserName == username);
            int account = userQuery.ToList()[0].ShippingAccountID;
            BusinessShippingAccount shippingAccount = (BusinessShippingAccount)db.ShippingAccounts.Find(account);
            return View(shippingAccount);
        }

        // GET: BusinessShippingAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessShippingAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingAccountID,Building,Street,City,Province,PostalCode,PhoneNumber,Email,ContactPersonName,CompanyName,DepartmentName")] BusinessShippingAccount businessShippingAccount)
        {
            if (ModelState.IsValid)
            {
                //db.ShippingAccounts.Add(businessShippingAccount);
                //db.SaveChanges();
                return RedirectToAction("Home");
            }

            return View(businessShippingAccount);
        }

        // GET: BusinessShippingAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessShippingAccount businessShippingAccount = (BusinessShippingAccount) db.ShippingAccounts.Find(id);
            if (businessShippingAccount == null)
            {
                return HttpNotFound();
            }
            return View(businessShippingAccount);
        }

        // POST: BusinessShippingAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ccType,ccNumber,ccSecurityNumber,ccHolderName,ccExpirationMonth,ccExpirationYear,ShippingAccountID,Building,Street,City,Province,PostalCode,PhoneNumber,Email,ContactPersonName,CompanyName,DepartmentName")] BusinessShippingAccount businessShippingAccount)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(businessShippingAccount).State = EntityState.Modified;
                //db.SaveChanges();

                var ent = (BusinessShippingAccount)db.ShippingAccounts.Find(businessShippingAccount.ShippingAccountID);
                ent.CompanyName = businessShippingAccount.CompanyName;
                ent.DepartmentName = businessShippingAccount.DepartmentName;
                ent.ContactPersonName = businessShippingAccount.ContactPersonName;
                ent.PhoneNumber = businessShippingAccount.PhoneNumber;
                ent.Email = businessShippingAccount.Email;
                ent.Building = businessShippingAccount.Building;
                ent.Street = businessShippingAccount.Street;
                ent.City = businessShippingAccount.City;
                ent.Province = businessShippingAccount.Province;
                ent.PostalCode = businessShippingAccount.PostalCode;
                ent.ccType = businessShippingAccount.ccType;
                ent.ccNumber = businessShippingAccount.ccNumber;
                ent.ccSecurityNumber = businessShippingAccount.ccSecurityNumber;
                ent.ccHolderName = businessShippingAccount.ccHolderName;
                ent.ccExpirationMonth = businessShippingAccount.ccExpirationMonth;
                ent.ccExpirationYear = businessShippingAccount.ccExpirationYear;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(businessShippingAccount);
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
