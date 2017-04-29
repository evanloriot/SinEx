using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.Models
{
    public class PersonalShippingAccount : ShippingAccount
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(35)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name may only contain letters.")]
        public virtual string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(35)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name may only contain letters.")]
        public virtual string LastName { get; set; }
    }
}