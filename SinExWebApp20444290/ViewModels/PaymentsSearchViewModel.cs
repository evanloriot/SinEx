﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinExWebApp20444290.ViewModels
{
    public class PaymentsSearchViewModel
    {

        public virtual int ShippingAccountId { get; set; }
        public virtual List<SelectListItem> ShippingAccounts { get; set; }

        public virtual DateTime StartingDate { get; set; }
        public virtual DateTime EndingDate { get; set; }
    }
}