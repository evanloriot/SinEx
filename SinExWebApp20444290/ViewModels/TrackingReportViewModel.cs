using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SinExWebApp20444290.Models;

namespace SinExWebApp20444290.ViewModels
{
    public class TrackingReportViewModel
    {
        public virtual Shipment Shipment { get; set; }
        public virtual IEnumerable<TrackingStatement> TrackingStatements { get; set; }
    }
}