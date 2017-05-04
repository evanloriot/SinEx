using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using SinExWebApp20444290.Models;

namespace SinExWebApp20444290.ViewModels
{
    public class FeePackageViewModel
    {
        public virtual ServicePackageFee result { get; set; }
        public virtual string packageType { get; set; }
        public virtual string size { get; set; }
        public virtual decimal weight { get; set; }
        public virtual bool penalty { get; set; }
        public virtual decimal fee { get; set; }
        public virtual int limit { get; set; }
    }
}