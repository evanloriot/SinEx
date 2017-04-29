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
    public class PickupLocationsController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        // GET: PickupLocations
        public ActionResult Index()
        {
            var userQuery = from s in db.ShippingAccounts select new { s.ShippingAccountID, s.UserName };
            string username = User.Identity.GetUserName();
            userQuery = userQuery.Where(s => s.UserName == username);
            int account = userQuery.ToList()[0].ShippingAccountID;

            var pickupLocations = db.PickupLocations.Where(p => p.ShippingAccountID == account);
            return View(pickupLocations.ToList());
        }

        // GET: PickupLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupLocation pickupLocation = db.PickupLocations.Find(id);
            if (pickupLocation == null)
            {
                return HttpNotFound();
            }
            return View(pickupLocation);
        }

        // GET: PickupLocations/Create
        public ActionResult Create()
        {
            ViewBag.ShippingAccountID = new SelectList(db.ShippingAccounts, "ShippingAccountID", "UserName");
            return View();
        }

        // POST: PickupLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PickupLocationID,ShippingAccountID,Nickname,Building,Street,City,Province,PostalCode")] PickupLocation pickupLocation)
        {
            if (ModelState.IsValid)
            {
                var userQuery = from s in db.ShippingAccounts select new { s.ShippingAccountID, s.UserName };
                string username = User.Identity.GetUserName();
                userQuery = userQuery.Where(s => s.UserName == username);
                int account = userQuery.ToList()[0].ShippingAccountID;

                pickupLocation.ShippingAccountID = account;
                db.PickupLocations.Add(pickupLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShippingAccountID = new SelectList(db.ShippingAccounts, "ShippingAccountID", "UserName", pickupLocation.ShippingAccountID);
            return View(pickupLocation);
        }

        // GET: PickupLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupLocation pickupLocation = db.PickupLocations.Find(id);
            if (pickupLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShippingAccountID = new SelectList(db.ShippingAccounts, "ShippingAccountID", "UserName", pickupLocation.ShippingAccountID);
            return View(pickupLocation);
        }

        // POST: PickupLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PickupLocationID,ShippingAccountID,Nickname,Building,Street,City,Province,PostalCode")] PickupLocation pickupLocation)
        {
            if (ModelState.IsValid)
            {
                var userQuery = from s in db.ShippingAccounts select new { s.ShippingAccountID, s.UserName };
                string username = User.Identity.GetUserName();
                userQuery = userQuery.Where(s => s.UserName == username);
                int account = userQuery.ToList()[0].ShippingAccountID;

                pickupLocation.ShippingAccountID = account;
                db.Entry(pickupLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShippingAccountID = new SelectList(db.ShippingAccounts, "ShippingAccountID", "UserName", pickupLocation.ShippingAccountID);
            return View(pickupLocation);
        }

        // GET: PickupLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickupLocation pickupLocation = db.PickupLocations.Find(id);
            if (pickupLocation == null)
            {
                return HttpNotFound();
            }
            return View(pickupLocation);
        }

        // POST: PickupLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickupLocation pickupLocation = db.PickupLocations.Find(id);
            db.PickupLocations.Remove(pickupLocation);
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
