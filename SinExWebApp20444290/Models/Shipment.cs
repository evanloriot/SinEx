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
        public virtual int WaybillID { get; set; }
        public string ReferenceNumber { get; set; }
        public string ServiceType { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public string RecipientName { get; set; }
        public int NumberOfPackages { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Status { get; set; }
        public int ShippingAccountID { get; set; }
        public ICollection<ShippingAccount> ShippingAccount { get; set; }
    }
}