using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinExWebApp20444290.ViewModels
{
    public class ShipmentsSearchViewModel
    {
        public int ShippingAccountID { get; set; }
        public DateTime StartShippedDate { get; set; }
        public DateTime EndShippedDate { get; set; }
        public List<SelectListItem> ShippingAccounts { get; set; }
    }
}