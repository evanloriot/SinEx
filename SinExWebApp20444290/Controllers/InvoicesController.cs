using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using SinExWebApp20444290.Models;
using X.PagedList;
using SinExWebApp20444290.ViewModels;

namespace SinExWebApp20444290.Controllers
{
    public class InvoicesController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();
        
        //Get : Payments/GeneratePaymentHistory
        public ActionResult GeneratePaymentHistoryReport(
            int? ShippingAccountId,
            DateTime? StartingDate,
            DateTime? EndingDate,
            string sortOrder,
            int? currentShippingAccountId,
            DateTime? currentStartingDate,
            DateTime? currentEndingDate,
            int? page)
        {

            if (ShippingAccountId == null)
            {
                ShippingAccountId = currentShippingAccountId;
            }

            // Instantiate an instance of the PaymentsReportViewModel and the PaymentsSearchViewModel.
            var PaymentReport = new PaymentsReportViewModel();
            PaymentReport.PaymentSearch = new PaymentsSearchViewModel();

            // Code for paging.
            ViewBag.CurrentSort = sortOrder;
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            // Retain search conditions for sorting.
            if (StartingDate == null)
            {
                StartingDate = currentStartingDate;
            }
            if (EndingDate == null)
            {
                EndingDate = currentEndingDate;
            }
            if (ShippingAccountId == null)
            {
                ShippingAccountId = currentShippingAccountId;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentShippingAccountId = ShippingAccountId;
            ViewBag.CurrentStartingDate = StartingDate;
            ViewBag.CurrentEndingDate = EndingDate;


            // Populate the ShippingAccountId dropdown list.
            var shippingAccountQuery = db.Invoices.Select(s => s.UserName).Distinct().OrderBy(s => s);
            var hehe = db.ShippingAccounts.Where(m => shippingAccountQuery.Contains(m.UserName)).Select(m => m.ShippingAccountID).Distinct().OrderBy(m => m);


            var n = (new SelectList(hehe)).ToList() ;
            foreach (SelectListItem k in n)
            {
                k.Value = k.Text;
            }
            n.Insert(0, new SelectListItem
            {
                Text = "All",
                Value = "0"
            });
            int haha = 0;
            for (int i = 0; i < n.Count(); i++)
            {
                if (n.ElementAt(i).Value == ShippingAccountId.ToString())
                {
                    haha = i;
                    break;
                }
            }
            foreach (var item in n)
            {
                if (item.Value == ShippingAccountId.ToString())
                {
                    item.Selected = true;
                }
            }
            PaymentReport.PaymentSearch.ShippingAccounts = n;
            PaymentReport.PaymentSearch.ShippingAccountId = ShippingAccountId == null ? 0 : (int)ShippingAccountId;
            //Initialize the query to retrieve payments using the PaymentsListViewModel.
            var list = new List<PaymentsListViewModel>();
            foreach (Invoice v in db.Invoices)
            {
                PaymentsListViewModel m = new PaymentsListViewModel();
                Shipment ship = db.Shipments.SingleOrDefault(a => a.WaybillID == v.WaybillID);
                m.WaybillId = v.WaybillID;
                m.ShippingAccountId = v.PayerCharacter == "Recipient" ? ship.RecipientShippingAccountID : ship.ShippingAccountID;
                m.ShipDate = (DateTime)ship.PickupDate;
                m.RecipientName = ship.RecipientName;
                m.OriginCity = ship.Origin;
                m.DestinationCity = ship.Destination;
                m.ServiceType = db.ServiceTypes.Single(a => a.Type == ship.ServiceType).Type;
                m.TotalPaymentAmount = v.PaymentAmount;
                m.PaymentDescription = v.PaymentDescription;
                list.Add(m);
            }
            var paymentQuery = list.AsQueryable();
            // Add the condition to select a spefic shipping account if shipping account id is not null.
            if (ShippingAccountId != 0 && ShippingAccountId != null)
            {
                // TODO: Construct the LINQ query to retrive only the shipments for the specified shipping account id.
                paymentQuery = paymentQuery.Where(s => s.ShippingAccountId == ShippingAccountId);

            }

            if ((StartingDate != null) && (EndingDate != null))
            {
                paymentQuery = paymentQuery.Where(s => (s.ShipDate > StartingDate && s.ShipDate < EndingDate));
            }
            else
            {
                // Return an empty result if no shipping account id has been selected.
                PaymentReport.PaymentList = new PaymentsListViewModel[0].ToPagedList(pageNumber, pageSize);
            }

            // Code for sorting on ServiceType, ShippedDate, DeliveredDate, RecipientName, Origin, Destination
            ViewBag.ServiceTypeSortParm = sortOrder == "serviceType" ? "serviceType_desc" : "serviceType";
            ViewBag.ShippedDateSortParm = sortOrder == "shippedDate" ? "shippedDate_desc" : "shippedDate";
            ViewBag.RecipientNameSortParm = sortOrder == "recipientName" ? "recipientName_desc" : "recipientName";
            ViewBag.OriginSortParm = sortOrder == "origin" ? "origin_desc" : "origin";
            ViewBag.DestinationSortParm = sortOrder == "destination" ? "destination_desc" : "destination";
            ViewBag.InvoiceAmountSortParm = sortOrder == "invoiceAmount" ? "invoiceAmount_desc" : "invoiceAmount";
            switch (sortOrder)
            {
                case "serviceType_desc":
                    paymentQuery = paymentQuery.OrderByDescending(s => s.ServiceType);
                    break;
                case "serviceType":
                    paymentQuery = paymentQuery.OrderBy(s => s.ServiceType);
                    break;
                case "shippedDate_desc":
                    paymentQuery = paymentQuery.OrderByDescending(s => s.ShipDate);
                    break;
                case "shippedDate":
                    paymentQuery = paymentQuery.OrderBy(s => s.ShipDate);
                    break;
                case "recipientName_desc":
                    paymentQuery = paymentQuery.OrderByDescending(s => s.RecipientName);
                    break;
                case "recipientName":
                    paymentQuery = paymentQuery.OrderBy(s => s.RecipientName);
                    break;
                case "origin_desc":
                    paymentQuery = paymentQuery.OrderByDescending(s => s.OriginCity);
                    break;
                case "origin":
                    paymentQuery = paymentQuery.OrderBy(s => s.OriginCity);
                    break;
                case "destination_desc":
                    paymentQuery = paymentQuery.OrderByDescending(s => s.DestinationCity);
                    break;
                case "destination":
                    paymentQuery = paymentQuery.OrderBy(s => s.DestinationCity);
                    break;
                case "invoiceAmount_desc":
                    paymentQuery = paymentQuery.OrderByDescending(s => s.TotalPaymentAmount);
                    break;
                case "invoiceAmount":
                    paymentQuery = paymentQuery.OrderBy(s => s.TotalPaymentAmount);
                    break;
                default:
                    paymentQuery = paymentQuery.OrderBy(s => s.WaybillId);
                    break;
            }
            PaymentReport.PaymentList = paymentQuery.ToPagedList(pageNumber, pageSize);
            return View(PaymentReport);
        }

        public void CreateInvoice(int WaybillID)
        {
            var q = from s in db.Shipments
                    select new
                    {
                        s.ShippingAccountID,
                        s.PickupDate,
                        s.ServiceType,
                        s.ReferenceNumber,
                        s.ShippingAccount,
                        s.RecipientName,
                        s.ShipmentAmount,
                        s.Packages,
                        s.ShipmentPayer,
                    };
            var holder = q.ToList()[0];

            var a = from s in db.ShippingAccounts
                    select s;
            a = a.Where(s => s.ShippingAccountID == holder.ShippingAccountID);

            PersonalShippingAccount psa = (PersonalShippingAccount) a.ToList()[0];

            int authorizationCode = BaseController.AuthorizeCreditCard("", "", holder.ShipmentAmount);

            Invoice invoice = new Invoice();
            invoice.AuthorizationCode = authorizationCode.ToString();
            foreach(var item in holder.Packages)
            {
                invoice.CurrencyCode = item.CurrencyCode;
                break;
            }
            invoice.PayerCharacter = holder.ShipmentPayer ? psa.FirstName + " " + psa.LastName : holder.RecipientName;
            invoice.PaymentAmount = holder.ShipmentAmount;
            invoice.WaybillID = WaybillID;

            //string email = holder.ShipmentPayer ? psa.Email : holder.RecipientEmail;

            string html = "";
            html = html + "<p>Hello " + invoice.PayerCharacter + ",</p>";
            html = html + "<p>Here is the invoice for Shipment: " + invoice.WaybillID + "</p>";
            html = html + "<p>Invoice payer: " + invoice.PayerCharacter + "</p>";
            html = html + "<p>Shipment waybill number: " + invoice.WaybillID + "</p>";
            html = html + "<p>Ship date: " + holder.PickupDate + "</p>";
            html = html + "<p>Service type: " + holder.ServiceType + "</p>";
            html = html + "<p>Reference Number: " + holder.ReferenceNumber + "</p>";
            html = html + "<p>Sender name: " + psa.FirstName + " " + psa.LastName + "</p>";
            html = html + "<p>Sender address: " + psa.Building + ", " + psa.Street + ", " + psa.City + ", " + psa.Province + ", " + psa.PostalCode + "</p>";
            html = html + "<p>Recipient name: " + holder.RecipientName + "</p>";
            //html = html + "<p>Recipient address: " + holder.RecipientAddress + "</p>";//fix this
            html = html + "<p>Credit card type: " + psa.ccType + "</p>";
            html = html + "<p>Credit card number: " + psa.ccNumber + "</p>";
            html = html + "<p>Authorization code: " + invoice.AuthorizationCode + "</p>";
            html = html + "<p>Total amount payable: " + invoice.PaymentAmount + "</p>";
            html = html + "<p>Packages:</p><ul>";
            foreach(var item in holder.Packages)
            {
                html = html + "<li>Package Type: " + item.PackageType + "; Weight: " + item.Weight + "; Cost: " + item.ContentValue + "</li>";
            }
            html = html + "</ul>";

            //MailMessage mail = new MailMessage();
            //SmtpClient emailServer = new SmtpClient("smtp.ust.hk");
            //mail.From = new MailAddress("comp3111_team101@cse.ust.hk", "SinEx");
            ////mail.To.Add(email);
            //mail.Subject = "Payment Invoice";
            //mail.Body = html;
            //emailServer.Send(mail);

            db.Invoices.Add(invoice);
            db.SaveChanges();
            return;

        }

        // GET: Payments
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(p => p.Shipment);
            return View(invoices.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice payment = db.Invoices.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            ViewBag.WaybillID = new SelectList(db.Shipments, "WaybillID", "ReferenceNumber");
            return View();
        }

        // POST: Payments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentID,AuthorizationCode,WaybillID,PaymentAmount,CurrencyCode,UserName,PayerCharacter,PaymentDescription")] Invoice payment)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WaybillID = new SelectList(db.Shipments, "WaybillID", "ReferenceNumber", payment.WaybillID);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice payment = db.Invoices.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.WaybillID = new SelectList(db.Shipments, "WaybillID", "ReferenceNumber", payment.WaybillID);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentID,AuthorizationCode,WaybillID,PaymentAmount,CurrencyCode,UserName,PayerCharacter,PaymentDescription")] Invoice payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WaybillID = new SelectList(db.Shipments, "WaybillID", "ReferenceNumber", payment.WaybillID);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice payment = db.Invoices.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice payment = db.Invoices.Find(id);
            db.Invoices.Remove(payment);
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
