using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.Models
{
    [Table("Destination")]
    public class Destination
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string ProvinceCode { get; set; }
        public virtual Currency Currency { get; set; }
    }
}