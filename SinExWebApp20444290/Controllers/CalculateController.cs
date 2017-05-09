using System;
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
            //Calculator.param.sizes = PopulatePackageTypeSizesDropdownlist().ToList();
            Calculator.packages = new List<FeePackageViewModel>();
            Calculator.packages.Add(new FeePackageViewModel());
            //populate size dropdownlist

            Calculator.param.sizes = PopulatePackageTypeSizesDropdownlist();
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
                decimal exchangeRate = db.Currencies.Where(s => s.CurrencyCode == Calculator.currencyCode).Select(s => s.ExchangeRate).First();
                foreach (FeePackageViewModel package in Calculator.packages)
                {
                    //string limitString = db.PackageTypeSizes.Where(a => a.Description == package.packageType).Select(a => a).First().WeightLimit;
                    int limitString = 30;
                    //package.limit = Int32.Parse(limitString);
                    package.limit = limitString;
                    package.weight = Math.Round((decimal)package.weight, 1);
                    
                    package.result = db.ServicePackageFees.SingleOrDefault(s => s.PackageType.Type == package.packageType && s.ServiceType.Type == Calculator.serviceType);
                    decimal fee = 0;
                    package.penalty = false;
                    switch (package.result.PackageTypeID)
                    {
                        //Envelope
                        case 1:
                            fee = package.result.Fee;
                            break;
                        //Pak
                        case 2:
                            if (package.weight * package.result.Fee > package.result.MinimumFee)
                            {
                                fee = (decimal)package.weight * package.result.Fee;
                                if (package.weight > package.limit) //Oversized Packaged
                                {
                                    fee += 500;
                                    package.penalty = true;
                                }                          
                            }
                            else //Under the minimum weight
                            {
                                fee = package.result.MinimumFee;
                            }
                            break;
                        //Tube
                        case 3:
                            if (package.weight * package.result.Fee > package.result.MinimumFee)
                            {
                                fee = (decimal)package.weight * package.result.Fee;
                            }
                            else
                            {
                                fee = package.result.MinimumFee;
                            }
                            break;
                        //Box
                        case 4:
                            if (package.weight * package.result.Fee > package.result.MinimumFee)
                            {
                                fee = (decimal)package.weight * package.result.Fee;
                                if (package.weight > package.limit) //Oversized Packaged
                                {
                                    fee += 500;
                                    package.penalty = true;
                                }
                            }
                            else //Under the minimum weight
                            {
                                fee = package.result.MinimumFee;
                            }
                            break;
                        //Customer
                        case 5:
                            if (package.weight * package.result.Fee > package.result.MinimumFee)
                            {
                                fee = (decimal)package.weight * package.result.Fee;
                            }
                            else
                            {
                                fee = package.result.MinimumFee;
                            }
                            break;
                        default:
                            fee = 0;
                            break;
                    }
                    package.fee = fee * exchangeRate;
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
            //Calculator.param.sizes = PopulatePackageTypeSizesDropdownlist().ToList();
            Calculator.param.sizes = PopulatePackageTypeSizesDropdownlist();

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

        private SelectList PopulatePackageTypeSizesDropdownlist()
        {
            var query = db.PackageTypeSizes.Select(a => a.Description);
            return new SelectList(query);
        }

        private SelectList PopulateCurrenciesDropdownlist()
        {
            var Query = db.Currencies.Select(a => a.CurrencyCode).Distinct().OrderBy(a => a);
            return new SelectList(Query);
        }
    }
}