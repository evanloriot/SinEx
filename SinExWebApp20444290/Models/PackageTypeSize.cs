using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.Models
{
    [Table("PackageTypeSize")]
    public class PackageTypeSize
    {
        public int PackageTypeSizeID { get; set; }
        public string Description { get; set; }
        public int PackageTypeID { get; set; }
        public PackageType PackageType { get; set; }
    }
}