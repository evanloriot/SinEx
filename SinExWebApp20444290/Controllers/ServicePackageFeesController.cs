using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinExWebApp20444290.Models;

namespace SinExWebApp20444290.Controllers
{
    public class ServicePackageFeesController : BaseController
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        // GET: ServicePackageFees
        public ActionResult Index(string CurrencyType = "CNY")
        {
            var servicePackageFees = db.ServicePackageFees.Include(s => s.PackageType).Include(s => s.ServiceType);
            foreach(var item in servicePackageFees)
            {
                item.MinimumFee = convert(CurrencyType, item.MinimumFee);
                item.Fee = convert(CurrencyType, item.Fee);
            }
            return View(servicePackageFees.ToList());
        }

        // GET: ServicePackageFees/EstimateCost
        public ActionResult EstimateCost(string Origin, string Destination, string ServiceType, string PackageType, string Weight, string currency = "1.00")
        {
            double cost = 0;
            double weight;
            bool isOverWeight = false;
            if (Double.TryParse(Weight, out weight))
            {
                weight = Convert.ToDouble(Weight);
                switch (ServiceType)
                {
                    case "1":
                        switch (PackageType)
                        {
                            case "1":
                                cost = 160;
                                break;
                            case "2":
                                if (weight <= 1.6)
                                {
                                    cost = 160;
                                }
                                else
                                {
                                    cost = weight * 100;
                                }
                                if (weight > 5)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "3":
                                if (weight <= 1.6)
                                {
                                    cost = 160;
                                }
                                else
                                {
                                    cost = weight * 100;
                                }
                                break;
                            case "4":
                                if (weight <= (110 / 160))
                                {
                                    cost = 160;
                                }
                                else
                                {
                                    cost = weight * 110;
                                }
                                if (weight > 10)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "5":
                                if (weight <= (110 / 160))
                                {
                                    cost = 160;
                                }
                                else
                                {
                                    cost = weight * 110;
                                }
                                if (weight > 20)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "6":
                                if (weight <= (110 / 160))
                                {
                                    cost = 160;
                                }
                                else
                                {
                                    cost = weight * 110;
                                }
                                if (weight > 30)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "7":
                                if (weight <= (110 / 160))
                                {
                                    cost = 160;
                                }
                                else
                                {
                                    cost = weight * 110;
                                }
                                break;
                        }
                        break;
                    case "2":
                        switch (PackageType)
                        {
                            case "1":
                                cost = 140;
                                break;
                            case "2":
                                if (weight <= (90 / 140))
                                {
                                    cost = 140;
                                }
                                else
                                {
                                    cost = weight * 90;
                                }
                                if (weight > 5)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "3":
                                if (weight <= (90 / 140))
                                {
                                    cost = 140;
                                }
                                else
                                {
                                    cost = weight * 90;
                                }
                                break;
                            case "4":
                                if (weight <= (99 / 140))
                                {
                                    cost = 140;
                                }
                                else
                                {
                                    cost = weight * 99;
                                }
                                if (weight > 10)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "5":
                                if (weight <= (99 / 140))
                                {
                                    cost = 140;
                                }
                                else
                                {
                                    cost = weight * 99;
                                }
                                if (weight > 20)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "6":
                                if (weight <= (99 / 140))
                                {
                                    cost = 140;
                                }
                                else
                                {
                                    cost = weight * 99;
                                }
                                if (weight > 30)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "7":
                                if (weight <= (99 / 140))
                                {
                                    cost = 140;
                                }
                                else
                                {
                                    cost = weight * 99;
                                }
                                break;
                        }
                        break;
                    case "3":
                        switch (PackageType)
                        {
                            case "1":
                                cost = 130;
                                break;
                            case "2":
                                if (weight <= (80 / 130))
                                {
                                    cost = 130;
                                }
                                else
                                {
                                    cost = weight * 80;
                                }
                                if (weight > 5)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "3":
                                if (weight <= (80 / 130))
                                {
                                    cost = 130;
                                }
                                else
                                {
                                    cost = weight * 80;
                                }
                                break;
                            case "4":
                                if (weight <= (88 / 130))
                                {
                                    cost = 130;
                                }
                                else
                                {
                                    cost = weight * 88;
                                }
                                if (weight > 10)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "5":
                                if (weight <= (88 / 130))
                                {
                                    cost = 130;
                                }
                                else
                                {
                                    cost = weight * 88;
                                }
                                if (weight > 20)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "6":
                                if (weight <= (88 / 130))
                                {
                                    cost = 130;
                                }
                                else
                                {
                                    cost = weight * 88;
                                }
                                if (weight > 30)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "7":
                                if (weight <= (88 / 130))
                                {
                                    cost = 130;
                                }
                                else
                                {
                                    cost = weight * 88;
                                }
                                break;
                        }
                        break;
                    case "4":
                        switch (PackageType)
                        {
                            case "1":
                                cost = 120;
                                break;
                            case "2":
                                if (weight <= (70 / 120))
                                {
                                    cost = 120;
                                }
                                else
                                {
                                    cost = weight * 70;
                                }
                                if (weight > 5)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "3":
                                if (weight <= (70 / 120))
                                {
                                    cost = 120;
                                }
                                else
                                {
                                    cost = weight * 70;
                                }
                                break;
                            case "4":
                                if (weight <= (77 / 120))
                                {
                                    cost = 120;
                                }
                                else
                                {
                                    cost = weight * 77;
                                }
                                if (weight > 10)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "5":
                                if (weight <= (77 / 120))
                                {
                                    cost = 120;
                                }
                                else
                                {
                                    cost = weight * 77;
                                }
                                if (weight > 20)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "6":
                                if (weight <= (77 / 120))
                                {
                                    cost = 120;
                                }
                                else
                                {
                                    cost = weight * 77;
                                }
                                if (weight > 30)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "7":
                                if (weight <= (77 / 120))
                                {
                                    cost = 120;
                                }
                                else
                                {
                                    cost = weight * 77;
                                }
                                break;
                        }
                        break;
                    case "5":
                        switch (PackageType)
                        {
                            case "1":
                                cost = 50;
                                break;
                            case "2":
                                if (weight <= (50 / 50))
                                {
                                    cost = 50;
                                }
                                else
                                {
                                    cost = weight * 50;
                                }
                                if (weight > 5)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "3":
                                if (weight <= (50 / 50))
                                {
                                    cost = 50;
                                }
                                else
                                {
                                    cost = weight * 50;
                                }
                                break;
                            case "4":
                                if (weight <= (55 / 55))
                                {
                                    cost = 55;
                                }
                                else
                                {
                                    cost = weight * 55;
                                }
                                if (weight > 10)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "5":
                                if (weight <= (55 / 55))
                                {
                                    cost = 55;
                                }
                                else
                                {
                                    cost = weight * 55;
                                }
                                if (weight > 20)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "6":
                                if (weight <= (55 / 55))
                                {
                                    cost = 55;
                                }
                                else
                                {
                                    cost = weight * 55;
                                }
                                if (weight > 30)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "7":
                                if (weight <= (55 / 55))
                                {
                                    cost = 55;
                                }
                                else
                                {
                                    cost = weight * 55;
                                }
                                break;
                        }
                        break;
                    case "6":
                        switch (PackageType)
                        {
                            case "1":
                                cost = 25;
                                break;
                            case "2":
                                if (weight <= (25 / 25))
                                {
                                    cost = 25;
                                }
                                else
                                {
                                    cost = weight * 25;
                                }
                                if (weight > 5)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "3":
                                if (weight <= (25 / 25))
                                {
                                    cost = 25;
                                }
                                else
                                {
                                    cost = weight * 25;
                                }
                                break;
                            case "4":
                                if (weight <= (30 / 30))
                                {
                                    cost = 30;
                                }
                                else
                                {
                                    cost = weight * 30;
                                }
                                if (weight > 10)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "5":
                                if (weight <= (30 / 30))
                                {
                                    cost = 30;
                                }
                                else
                                {
                                    cost = weight * 30;
                                }
                                if (weight > 20)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "6":
                                if (weight <= (30 / 30))
                                {
                                    cost = 30;
                                }
                                else
                                {
                                    cost = weight * 30;
                                }
                                if (weight > 30)
                                {
                                    cost += 500;
                                    isOverWeight = true;
                                }
                                break;
                            case "7":
                                if (weight <= (30 / 30))
                                {
                                    cost = 30;
                                }
                                else
                                {
                                    cost = weight * 30;
                                }
                                break;
                        }
                        break;
                }
            }

            double rate = Double.Parse(currency);

            ViewBag.Rate = rate;

            ViewBag.IsOverWeight = isOverWeight;

            ViewBag.PreCost = isOverWeight ? cost - 500 : cost;

            ViewBag.Cost = cost * rate;
            return View();
        }

        // GET: ServicePackageFees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicePackageFee servicePackageFee = db.ServicePackageFees.Find(id);
            if (servicePackageFee == null)
            {
                return HttpNotFound();
            }
            return View(servicePackageFee);
        }

        // GET: ServicePackageFees/Create
        public ActionResult Create()
        {
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "Type");
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ServiceTypeID", "Type");
            return View();
        }

        // POST: ServicePackageFees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicePackageFeeID,Fee,MinimumFee,PackageTypeID,ServiceTypeID")] ServicePackageFee servicePackageFee)
        {
            if (ModelState.IsValid)
            {
                db.ServicePackageFees.Add(servicePackageFee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "Type", servicePackageFee.PackageTypeID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ServiceTypeID", "Type", servicePackageFee.ServiceTypeID);
            return View(servicePackageFee);
        }

        // GET: ServicePackageFees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicePackageFee servicePackageFee = db.ServicePackageFees.Find(id);
            if (servicePackageFee == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "Type", servicePackageFee.PackageTypeID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ServiceTypeID", "Type", servicePackageFee.ServiceTypeID);
            return View(servicePackageFee);
        }

        // POST: ServicePackageFees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicePackageFeeID,Fee,MinimumFee,PackageTypeID,ServiceTypeID")] ServicePackageFee servicePackageFee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicePackageFee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "Type", servicePackageFee.PackageTypeID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ServiceTypeID", "Type", servicePackageFee.ServiceTypeID);
            return View(servicePackageFee);
        }

        // GET: ServicePackageFees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicePackageFee servicePackageFee = db.ServicePackageFees.Find(id);
            if (servicePackageFee == null)
            {
                return HttpNotFound();
            }
            return View(servicePackageFee);
        }

        // POST: ServicePackageFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicePackageFee servicePackageFee = db.ServicePackageFees.Find(id);
            db.ServicePackageFees.Remove(servicePackageFee);
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
