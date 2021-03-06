﻿using System;
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
    public class RecipientsController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        // GET: Recipients
        public ActionResult Index()
        {
            var userQuery = from s in db.ShippingAccounts select new { s.ShippingAccountID, s.UserName };
            string username = User.Identity.GetUserName();
            userQuery = userQuery.Where(s => s.UserName == username);
            int account = userQuery.ToList()[0].ShippingAccountID;

            var recipients = db.Recipients.Where(r => r.ShippingAccountID == account);
            return View(recipients.ToList());
        }

        // GET: Recipients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipient recipient = db.Recipients.Find(id);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(recipient);
        }

        // GET: Recipients/Create
        public ActionResult Create()
        {
            ViewBag.ShippingAccountID = new SelectList(db.ShippingAccounts, "ShippingAccountID", "UserName");
            return View();
        }

        // POST: Recipients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipientID,ShippingAccountID,Nickname,Building,Street,City,Province,PostalCode")] Recipient recipient)
        {
            if (ModelState.IsValid)
            {
                var userQuery = from s in db.ShippingAccounts select new { s.ShippingAccountID, s.UserName };
                string username = User.Identity.GetUserName();
                userQuery = userQuery.Where(s => s.UserName == username);
                int account = userQuery.ToList()[0].ShippingAccountID;

                recipient.ShippingAccountID = account;
                db.Recipients.Add(recipient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShippingAccountID = new SelectList(db.ShippingAccounts, "ShippingAccountID", "UserName", recipient.ShippingAccountID);
            return View(recipient);
        }

        // GET: Recipients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipient recipient = db.Recipients.Find(id);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShippingAccountID = new SelectList(db.ShippingAccounts, "ShippingAccountID", "UserName", recipient.ShippingAccountID);
            return View(recipient);
        }

        // POST: Recipients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipientID,ShippingAccountID,Nickname,Building,Street,City,Province,PostalCode")] Recipient recipient)
        {
            if (ModelState.IsValid)
            {
                var userQuery = from s in db.ShippingAccounts select new { s.ShippingAccountID, s.UserName };
                string username = User.Identity.GetUserName();
                userQuery = userQuery.Where(s => s.UserName == username);
                int account = userQuery.ToList()[0].ShippingAccountID;

                recipient.ShippingAccountID = account;
                db.Entry(recipient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShippingAccountID = new SelectList(db.ShippingAccounts, "ShippingAccountID", "UserName", recipient.ShippingAccountID);
            return View(recipient);
        }

        // GET: Recipients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipient recipient = db.Recipients.Find(id);
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(recipient);
        }

        // POST: Recipients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipient recipient = db.Recipients.Find(id);
            db.Recipients.Remove(recipient);
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
