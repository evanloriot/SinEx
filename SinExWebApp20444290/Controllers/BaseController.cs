using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinExWebApp20444290.Models;

namespace SinExWebApp20444290.Controllers
{
    public class BaseController : Controller
    {
        private SinExDatabaseContext db = new SinExDatabaseContext();

        public static int AuthorizeCreditCard(string ccNumber, string ccSecurityNumber, decimal amount)
        {
            return new Random().Next(1000, 9999);
        }

        public int GetNextWaybill()
        {
            var q = from s in db.Shipments select s;
            var holder = q.OrderByDescending(s => s.WaybillID).ToList();
            if(holder.Count == 0)
            {
                return 1;
            }
            return holder[0].WaybillID + 1;
        }

        // GET: Base
        public decimal convert(string currency, decimal amount)
        {
            if(Session[currency] == null)
            {
                var currencies = db.Currencies.ToList();
                foreach(var item in currencies)
                {
                    Session[item.CurrencyCode] = item.ExchangeRate;
                }
            }
            return amount * (Decimal)(Session[currency]);
        }
        public decimal convertUseless(string currency, decimal amount)
        {
            double rate;
            switch (currency)
            {
                case "HKD" :
                    rate = 1.13;
                    break;
                case "MOP":
                    rate = 1.16;
                    break;
                case "TWD":
                    rate = 4.56;
                    break;
                default:
                    rate = 1.00;
                    break;
            }
            return amount * (Decimal) rate;
        }
    }
}