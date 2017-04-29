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
