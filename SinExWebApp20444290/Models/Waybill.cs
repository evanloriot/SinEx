using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SinExWebApp20444290.Models
{
    public class Waybill
    {
        public virtual int WaybillID { get; set; }
        public virtual ShippingAccount Sender { get; set; }
        public virtual int ReferenceNumber { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [StringLength(70)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Name may only contain letters.")]
        public virtual string RecipientName { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [StringLength(40)]
        public virtual string CompanyName { get; set; }

        [Display(Name = "Department Name")]
        [StringLength(30)]
        public virtual string DepartmentName { get; set; }
        
        [StringLength(50)]
        public virtual string RecipientBuilding { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Street must be alphanumeric.")]
        [StringLength(35)]
        public virtual string RecipientStreet { get; set; }

        [Required]
        [StringLength(25)]
        public virtual string RecipientCity { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Province must be alphabetic.")]
        public virtual string Province { get; set; }

        [Display(Name = "Postal Code")]
        [StringLength(6, MinimumLength = 5)]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Postal code must be numeric.")]
        public virtual string RecipientPostalCode { get; set; }

        public virtual ICollection<Shipment> Packages { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public virtual ShippingAccount ShipmentPayer { get; set; }
        public virtual ShippingAccount TaxesPayer { get; set; }
        public virtual bool EmailNotification { get; set; }
        public virtual decimal TotalCost { get; set; }
        public virtual string SystemStatus { get; set; }
        public virtual string DeliveredAt { get; set; }
        public virtual string Status { get; set; }
        public virtual ICollection<TrackingStatement> TrackingStatements { get; set; }
    }
}