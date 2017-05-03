﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinExWebApp20444290.Models;
using SinExWebApp20444290.ViewModels;

namespace SinExWebApp20444290.Controllers
{
    public class CalculateController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        // GET: Calculate
        public ActionResult Index()
        {
            FeeViewModel Calculator = new FeeViewModel();
            Calculator.param = new FeeSearchViewModel();
            //populate dropdownlists
            Calculator.param.origins = PopulateCitiesDropdownlist().ToList();
            Calculator.param.destinations = PopulateCitiesDropdownlist().ToList();
            Calculator.param.packageTypes = PopulatePackageTypesDropdownlist().ToList();
            Calculator.param.serviceTypes = PopulateServiceTypesDropdownlist().ToList();
            Calculator.param.currencies = PopulateCurrenciesDropdownlist().ToList();
            Calculator.param.sizes = new List<SelectListItem>();
            Calculator.packages = new List<FeePackageViewModel>();
            Calculator.packages.Add(new FeePackageViewModel());
            //populate size dropdownlist

            Calculator.param.sizes = new List<SelectListItem>();
            return View(Calculator);
        }

        // POST: Currencies/Index
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "packages,origin,destination,serviceType,currencyCode,param")] FeeViewModel Calculator)
        {
            if (ModelState.IsValid)
            {
                decimal rate = db.Currencies.Where(a => a.CurrencyCode == Calculator.currencyCode).Select(a => a.ExchangeRate).First();
                foreach (FeePackageViewModel package in Calculator.packages)
                {
                    string limitString = db.PackageTypeSizes.Where(a => a.Description == package.size).Select(a => a).First().WeightLimit;
                    package.limit = limitString;
                    package.weight = Math.Round((decimal)package.weight, 1);
                    package.result = db.ServicePackageFees.SingleOrDefault(a => a.PackageType.Type == package.packageType && a.ServiceType.Type == Calculator.serviceType);
                    decimal price = 0;
                    package.penalty = false;
                    switch (package.result.PackageTypeID)
                    {
                        //Envelope
                        case 1:
                            price = package.result.Fee;
                            break;
                        //Pak or Box
                        case 2:
                        case 4:
                            price = package.weight * package.result.Fee > package.result.MinimumFee ? (decimal)package.weight * package.result.Fee : package.result.MinimumFee;
                            // weight limit
                            int limit = 0;
                            bool convertResult = Int32.TryParse(limitString.Substring(0, limitString.Length - 2), out limit);
                            if (limit != 0 && convertResult == true && package.weight > (decimal)limit)
                            {
                                price += 500;
                                package.penalty = true;
                            }
                            break;
                        //Tube
                        case 3:
                            price = package.weight * package.result.Fee > package.result.MinimumFee ? (decimal)package.weight * package.result.Fee : package.result.MinimumFee;
                            break;
                        //Customer
                        case 5:
                            price = package.weight * package.result.Fee > package.result.MinimumFee ? (decimal)package.weight * package.result.Fee : package.result.MinimumFee;
                            break;
                    }
                    package.fee = price * rate;
                }
                return View("Result", Calculator);
            }

            Calculator.param = new FeeSearchViewModel();
            //populate dropdownlists
            Calculator.param.origins = PopulateCitiesDropdownlist().ToList();
            Calculator.param.destinations = PopulateCitiesDropdownlist().ToList();
            Calculator.param.packageTypes = PopulatePackageTypesDropdownlist().ToList();
            Calculator.param.serviceTypes = PopulateServiceTypesDropdownlist().ToList();
            Calculator.param.currencies = PopulateCurrenciesDropdownlist().ToList();
            Calculator.param.sizes = new List<SelectListItem>();

            return View("Index", Calculator);
        }

        private SelectList PopulateCitiesDropdownlist()
        {
            var Query = db.Destinations.Select(a => a.City).Distinct().OrderBy(a => a);
            return new SelectList(Query);
        }

        private SelectList PopulatePackageTypesDropdownlist()
        {
            var Query = db.PackageTypes.Select(a => a.Type).Distinct().OrderBy(a => a);
            return new SelectList(Query);
        }

        private SelectList PopulateServiceTypesDropdownlist()
        {
            var Query = db.ServiceTypes.Select(a => a.Type).Distinct().OrderBy(a => a);
            return new SelectList(Query);
        }

        private SelectList PopulatePackageTypeSizesDropdownlist(string packageType)
        {
            var Query = db.PackageTypeSizes.Where(a => a.PackageType.Type == packageType).Select(a => a.Description);
            return new SelectList(Query);
        }

        private SelectList PopulateCurrenciesDropdownlist()
        {
            var Query = db.Currencies.Select(a => a.CurrencyCode).Distinct().OrderBy(a => a);
            return new SelectList(Query);
        }

        public ActionResult GetSizes(string packageType)
        {
            if (String.IsNullOrEmpty(packageType))
            {
                return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
            }

            var query = db.PackageTypeSizes.Where(a => a.PackageType.Type == packageType).Select(a => a.Description);
            List<SelectListItem> data = new SelectList(query).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSizesByID(int? packageTypeID)
        {
            if (packageTypeID == null)
            {
                return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
            }

            var query = db.PackageTypeSizes.Where(a => a.PackageType.PackageTypeID == packageTypeID);
            List<SelectListItem> data = new SelectList(query, "PackageTypeSizeID", "TypeSize").ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}