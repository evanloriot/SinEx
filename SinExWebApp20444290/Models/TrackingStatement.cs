using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.Models
{
    public class TrackingStatement
    {
        public virtual DateTime DateTime { get; set; }
        public virtual string Description { get; set; }
        public virtual string Location { get; set; }
        public virtual string Remarks { get; set; }
    }
}