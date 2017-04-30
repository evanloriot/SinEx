using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SinExWebApp20444290.Models
{
    public class Recipient
    {
        public virtual int RecipientID { get; set; }
        public virtual int ShippingAccountID { get; set; }
        public virtual ShippingAccount ShippingAccount { get; set; }
        public virtual string Nickname { get; set; }

        [StringLength(50)]
        public virtual string Building { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "Street must be alphanumeric.")]
        [StringLength(35)]
        public virtual string Street { get; set; }

        [Required]
        [StringLength(25)]
        public virtual string City { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Province must be alphabetic.")]
        public virtual string Province { get; set; }

        [Display(Name = "Postal Code")]
        [StringLength(6, MinimumLength = 5)]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Postal code must be numeric.")]
        public virtual string PostalCode { get; set; }
    }
}