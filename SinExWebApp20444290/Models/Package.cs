using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinExWebApp20444290.Models
{
    public class Package
    {
        [Key]
        public virtual int PackageID { get; set; }
        public virtual int WaybillID { get; set; }
        [ForeignKey("WaybillID")]
        public virtual Shipment Shipment { get; set; }
        public virtual string PackageType { get; set; }
        public virtual decimal Weight { get; set; }
    }
}