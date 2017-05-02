using System;
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
        [Range(typeof(decimal), "0.01", "1000000", ErrorMessage = "Out of bound")]
        [RegularExpression(@"^[0-9]*([.][0-9]{1,2})?$", ErrorMessage = "Please input a proper decimal number(eg. 12.45)")]
        public virtual decimal ContentValue { get; set; }
        [Display(Name = "Currency")]
        public virtual string CurrencyCode { get; set; }
        [Required]
        [Display(Name = "Declared Weight")]
        [Range(typeof(decimal), "0.1", "1000", ErrorMessage = "Out of bound")]
        [RegularExpression(@"^[0-9]*([.][0-9]{1})?$", ErrorMessage = "Please input a proper decimal number. One digit behind comma(eg. 12.4")]
        public virtual decimal DeclaredWeight { get; set; }
        [Display(Name = "Actual Weight")]
        [Range(typeof(decimal), "0.1", "1000", ErrorMessage = "Out of bound")]
        [RegularExpression(@"^[0-9]*([.][0-9]{1})?$", ErrorMessage = "Please input a proper decimal number. One digit behind comma(eg. 12.4")]
        public virtual decimal? ActualWeight { get; set; }
        [Display(Name = "Declared Fee")]
        [Range(typeof(decimal), "0.01", "1000000", ErrorMessage = "Out of bound")]
        [RegularExpression(@"^[0-9]*([.][0-9]{1,2})?$", ErrorMessage = "Please input a proper decimal number(eg. 12.45)")]
        public virtual decimal DeclaredFee { get; set; }
        [Display(Name = "Actual Fee")]
        [Range(typeof(decimal), "0.01", "1000000", ErrorMessage = "Out of bound")]
        [RegularExpression(@"^[0-9]*([.][0-9]{1,2})?$", ErrorMessage = "Please input a proper decimal number(eg. 12.45)")]
        public virtual decimal? ActualFee { get; set; }

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