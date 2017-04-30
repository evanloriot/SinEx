using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.ViewModels
{
    public class ShipmentsListViewModel
    {
        public int WaybillID { get; set; }
        public string ServiceType { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public string RecipientName { get; set; }
        public int NumberOfPackages { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int ShippingAccountID { get; set; }
    }
}