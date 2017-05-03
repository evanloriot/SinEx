using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.Models
{
    [Table("Shipment")]
    public class Shipment
    {
        [Key]
        [Display(Name = "Waybill Number")]
        public virtual int WaybillID { get; set; }
        [Display(Name = "Ref Number")]
        public string ReferenceNumber { get; set; }
        public string ServiceType { get; set; }
        [Display(Name = "Shipped date")]
        public DateTime ShippedDate { get; set; }
        [Display(Name = "Delivery date")]
        public DateTime DeliveredDate { get; set; }
        [Display(Name = "Delivered at")]
        public string DeliveredAt { get; set; }
        [Display(Name = "Delivered to")]
        public string RecipientName { get; set; }
        [Required]
        [Display(Name = "Number of Packages")]
        public int NumberOfPackages { get; set; }
        [Required]
        [Display(Name = "Origin")]
        public string Origin { get; set; }
        [Required]
        [Display(Name = "Destination")]
        public string Destination { get; set; }
        public string Status { get; set; }
        public int ShippingAccountID { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public ICollection<ShippingAccount> ShippingAccount { get; set; }


        [Display(Name ="Recipient Shipping Account")]
        public virtual int RecipientShippingAccountID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime? PickupDate { get; set; }


        [Required]
        [Display(Name = "Tax and duty payer")]
        public virtual bool TaxPayer { get; set; }
        [Required]
        [Display(Name = "Shipment Payer")]
        public virtual bool ShipmentPayer { get; set; }
        public virtual decimal? Duty { get; set; }
        public virtual decimal? Tax { get; set; }
        [Display(Name = "Estimated total shipment cost")]
        public virtual decimal EstimatedShipmentTotalAmount { get; set; }
        [Display(Name = "Actual total shipment cost")]
        public virtual decimal ShipmentTotalAmount { get; set; }
        [Display(Name = "Shipment confirmed")]
        public virtual bool ShipmentConfirm { get; set; }
        [Display(Name = "Shipment picked up")]
        public virtual bool Pickup { get; set; }
        [Display(Name = "Shipment canceled")]
        public virtual bool Canceled { get; set; }
        [Display(Name = "Shipment delivered")]
        public virtual bool Delivered { get; set; }
    }
}
