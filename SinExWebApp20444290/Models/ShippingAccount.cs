using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.Models
{
    public enum CCType
    {
        [Display(Name = "American Express")]
        AmericanExpress,
        [Display(Name = "Diners Club")]
        DinersClub,
        Discover,
        MasterCard,
        UinionPay,
        Visa
    }

    [Table("ShippingAccount")]
    public abstract class ShippingAccount
    {
        [StringLength(10)]
        public virtual string UserName { get; set; }

        [StringLength(15, MinimumLength = 8)]
        public virtual string Password { get; set; }

        public virtual int ShippingAccountID { get; set; }
        
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

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(14, MinimumLength = 8)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number must be numeric.")]
        public virtual string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        public virtual string Email { get; set; }

        [Required]
        [Display(Name = "Type")]
        public virtual CCType ccType { get; set; }

        [Required]
        [Display(Name = "Number")]
        [DataType(DataType.CreditCard)]
        [StringLength(19, MinimumLength = 14)]
        public virtual string ccNumber { get; set; }

        [Required]
        [Display(Name = "Security Number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Security number must be numeric.")]
        [StringLength(4, MinimumLength = 3)]
        public virtual string ccSecurityNumber { get; set; }

        [Required]
        [Display(Name = "Cardholder Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Cardholder name may only contain letters.")]
        [StringLength(70)]
        public virtual string ccHolderName { get; set; }

        [Required]
        [Display(Name = "Expiry Month")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Expiration month must be numeric.")]
        [StringLength(2, MinimumLength = 2)]
        [Range(1,12)]
        public virtual string ccExpirationMonth { get; set; }

        [Required]
        [Display(Name = "Expiry Year")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Expiration year must be numeric.")]
        [StringLength(2, MinimumLength = 2)]
        public virtual string ccExpirationYear { get; set; }
    }
}