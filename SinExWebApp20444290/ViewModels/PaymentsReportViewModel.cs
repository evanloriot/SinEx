﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace SinExWebApp20444290.ViewModels
{
    public class PaymentsReportViewModel
    {
        public virtual PaymentsSearchViewModel PaymentSearch { get; set; }
        public virtual IPagedList<PaymentsListViewModel> PaymentList { get; set; }
    }
}