﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinExWebApp20444290.Models
{
    [Table("Package")]
    public class Package
    {
        [Display(Name = "Package Shipping ID")]
        public virtual int PackageID { get; set; }
        [Display(Name = "Waybill ID")]
        public virtual int WaybillID { get; set; }
        [Display(Name = "Package Type")]
        public virtual int PackageTypeID { get; set; }
        [Display(Name = "Package Type Size")]
        public virtual int PackageTypeSizeID { get; set; }
        [Display(Name = "Description")]
        public virtual string Description { get; set; }
        [Display(Name = "Content Value")]
        public virtual decimal ContentValue { get; set; }
        [Display(Name = "Currency")]
        public virtual string CurrencyCode { get; set; }
        [Display(Name = "Weight")]
        public virtual decimal? Weight { get; set; }
        public virtual bool Weighed { get; set; }
        [Display(Name = "Fee")]
        public virtual decimal? Fee { get; set; }
        [Display(Name = "Service Type")]
        public virtual int ServiceTypeID { get; set; }

        [ForeignKey("WaybillID")]
        public virtual Shipment Shipment { get; set; }
        [ForeignKey("PackageTypeID")]
        public virtual PackageType PackageType { get; set; }
        [ForeignKey("PackageTypeSizeID")]
        public virtual PackageTypeSize PackageTypeSize { get; set; }
        [ForeignKey("CurrencyCode")]
        public virtual Currency Currency { get; set; }
    }
}