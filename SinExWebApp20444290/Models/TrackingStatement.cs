using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SinExWebApp20444290.Models
{
    public class TrackingStatement
    {
        [Key]
        public virtual int TrackingID { get; set; }
        public virtual int WaybillID { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual string Description { get; set; }
        public virtual string Location { get; set; }
        public virtual string Remarks { get; set; }
    }
}