using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.ViewModels
{
    public class TrackingListViewModel
    {
        public virtual int WaybillNumber { get; set; }
        public virtual string DeliveredTo { get; set; }
        public virtual string DeliveredAt { get; set; }
        public virtual string Status { get; set; }
        public virtual string ServiceType { get; set; }

    }
}