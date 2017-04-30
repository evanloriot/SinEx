using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.Models
{
    [Table("PackageType")]
    public class PackageType
    {
        public virtual int PackageTypeID { get; set; }
        public virtual string Type { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<ServicePackageFee> ServicePackageFee { get; set; }
        public virtual ICollection<PackageTypeSize> PackageTypeSize { get; set; }
    }
}