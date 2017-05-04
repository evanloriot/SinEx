﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.ViewModels
{
    public class FeeViewModel
    {
        public virtual FeeSearchViewModel param { get; set; }

        public virtual List<FeePackageViewModel> packages { get; set; }



        [Required]
        public virtual string origin { get; set; }
        [Required]
        public virtual string destination { get; set; }
        [Required]
        public virtual string serviceType { get; set; }
        [Required]
        public virtual string currencyCode { get; set; }
        [Required]
        public virtual string RecipientName { get; set; }
        [Required]
        public virtual string RecipientAddress { get; set; }
        [Required]
        public virtual string RecipientEmail { get; set; }
    }
}