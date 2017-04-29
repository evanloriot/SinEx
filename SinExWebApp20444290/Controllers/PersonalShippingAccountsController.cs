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
    public class PersonalShippingAccountsController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        public ActionResult Index()
        {
            var userQuery = from s in db.ShippingAccounts select new { s.ShippingAccountID, s.UserName };
            string username = User.Identity.GetUserName();
            userQuery = userQuery.Where(s => s.UserName == username);
            int account = userQuery.ToList()[0].ShippingAccountID;
            PersonalShippingAccount shippingAccount = (PersonalShippingAccount)db.ShippingAccounts.Find(account);
            return View(shippingAccount);
        }

        // GET: PersonalShippingAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalShippingAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingAccountID,Building,Street,City,Province,PostalCode,PhoneNumber,Email,FirstName,LastName")] PersonalShippingAccount personalShippingAccount)
        {
            if (ModelState.IsValid)
            {
                //db.ShippingAccounts.Add(personalShippingAccount);
                //db.SaveChanges();
                return RedirectToAction("Home");
            }

            return View(personalShippingAccount);
        }

        // GET: PersonalShippingAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalShippingAccount personalShippingAccount = (PersonalShippingAccount) db.ShippingAccounts.Find(id);
            if (personalShippingAccount == null)
            {
                return HttpNotFound();
            }
            return View(personalShippingAccount);
        }

        // POST: PersonalShippingAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingAccountID,FirstName,LastName,PhoneNumber,Email,Building,Street,City,Province,PostalCode,ccType,ccNumber,ccSecurityNumber,ccHolderName,ccExpirationMonth,ccExpirationYear")] PersonalShippingAccount personalShippingAccount)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(personalShippingAccount).State = EntityState.Modified;
                //db.SaveChanges();

                var ent = (PersonalShippingAccount) db.ShippingAccounts.Find(personalShippingAccount.ShippingAccountID);
                ent.FirstName = personalShippingAccount.FirstName;
                ent.LastName = personalShippingAccount.LastName;
                ent.PhoneNumber = personalShippingAccount.PhoneNumber;
                ent.Email = personalShippingAccount.Email;
                ent.Building = personalShippingAccount.Building;
                ent.Street = personalShippingAccount.Street;
                ent.City = personalShippingAccount.City;
                ent.Province = personalShippingAccount.Province;
                ent.PostalCode = personalShippingAccount.PostalCode;
                ent.ccType = personalShippingAccount.ccType;
                ent.ccNumber = personalShippingAccount.ccNumber;
                ent.ccSecurityNumber = personalShippingAccount.ccSecurityNumber;
                ent.ccHolderName = personalShippingAccount.ccHolderName;
                ent.ccExpirationMonth = personalShippingAccount.ccExpirationMonth;
                ent.ccExpirationYear = personalShippingAccount.ccExpirationYear;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(personalShippingAccount);
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
