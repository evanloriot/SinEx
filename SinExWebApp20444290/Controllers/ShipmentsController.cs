using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinExWebApp20444290.Models;
using SinExWebApp20444290.ViewModels;
using X.PagedList;

namespace SinExWebApp20444290.Controllers
{
    public class ShipmentsController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        // GET: Shipments
        public ActionResult Index()
        {
            return View(db.Shipments.ToList());
        }

        // GET: Shipments/GenerateHistoryReport
        public ActionResult GenerateHistoryReport(int? ShippingAccountID, string SortOrder, int? CurrentShippingAccountID, int? page, string StartShippedDate, string EndShippedDate)
        {
            if (!Request.IsAuthenticated)
            {
                return View();
            }

            // Instantiate an instance of the ShipmentsReportViewModel and the ShipmentsSearchViewModel.
            var shipmentSearch = new ShipmentsReportViewModel();
            shipmentSearch.Shipment = new ShipmentsSearchViewModel();

            //Code for paging.
            ViewBag.CurrentSort = SortOrder;
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            if(ShippingAccountID == null)
            {
                ShippingAccountID = CurrentShippingAccountID;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentShippingAccountID = ShippingAccountID;

            // Populate the ShippingAccountId dropdown list.
            shipmentSearch.Shipment.ShippingAccounts = PopulateShippingAccountsDropdownList().ToList();

            // Initialize the query to retrieve shipments using the ShipmentsListViewModel.
            var shipmentQuery = from s in db.Shipments
                                select new ShipmentsListViewModel
                                {
                                    WaybillID = s.WaybillID,
                                    ServiceType = s.ServiceType,
                                    ShippedDate = s.ShippedDate,
                                    DeliveredDate = s.DeliveredDate,
                                    RecipientName = s.RecipientName,
                                    NumberOfPackages = s.NumberOfPackages,
                                    Origin = s.Origin,
                                    Destination = s.Destination,
                                    ShippingAccountID = s.ShippingAccountID
                                };

            // Add the condition to select a spefic shipping account if shipping account id is not null.
            if(ShippingAccountID != null && StartShippedDate != null && EndShippedDate != null)
            {
                DateTime CStartDate;
                DateTime CEndDate;
                shipmentQuery = shipmentQuery.Where(id => id.ShippingAccountID == ShippingAccountID);
                if (DateTime.TryParse(StartShippedDate, out CStartDate) && DateTime.TryParse(EndShippedDate, out CEndDate))
                {
                    shipmentQuery = shipmentQuery.Where(start => start.ShippedDate >= CStartDate && start.ShippedDate <= CEndDate);
                }
                else if(StartShippedDate == "" || EndShippedDate == "")
                {

                }
                else
                {
                    ViewBag.DateError = true;
                }
            }
            else if (StartShippedDate != null && EndShippedDate != null)
            {
                DateTime CStartDate;
                DateTime CEndDate;
                if(DateTime.TryParse(StartShippedDate, out CStartDate) && DateTime.TryParse(EndShippedDate, out CEndDate))
                {
                    shipmentQuery = shipmentQuery.Where(start => start.ShippedDate >= CStartDate && start.ShippedDate <= CEndDate);
                }
                else
                {
                    ViewBag.DateError = true;
                }
            }
            else if (ShippingAccountID != null)
            {
                shipmentQuery = shipmentQuery.Where(id => id.ShippingAccountID == ShippingAccountID);
            }

            ViewBag.ServiceTypeSortParam = SortOrder == "service_type" ? "service_type_desc" : "service_type";
            ViewBag.ShippedDateSortParam = SortOrder == "shipped_date" ? "shipped_date_desc" : "shipped_date";
            ViewBag.DeliveredDateSortParam = SortOrder == "delivered_date" ? "delivered_date_desc" : "delivered_date";
            ViewBag.RecipientNameSortParam = SortOrder == "recipient_name" ? "recipient_name_desc" : "recipient_name";
            ViewBag.OriginSortParam = SortOrder == "origin" ? "origin_desc" : "origin";
            ViewBag.DestinationSortParam = SortOrder == "destination" ? "destination_desc" : "destination";
            switch (SortOrder)
            {
                case "service_type":
                    shipmentQuery = shipmentQuery.OrderBy(st => st.ServiceType);
                    break;
                case "service_type_desc":
                    shipmentQuery = shipmentQuery.OrderByDescending(st => st.ServiceType);
                    break;
                case "shipped_date":
                    shipmentQuery = shipmentQuery.OrderBy(st => st.ShippedDate);
                    break;
                case "shipped_date_desc":
                    shipmentQuery = shipmentQuery.OrderByDescending(st => st.ShippedDate);
                    break;
                case "delivered_date":
                    shipmentQuery = shipmentQuery.OrderBy(st => st.DeliveredDate);
                    break;
                case "delivered_date_desc":
                    shipmentQuery = shipmentQuery.OrderByDescending(st => st.DeliveredDate);
                    break;
                case "recipient_name":
                    shipmentQuery = shipmentQuery.OrderBy(st => st.RecipientName);
                    break;
                case "recipient_name_desc":
                    shipmentQuery = shipmentQuery.OrderByDescending(st => st.RecipientName);
                    break;
                case "origin":
                    shipmentQuery = shipmentQuery.OrderBy(st => st.Origin);
                    break;
                case "origin_desc":
                    shipmentQuery = shipmentQuery.OrderByDescending(st => st.Origin);
                    break;
                case "destination":
                    shipmentQuery = shipmentQuery.OrderBy(st => st.Destination);
                    break;
                case "destination_desc":
                    shipmentQuery = shipmentQuery.OrderByDescending(st => st.Destination);
                    break;
                default:
                    shipmentQuery = shipmentQuery.OrderBy(st => st.WaybillID);
                    break;
            }
            if (!User.IsInRole("Employee"))
            {
                var q = from s in db.ShippingAccounts where s.UserName == User.Identity.Name select s.ShippingAccountID;
                int AccountID = q.ToList()[0];
                shipmentQuery = shipmentQuery.Where(id => id.ShippingAccountID == AccountID);
            }
            shipmentSearch.Shipments = shipmentQuery.ToPagedList(pageNumber, pageSize);
            return View(shipmentSearch);
        }

        private SelectList PopulateShippingAccountsDropdownList()
        {
            // TODO: Construct the LINQ query to retrieve the unique list of shipping account ids.
            var shippingAccountQuery = db.Shipments.Select(id => id.ShippingAccountID).Distinct().OrderBy(id => id);
            return new SelectList(shippingAccountQuery);
        }

        public ActionResult TrackShipment(int? WaybillID)
        {
            ViewBag.ErrorText = "";
            if(WaybillID == null)
            {
                return View();
            }

            var shipmentSearch = new TrackingReportViewModel();

            var q = from s in db.Shipments
                    select new 
                    {
                        s.WaybillID,
                        s.RecipientName,
                        s.DeliveredAt,
                        s.Status,
                        s.ServiceType,
                        s.Packages
                    };
            q = q.Where(s => s.WaybillID == WaybillID);
            if(q.ToList().Count == 0)
            {
                ViewBag.ErrorText = "No results found.";
                return View();
            }
            var list = q.ToList()[0];
            Shipment shipment = new Shipment();
            shipment.WaybillID = list.WaybillID;
            shipment.RecipientName = list.RecipientName;
            shipment.DeliveredAt = list.DeliveredAt;
            shipment.Status = list.Status;
            shipment.ServiceType = list.ServiceType;
            shipment.Packages = list.Packages;
            shipmentSearch.Shipment = shipment;

            var t = from s in db.TrackingStatements
                    select new 
                    {
                        s.WaybillID,
                        s.DateTime,
                        s.Description,
                        s.Location,
                        s.Remarks
                    };
            t = t.Where(s => s.WaybillID == WaybillID).Distinct();
            var holder = t.ToList();
            List<TrackingStatement> trackingStatements = new List<TrackingStatement>();
            TrackingStatement trackingStatement = new TrackingStatement();
            for(int i = 0; i < holder.Count; i++)
            {
                trackingStatement = new TrackingStatement();
                trackingStatement.DateTime = holder[i].DateTime;
                trackingStatement.Description = holder[i].Description;
                trackingStatement.Location = holder[i].Location;
                trackingStatement.Remarks = holder[i].Remarks;
                trackingStatements.Add(trackingStatement);
            }

            shipmentSearch.TrackingStatements = trackingStatements;

            return View(shipmentSearch);
        }

        public ActionResult TrackingSystem(int? WaybillID)
        {
            var q = from s in db.TrackingStatements
                    select new
                    {
                        s.WaybillID,
                        s.DateTime,
                        s.Description,
                        s.Location,
                        s.Remarks
                    };
            var holder = q.ToList();
            List<TrackingStatement> tss = new List<TrackingStatement>();
            foreach(var item in holder)
            {
                TrackingStatement ts = new TrackingStatement();
                ts.WaybillID = item.WaybillID;
                ts.DateTime = item.DateTime;
                ts.Description = item.Description;
                ts.Location = item.Location;
                ts.Remarks = item.Remarks;
                tss.Add(ts);
            }
            return View(tss);
        }

        public ActionResult TrackingSystemCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrackingSystemCreate([Bind(Include = "TrackingStatementID,WaybillID,DateTime,Description,Location,Remarks")] TrackingStatement ts)
        {
            if (ModelState.IsValid)
            {
                db.TrackingStatements.Add(ts);
                db.SaveChanges();
                return RedirectToAction("TrackingSystem");
            }

            return View(ts);
        }

        public ActionResult TrackingSystemStatus()
        {
            var q = from s in db.Shipments
                    select new
                    {
                        s.WaybillID,
                        s.RecipientName,
                        s.DeliveredAt,
                        s.Status,
                        s.Origin,
                        s.Destination
                    };
            var holder = q.ToList();
            List<Shipment> ss = new List<Shipment>();
            foreach(var item in holder)
            {
                Shipment s = new Shipment();
                s.WaybillID = item.WaybillID;
                s.RecipientName = item.RecipientName;
                s.DeliveredAt = item.DeliveredAt;
                s.Status = item.Status;
                s.Origin = item.Origin;
                s.Destination = item.Destination;
                ss.Add(s);
            }

            return View(ss);
        }

        public ActionResult TrackingSystemStatusEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrackingSystemStatusEdit([Bind(Include = "WaybillID,RecipientName,DeliveredAt,Status,Destination,Origin")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Shipments.Attach(shipment);
                db.Entry(shipment).Property(x => x.RecipientName).IsModified = true;
                db.Entry(shipment).Property(x => x.DeliveredAt).IsModified = true;
                db.Entry(shipment).Property(x => x.Status).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("TrackingSystemStatus");
            }
            return View(shipment);
        }

        public ActionResult EmployeeShipment()
        {
            var q = from s in db.Shipments
                    select new
                    {
                        s.WaybillID,
                        s.Duty,
                        s.Tax
                    };
            var holder = q.ToList();
            List<Shipment> ss = new List<Shipment>();
            foreach(var item in holder)
            {
                Shipment s = new Shipment();
                s.WaybillID = item.WaybillID;
                s.Duty = item.Duty;
                s.Tax = item.Tax;
                ss.Add(s);
            }

            return View(ss);
        }

        public ActionResult EmployeeShipmentEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeShipmentEdit([Bind(Include = "WaybillID,Duty,Tax,Origin,Destination")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Shipments.Attach(shipment);
                db.Entry(shipment).Property(x => x.Duty).IsModified = true;
                db.Entry(shipment).Property(x => x.Tax).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("EmployeeShipment");
            }
            return View(shipment);
        }

        public ActionResult EmployeePackage()
        {
            var q = from s in db.Packages
                    select new
                    {
                        s.PackageID,
                        s.WaybillID,
                        s.Weight
                    };
            var holder = q.ToList();
            List<Package> ps = new List<Package>();
            foreach (var item in holder)
            {
                Package p = new Package();
                p.PackageID = item.PackageID;
                p.WaybillID = item.WaybillID;
                p.Weight = item.Weight;
                ps.Add(p);
            }

            return View(ps);
        }

        public ActionResult EmployeePackageEdit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeePackageEdit([Bind(Include = "PackageID,Weight")] Package package)
        {
            if (ModelState.IsValid)
            {
                db.Packages.Attach(package);
                db.Entry(package).Property(x => x.Weight).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("EmployeePackage");
            }
            return View(package);
        }

        public ActionResult MakeShipment()
        {
            return View();
        }


        // GET: Shipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // GET: Shipments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WaybillID,ReferenceNumber,ServiceType,ShippedDate,DeliveredDate,RecipientName,NumberOfPackages,Origin,Destination,Status,ShippingAccountID")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Shipments.Add(shipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipment);
        }

        // GET: Shipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WaybillID,ReferenceNumber,ServiceType,ShippedDate,DeliveredDate,RecipientName,NumberOfPackages,Origin,Destination,Status,ShippingAccountID")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipment);
        }

        // GET: Shipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipment shipment = db.Shipments.Find(id);
            db.Shipments.Remove(shipment);
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
