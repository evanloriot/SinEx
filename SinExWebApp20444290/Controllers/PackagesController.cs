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
    public class PackagesController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        // GET: Packages
        public ActionResult Index(int WaybillID)
        {
            ViewBag.WaybillID = WaybillID;
            Shipment shipment = db.Shipments.Single(s => s.WaybillID == WaybillID);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAuthenticated)
            {
                ShippingAccount shippingAccount = db.ShippingAccounts.SingleOrDefault(s => s.UserName == User.Identity.Name);
                //check if the waybill belongs to the current user
                if (shipment.ShippingAccountID != shippingAccount.ShippingAccountID)
                {
                    return HttpNotFound();
                }
            }
            
            var packages = db.Packages.Include(p => p.Currency).Include(p => p.PackageType).Include(p => p.Shipment).Where(p => p.WaybillID == shipment.WaybillID);
            return View(packages.ToList());
        }

        // GET: Packages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // GET: Packages/Create
        public ActionResult Create(int WaybillID)
        {
            Shipment shipment = db.Shipments.Single(s => s.WaybillID == WaybillID);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            if (shipment.Packages.Count() >= 10)
            {
                return RedirectToAction("Details", "Shipments", new { id = WaybillID });
            }

            ViewBag.CurrencyCode = new SelectList(db.Currencies, "CurrencyCode", "CurrencyCode");
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "Type");
            ViewBag.PackageTypeSizeID = new SelectList(db.PackageTypeSizes.Where(s => s.PackageTypeSizeID == 0), "PackageTypeSizeID", "TypeSize");
            ViewBag.WaybillId = WaybillID;
            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PackageID,WaybillID,PackageTypeID,PackageTypeSizeID,Description,ContentValue,CurrencyCode,Weight,Fee")] Package package)
        {
            //package.Weight = Math.Round(package.Weight, 1);
            bool isPackageTypeSizeEmpty = false;
            if (package.PackageTypeSizeID == 0)
            {
                isPackageTypeSizeEmpty = true;
            }
            if (ModelState.IsValid && isPackageTypeSizeEmpty==false)
            {   
                package.Currency = db.Currencies.Single(s => s.CurrencyCode == package.CurrencyCode);
                package.PackageType = db.PackageTypes.Single(s => s.PackageTypeID == package.PackageTypeID);
                package.PackageTypeSize = db.PackageTypeSizes.Single(s => s.PackageTypeSizeID == package.PackageTypeSizeID);
                package.Shipment = db.Shipments.Single(s => s.WaybillID == package.WaybillID);
                //package.Fee = CalculatePrice(package);
                db.Packages.Add(package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyCode = new SelectList(db.Currencies, "CurrencyCode", "CurrencyCode", package.CurrencyCode);
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "Type", package.PackageTypeID);
            ViewBag.PackageTypeSizeID = new SelectList(db.PackageTypeSizes, "PackageTypeSizeID", "Description", package.PackageTypeSizeID);
            ViewBag.WaybillID = new SelectList(db.Shipments, "WaybillID", "ReferenceNumber", package.WaybillID);
            return View(package);
        }

        // GET: Packages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyCode = new SelectList(db.Currencies, "CurrencyCode", "CurrencyCode", package.CurrencyCode);
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "Type", package.PackageTypeID);
            ViewBag.PackageTypeSizeID = new SelectList(db.PackageTypeSizes.Where(s => s.PackageTypeID == package.PackageTypeID), "PackageTypeSizeID", "TypeSize", package.PackageTypeSizeID);
            ViewBag.WaybillId = package.WaybillID;
            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PackageID,WaybillID,PackageTypeSizeID,Description,ContentValue,CurrencyCode,Weight,Fee,PackageTypeID")] Package package)
        {
            if (ModelState.IsValid)
            {
                Shipment shipment = db.Shipments.SingleOrDefault(s => s.WaybillID == package.WaybillID);
                package.Shipment = shipment;
                package.Fee = PackageFee(package);
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();


                shipment.ShipmentAmount = 0;
                foreach(Package p in shipment.Packages)
                {
                    shipment.ShipmentAmount += PackageFee(p);
                }
                db.Entry(shipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { WaybillId = package.WaybillID });
            }
            ViewBag.CurrencyCode = new SelectList(db.Currencies, "CurrencyCode", "CurrencyCode", package.CurrencyCode);
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "Type", package.PackageTypeID);
            ViewBag.PackageTypeSizeID = new SelectList(db.PackageTypeSizes.Where(s => s.PackageTypeID == package.PackageTypeID), "PackageTypeSizeID", "TypeSize", package.PackageTypeSizeID);
            ViewBag.WaybillId = package.WaybillID;
            return View(package);
        }
        public decimal PackageFeePublic(int weight, int PackageTypeID)
        {
            Package Package = new Package();
            Package.PackageTypeID = PackageTypeID;
            Package.Weight = weight;
            decimal price = 0;
            switch (Package.PackageTypeID)
            {
                //Envelop
                case 1:
                    price = 160;
                    break;
                //Pack/Box
                case 2:
                    if (Package.Weight * 100 > 160)
                    {
                        price = (decimal)Package.Weight * 100;
                    }
                    else
                    {
                        price = 160;
                    }
                    int limit = 5;
                    if (limit < Package.Weight)
                    {
                        price += 500;
                    }
                    break;
                case 4:
                    if (Package.Weight * 110 > 160)
                    {
                        price = (decimal)Package.Weight * 110;
                    }
                    else
                    {
                        price = 160;
                    }
                    int weightLimit = 10;

                    if (weightLimit < Package.Weight)
                    {
                        price += 500;
                    }
                    break;
                //Tube or Customer
                case 3:
                    if (Package.Weight * 100 > 160)
                    {
                        price = (decimal)Package.Weight * 100;
                    }
                    else
                    {
                        price = 160;
                    }
                    break;
                case 5:
                    if (Package.Weight * 110 > 160)
                    {
                        price = (decimal)Package.Weight * 110;
                    }
                    else
                    {
                        price = 160;
                    }
                    break;
            }
            return price;
        }
        //Calculate package fee from declared weight in RMB
        private decimal PackageFee(Package Package)
        {
            ServicePackageFee servicePackageFees = db.ServicePackageFees.SingleOrDefault(a => a.PackageTypeID == Package.PackageTypeID && a.ServiceTypeID == Package.Shipment.ServiceTypeID);
            PackageTypeSize packageTypeSizes = db.PackageTypeSizes.Single(a => a.PackageTypeSizeID == Package.PackageTypeSizeID);
            decimal price = 0;
            switch (Package.PackageTypeID)
            {
                //Envelop
                case 1:
                    price = servicePackageFees.Fee;
                    break;
                //Pack/Box
                case 2:
                    if (Package.Weight * servicePackageFees.Fee > servicePackageFees.MinimumFee){
                        price = (decimal)Package.Weight * servicePackageFees.Fee;
                    }
                    else{
                        price = servicePackageFees.MinimumFee;
                    }
                    int limit = 0;
                    string limitString = packageTypeSizes.WeightLimit;
                    bool convertResult = Int32.TryParse(limitString.Substring(0, limitString.Length - 2), out limit);
                    if (limit != 0 && convertResult && Package.Weight > (decimal)limit){
                        price += 500;
                    }
                    break;
                case 4:
                    if (Package.Weight * servicePackageFees.Fee > servicePackageFees.MinimumFee){
                        price = (decimal)Package.Weight * servicePackageFees.Fee;
                    }
                    else{
                        price = servicePackageFees.MinimumFee;
                    }
                    int weightLimit = 0;
                    string limitInString = packageTypeSizes.WeightLimit;
                    bool result = Int32.TryParse(limitInString.Substring(0, limitInString.Length - 2), out weightLimit);
                    if (weightLimit != 0 && result && Package.Weight > (decimal)weightLimit){
                        price += 500;
                    }
                    break;
                //Tube or Customer
                case 3:
                    if (Package.Weight * servicePackageFees.Fee > servicePackageFees.MinimumFee){
                        price = (decimal)Package.Weight * servicePackageFees.Fee;
                    }
                    else{
                        price = servicePackageFees.MinimumFee;
                    }
                    break;
                case 5:
                    if (Package.Weight * servicePackageFees.Fee > servicePackageFees.MinimumFee){
                        price = (decimal)Package.Weight * servicePackageFees.Fee;
                    }
                    else{
                        price = servicePackageFees.MinimumFee;
                    }
                    break;
            }
            return price;
        }

        // GET: Packages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            Shipment shipment = db.Shipments.Single(s => s.WaybillID == package.WaybillID);
            if (package == null || shipment == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = db.Packages.Find(id);
            Shipment shipment = db.Shipments.Single(s => s.WaybillID == package.WaybillID);
            db.Packages.Remove(package);
            shipment.NumberOfPackages -= 1;
            shipment.ShipmentAmount -= (decimal)package.Fee;
            db.Entry(shipment).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", new { WaybillId = package.WaybillID });
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
