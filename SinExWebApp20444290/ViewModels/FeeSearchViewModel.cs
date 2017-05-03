﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SinExWebApp20444290.ViewModels
{
    public class FeeSearchViewModel
    {

        public virtual List<SelectListItem> origins { get; set; }
        public virtual List<SelectListItem> destinations { get; set; }
        public virtual List<SelectListItem> packageTypes { get; set; }
        public virtual List<SelectListItem> serviceTypes { get; set; }
        public virtual List<SelectListItem> currencies { get; set; }
        public virtual List<SelectListItem> sizes { get; set; }
    }
}