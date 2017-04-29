using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.Models
{
    public class BusinessShippingAccount : ShippingAccount
    {
        [Required]
        [Display(Name = "Contact Person Name")]
        [StringLength(70)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Name may only contain letters.")]
        public virtual string ContactPersonName { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [StringLength(40)]
        public virtual string CompanyName { get; set; }

        [Display(Name = "Department Name")]
        [StringLength(30)]
        public virtual string DepartmentName { get; set; }
    }
}