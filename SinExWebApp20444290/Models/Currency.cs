using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.Models
{
    [Table("Currency")]
    public class Currency
    {
        [Key]
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public virtual ICollection<Destination> Destination { get; set; }
    }
}