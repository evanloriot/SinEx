using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinExWebApp20444290.ViewModels
{
    public class ShipmentsReportViewModel
    {
        public ShipmentsSearchViewModel Shipment { get; set; }
        public IPagedList<ShipmentsListViewModel> Shipments { get; set; }
    }
}