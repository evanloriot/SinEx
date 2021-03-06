namespace SinExWebApp20444290.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class SinExConfiguration : DbMigrationsConfiguration<SinExWebApp20444290.Models.SinExDatabaseContext>
    {
        public SinExConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SinExWebApp20444290.Models.SinExDatabaseContext";
        }

        protected override void Seed(SinExWebApp20444290.Models.SinExDatabaseContext context)
        {
            //// Add package type data.
            //context.PackageTypes.AddOrUpdate(
            //    p => p.PackageTypeID,
            //    new PackageType { PackageTypeID = 1, Type = "Envelope", Description = "for correspondence and documents only with no commercial value", Size = "250x350mm" },
            //    new PackageType { PackageTypeID = 2, Type = "Pak", Description = "for flat, non-breakable articles including heavy documents", Size = " small - 350x400mm" },
            //    new PackageType { PackageTypeID = 2, Type = "Pak", Description = "for flat, non-breakable articles including heavy documents", Size = " large - 450x550mm" },
            //    new PackageType { PackageTypeID = 3, Type = "Tube", Description = "for larger documents, such as blueprints, which should be rolled rather than folded", Size = "Size: 1000x80mm" },
            //    new PackageType { PackageTypeID = 4, Type = "Box", Description = "for bulky items, such as electronic parts and textile samples", Size = "small - 300x250x150mm" },
            //    new PackageType { PackageTypeID = 4, Type = "Box", Description = "for bulky items, such as electronic parts and textile samples", Size = "medium - 400x350x250mm" },
            //    new PackageType { PackageTypeID = 4, Type = "Box", Description = "for bulky items, such as electronic parts and textile samples", Size = "large - 500x450x350mm" },
            //    new PackageType { PackageTypeID = 5, Type = "Customer", Description = "for packaging provided by customer" }
            //);

            //// Add service type data.
            //context.ServiceTypes.AddOrUpdate(
            //    p => p.ServiceTypeID,
            //    new ServiceType { ServiceTypeID = 1, Type = "Same Day", CutoffTime = "10:00 a.m.", DeliveryTime = "Same day" },
            //    new ServiceType { ServiceTypeID = 2, Type = "Next Day 10:30", CutoffTime = "3:00 p.m.", DeliveryTime = "Next day 10:30 a.m." },
            //    new ServiceType { ServiceTypeID = 3, Type = "Next Day 12:00", CutoffTime = "6:00 p.m.", DeliveryTime = "Next day 12:00 p.m." },
            //    new ServiceType { ServiceTypeID = 4, Type = "Next Day 15:00", CutoffTime = "9:00 p.m.", DeliveryTime = "Next day 15:00 p.m." },
            //    new ServiceType { ServiceTypeID = 5, Type = "2nd Day", CutoffTime = "", DeliveryTime = "5:00 p.m. second business day" },
            //    new ServiceType { ServiceTypeID = 6, Type = "Ground", CutoffTime = "", DeliveryTime = "1 to 5 business days" }
            //);

            //// Add service and package type fees.
            //context.ServicePackageFees.AddOrUpdate(
            //    p => p.ServicePackageFeeID,
            //    // Same Day
            //    new ServicePackageFee { ServicePackageFeeID = 1, Fee = 160, MinimumFee = 160, ServiceTypeID = 1, PackageTypeID = 1 }, // Envelope
            //    new ServicePackageFee { ServicePackageFeeID = 2, Fee = 100, MinimumFee = 160, ServiceTypeID = 1, PackageTypeID = 2 }, // Pak
            //    new ServicePackageFee { ServicePackageFeeID = 3, Fee = 100, MinimumFee = 160, ServiceTypeID = 1, PackageTypeID = 3 }, // Tube
            //    new ServicePackageFee { ServicePackageFeeID = 4, Fee = 110, MinimumFee = 160, ServiceTypeID = 1, PackageTypeID = 4 }, // Box
            //    new ServicePackageFee { ServicePackageFeeID = 5, Fee = 110, MinimumFee = 160, ServiceTypeID = 1, PackageTypeID = 5 }, // Customer
            //                                                                                                                          // Next Day 10:30
            //    new ServicePackageFee { ServicePackageFeeID = 6, Fee = 140, MinimumFee = 140, ServiceTypeID = 2, PackageTypeID = 1 }, // Envelope
            //    new ServicePackageFee { ServicePackageFeeID = 7, Fee = 90, MinimumFee = 140, ServiceTypeID = 2, PackageTypeID = 2 }, // Pak
            //    new ServicePackageFee { ServicePackageFeeID = 8, Fee = 90, MinimumFee = 140, ServiceTypeID = 2, PackageTypeID = 3 }, // Tube
            //    new ServicePackageFee { ServicePackageFeeID = 9, Fee = 99, MinimumFee = 100, ServiceTypeID = 2, PackageTypeID = 4 }, // Box
            //    new ServicePackageFee { ServicePackageFeeID = 10, Fee = 99, MinimumFee = 140, ServiceTypeID = 2, PackageTypeID = 5 }, // Customer
            //                                                                                                                          // Next Day 12:00
            //    new ServicePackageFee { ServicePackageFeeID = 11, Fee = 130, MinimumFee = 130, ServiceTypeID = 3, PackageTypeID = 1 }, // Envelope
            //    new ServicePackageFee { ServicePackageFeeID = 12, Fee = 80, MinimumFee = 130, ServiceTypeID = 3, PackageTypeID = 2 }, // Pak
            //    new ServicePackageFee { ServicePackageFeeID = 13, Fee = 80, MinimumFee = 130, ServiceTypeID = 3, PackageTypeID = 3 }, // Tube
            //    new ServicePackageFee { ServicePackageFeeID = 14, Fee = 88, MinimumFee = 130, ServiceTypeID = 3, PackageTypeID = 4 }, // Box
            //    new ServicePackageFee { ServicePackageFeeID = 15, Fee = 88, MinimumFee = 130, ServiceTypeID = 3, PackageTypeID = 5 }, // Customer
            //                                                                                                                          // Next Day 15:00
            //    new ServicePackageFee { ServicePackageFeeID = 16, Fee = 120, MinimumFee = 120, ServiceTypeID = 4, PackageTypeID = 1 }, // Envelope
            //    new ServicePackageFee { ServicePackageFeeID = 17, Fee = 70, MinimumFee = 120, ServiceTypeID = 4, PackageTypeID = 2 }, // Pak
            //    new ServicePackageFee { ServicePackageFeeID = 18, Fee = 70, MinimumFee = 120, ServiceTypeID = 4, PackageTypeID = 3 }, // Tube
            //    new ServicePackageFee { ServicePackageFeeID = 19, Fee = 77, MinimumFee = 120, ServiceTypeID = 4, PackageTypeID = 4 }, // Box
            //    new ServicePackageFee { ServicePackageFeeID = 20, Fee = 77, MinimumFee = 120, ServiceTypeID = 4, PackageTypeID = 5 }, // Customer
            //                                                                                                                          // 2nd Day
            //    new ServicePackageFee { ServicePackageFeeID = 21, Fee = 50, MinimumFee = 50, ServiceTypeID = 5, PackageTypeID = 1 }, // Envelope
            //    new ServicePackageFee { ServicePackageFeeID = 22, Fee = 50, MinimumFee = 50, ServiceTypeID = 5, PackageTypeID = 2 }, // Pak
            //    new ServicePackageFee { ServicePackageFeeID = 23, Fee = 50, MinimumFee = 50, ServiceTypeID = 5, PackageTypeID = 3 }, // Tube
            //    new ServicePackageFee { ServicePackageFeeID = 24, Fee = 55, MinimumFee = 55, ServiceTypeID = 5, PackageTypeID = 4 }, // Box
            //    new ServicePackageFee { ServicePackageFeeID = 25, Fee = 55, MinimumFee = 55, ServiceTypeID = 5, PackageTypeID = 5 }, // Customer
            //                                                                                                                         // Ground
            //    new ServicePackageFee { ServicePackageFeeID = 26, Fee = 25, MinimumFee = 25, ServiceTypeID = 6, PackageTypeID = 1 },// Envelope
            //    new ServicePackageFee { ServicePackageFeeID = 27, Fee = 25, MinimumFee = 25, ServiceTypeID = 6, PackageTypeID = 2 }, // Pak
            //    new ServicePackageFee { ServicePackageFeeID = 28, Fee = 25, MinimumFee = 25, ServiceTypeID = 6, PackageTypeID = 3 }, // Tube
            //    new ServicePackageFee { ServicePackageFeeID = 29, Fee = 30, MinimumFee = 30, ServiceTypeID = 6, PackageTypeID = 4 }, // Box
            //    new ServicePackageFee { ServicePackageFeeID = 30, Fee = 30, MinimumFee = 30, ServiceTypeID = 6, PackageTypeID = 5 }  // Customer
            //);

            ////Add currency type data.
            //context.Currencies.AddOrUpdate(
            //    p => p.CurrencyCode,
            //    new Currency { CurrencyCode = "CNY", ExchangeRate = 1.00m },
            //    new Currency { CurrencyCode = "HKD", ExchangeRate = 1.13m },
            //    new Currency { CurrencyCode = "MOP", ExchangeRate = 1.16m },
            //    new Currency { CurrencyCode = "TWD", ExchangeRate = 4.56m }
            //);

            ////Add destination type data.
            //context.Destinations.AddOrUpdate(
            //    p => p.DestinationID,
            //    new Destination { City = "Beijing", ProvinceCode = "BJ" },
            //    new Destination { City = "Changchun", ProvinceCode = "JL" },
            //    new Destination { City = "Changsha", ProvinceCode = "HN" },
            //    new Destination { City = "Chengdu", ProvinceCode = "SC" },
            //    new Destination { City = "Chongqing", ProvinceCode = "CQ" },
            //    new Destination { City = "Fuzhou", ProvinceCode = "JX" },
            //    new Destination { City = "Golmud", ProvinceCode = "QH" },
            //    new Destination { City = "Guangzhou", ProvinceCode = "GD" },
            //    new Destination { City = "Guiyang", ProvinceCode = "GZ" },
            //    new Destination { City = "Haikou", ProvinceCode = "HI" },
            //    new Destination { City = "Hailar", ProvinceCode = "NM" },
            //    new Destination { City = "Hangzhou", ProvinceCode = "ZJ" },
            //    new Destination { City = "Harbin", ProvinceCode = "HL" },
            //    new Destination { City = "Hefei", ProvinceCode = "AH" },
            //    new Destination { City = "Hohhot", ProvinceCode = "NM" },
            //    new Destination { City = "Hong Kong", ProvinceCode = "HK" },
            //    new Destination { City = "Hulun Buir", ProvinceCode = "NM" },
            //    new Destination { City = "Jinan", ProvinceCode = "SD" },
            //    new Destination { City = "Kashi", ProvinceCode = "XJ" },
            //    new Destination { City = "Kunming", ProvinceCode = "YN" },
            //    new Destination { City = "Lanzhou", ProvinceCode = "GS" },
            //    new Destination { City = "Lhasa", ProvinceCode = "XZ" },
            //    new Destination { City = "Macau", ProvinceCode = "MC" },
            //    new Destination { City = "Nanchang", ProvinceCode = "JX" },
            //    new Destination { City = "Nanjing", ProvinceCode = "JS" },
            //    new Destination { City = "Nanning", ProvinceCode = "JX" },
            //    new Destination { City = "Qiqihar", ProvinceCode = "HL" },
            //    new Destination { City = "Shanghai", ProvinceCode = "SH" },
            //    new Destination { City = "Shenyang", ProvinceCode = "LN" },
            //    new Destination { City = "Shijiazhuang", ProvinceCode = "HE" },
            //    new Destination { City = "Taipei", ProvinceCode = "TW" },
            //    new Destination { City = "Taiyuan", ProvinceCode = "SX" },
            //    new Destination { City = "Tianjin", ProvinceCode = "HE" },
            //    new Destination { City = "Urumqi", ProvinceCode = "XJ" },
            //    new Destination { City = "Wuhan", ProvinceCode = "HB" },
            //    new Destination { City = "Xi'an", ProvinceCode = "SN" },
            //    new Destination { City = "Xining", ProvinceCode = "QH" },
            //    new Destination { City = "Yinchuan", ProvinceCode = "NX" },
            //    new Destination { City = "Yumen", ProvinceCode = "GS" },
            //    new Destination { City = "Zhengzhou", ProvinceCode = "HA" }
            //);

            ////Add package type size data.
            //context.PackageTypeSizes.AddOrUpdate(
            //    p => p.PackageTypeSizeID,
            //    new PackageTypeSize { Description = "(Size: 250x350mm; Weight limit: Not Applicable)", PackageTypeID = 1 },
            //    new PackageTypeSize { Description = "(Size: small - 350x400mm; Weight limit: 5kg)", PackageTypeID = 2 },
            //    new PackageTypeSize { Description = "(Size: large - 450x550mm; Weight limit: 5kg)", PackageTypeID = 2 },
            //    new PackageTypeSize { Description = "(Size: 1000x80mm; Weight limit: Not Applicable)", PackageTypeID = 3 },
            //    new PackageTypeSize { Description = "(Size: small - 300x250x150mm; Weight limit: 10kg)", PackageTypeID = 4 },
            //    new PackageTypeSize { Description = "(Size: medium - 400x350x250mm; Weight limit: 20kg)", PackageTypeID = 4 },
            //    new PackageTypeSize { Description = "(Size: large - 500x450x350mm; Weight limit: 30kg)", PackageTypeID = 4 }
            //);

            //// Add shipment data.
            //context.Shipments.AddOrUpdate(
            //    p => p.WaybillID,
            //    new Shipment { WaybillID = 1, ReferenceNumber = "", ServiceType = "Same Day", ShippedDate = new DateTime(2016, 11, 11), DeliveredDate = new DateTime(2016, 11, 11), RecipientName = "Andy Ho", NumberOfPackages = 1, Origin = "Hong Kong", Destination = "Guangzhou", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 2, ReferenceNumber = "A28756", ServiceType = "Same Day", ShippedDate = new DateTime(2016, 12, 12), DeliveredDate = new DateTime(2016, 12, 12), RecipientName = "John Wong", NumberOfPackages = 2, Origin = "Hong Kong", Destination = "Macau", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 3, ReferenceNumber = "", ServiceType = "Next Day 10:30", ShippedDate = new DateTime(2016, 12, 31), DeliveredDate = new DateTime(2017, 01, 01), RecipientName = "John Wong", NumberOfPackages = 1, Origin = "Hong Kong", Destination = "Beijing", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 4, ReferenceNumber = "", ServiceType = "Next Day 10:30", ShippedDate = new DateTime(2016, 11, 30), DeliveredDate = new DateTime(2016, 12, 01), RecipientName = "Daisy Chan", NumberOfPackages = 3, Origin = "Hong Kong", Destination = "Shanghai", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 5, ReferenceNumber = "", ServiceType = "Next Day 12:00", ShippedDate = new DateTime(2016, 11, 17), DeliveredDate = new DateTime(2016, 11, 18), RecipientName = "Daisy Chan", NumberOfPackages = 1, Origin = "Hong Kong", Destination = "Kashi", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 6, ReferenceNumber = "", ServiceType = "Ground", ShippedDate = new DateTime(2016, 12, 16), DeliveredDate = new DateTime(2016, 12, 15), RecipientName = "Harry Lee", NumberOfPackages = 1, Origin = "Hong Kong", Destination = "Harbin", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 7, ReferenceNumber = "45236", ServiceType = "2nd Day", ShippedDate = new DateTime(2017, 01, 14), DeliveredDate = new DateTime(2017, 01, 16), RecipientName = "John Wong", NumberOfPackages = 2, Origin = "Hong Kong", Destination = "Changchun", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 8, ReferenceNumber = "", ServiceType = "Next Day", ShippedDate = new DateTime(2016, 10, 19), DeliveredDate = new DateTime(2016, 10, 20), RecipientName = "Lisa Li", NumberOfPackages = 1, Origin = "Beijing", Destination = "Haikou", Status = "Delivered", ShippingAccountID = 2, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 9, ReferenceNumber = "", ServiceType = "Same Day", ShippedDate = new DateTime(2016, 11, 04), DeliveredDate = new DateTime(2016, 11, 05), RecipientName = "Yolanda Yu", NumberOfPackages = 1, Origin = "Beijing", Destination = "Hangzhou", Status = "Delivered", ShippingAccountID = 2, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 10, ReferenceNumber = "", ServiceType = "Next Day", ShippedDate = new DateTime(2017, 02, 02), DeliveredDate = new DateTime(2017, 02, 03), RecipientName = "Yolanda Yu", NumberOfPackages = 2, Origin = "Beijing", Destination = "Jinan", Status = "Delivered", ShippingAccountID = 2, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 11, ReferenceNumber = "66543", ServiceType = "Ground", ShippedDate = new DateTime(2017, 01, 23), DeliveredDate = new DateTime(2017, 01, 26), RecipientName = "Arnold Au", NumberOfPackages = 3, Origin = "Beijing", Destination = "Guangzhou", Status = "Delivered", ShippingAccountID = 2, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 12, ReferenceNumber = "", ServiceType = "Next Day 12:00", ShippedDate = new DateTime(2016, 12, 18), DeliveredDate = new DateTime(2016, 12, 19), RecipientName = "Andrew Li", NumberOfPackages = 1, Origin = "Nanjing", Destination = "Beijing", Status = "Delivered", ShippingAccountID = 3, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 13, ReferenceNumber = "", ServiceType = "2nd Day", ShippedDate = new DateTime(2017, 01, 07), DeliveredDate = new DateTime(2017, 01, 09), RecipientName = "Amelia Auyeung", NumberOfPackages = 1, Origin = "Nanjing", Destination = "Kunming", Status = "Delivered", ShippingAccountID = 3, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 14, ReferenceNumber = "887564", ServiceType = "Next Day 15:00", ShippedDate = new DateTime(2017, 02, 02), DeliveredDate = new DateTime(2017, 02, 03), RecipientName = "Amanda Au", NumberOfPackages = 2, Origin = "Nanjing", Destination = "Beijing", Status = "Delivered", ShippingAccountID = 3, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 15, ReferenceNumber = "", ServiceType = "Ground", ShippedDate = new DateTime(2017, 01, 13), DeliveredDate = new DateTime(2017, 01, 20), RecipientName = "John Wong", NumberOfPackages = 1, Origin = "Hong Kong", Destination = "Nanning", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 16, ReferenceNumber = "348712", ServiceType = "Next Day 12:00", ShippedDate = new DateTime(2016, 12, 03), DeliveredDate = new DateTime(2016, 12, 04), RecipientName = "Derek Chan", NumberOfPackages = 5, Origin = "Haikou", Destination = "Hong Kong", Status = "Delivered", ShippingAccountID = 4, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 17, ReferenceNumber = "", ServiceType = "2nd Day", ShippedDate = new DateTime(2017, 02, 10), DeliveredDate = new DateTime(2017, 02, 12), RecipientName = "Kelly Kwong", NumberOfPackages = 6, Origin = "Hong Kong", Destination = "Golmud", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 18, ReferenceNumber = "", ServiceType = "Same Day", ShippedDate = new DateTime(2017, 01, 18), DeliveredDate = new DateTime(2017, 01, 18), RecipientName = "Wendy Wang", NumberOfPackages = 4, Origin = "Hong Kong", Destination = "Hohhot", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 19, ReferenceNumber = "", ServiceType = "2nd Day", ShippedDate = new DateTime(2017, 02, 06), DeliveredDate = new DateTime(2017, 02, 08), RecipientName = "Larry Leung", NumberOfPackages = 2, Origin = "Guangzhou", Destination = "Hong Kong", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 20, ReferenceNumber = "22233398", ServiceType = "Next Day 15:00", ShippedDate = new DateTime(2016, 10, 09), DeliveredDate = new DateTime(2016, 10, 10), RecipientName = "Larry Leung", NumberOfPackages = 1, Origin = "Beijing", Destination = "Hong Kong", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 21, ReferenceNumber = "", ServiceType = "Same Day", ShippedDate = new DateTime(2016, 12, 04), DeliveredDate = new DateTime(2016, 12, 04), RecipientName = "Vincent Zhang", NumberOfPackages = 2, Origin = "Hulun Buir", Destination = "Lhasa", Status = "Delivered", ShippingAccountID = 4, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 22, ReferenceNumber = "336723", ServiceType = "Ground", ShippedDate = new DateTime(2017, 02, 08), DeliveredDate = new DateTime(2017, 02, 10), RecipientName = "Sarah So", NumberOfPackages = 1, Origin = "Beijing", Destination = "Beijing", Status = "Delivered", ShippingAccountID = 4, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 23, ReferenceNumber = "", ServiceType = "Next Day 15:00", ShippedDate = new DateTime(2016, 10, 23), DeliveredDate = new DateTime(2016, 10, 24), RecipientName = "Harry Ho", NumberOfPackages = 2, Origin = "Hefei", Destination = "Beijing", Status = "Delivered", ShippingAccountID = 1, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 24, ReferenceNumber = "", ServiceType = "Ground", ShippedDate = new DateTime(2017, 01, 15), DeliveredDate = new DateTime(2017, 01, 19), RecipientName = "Peter Pang", NumberOfPackages = 3, Origin = "Beijing", Destination = "Lhasa", Status = "Delivered", ShippingAccountID = 2, ShipmentPayer = true, TaxPayer = true },
            //    new Shipment { WaybillID = 25, ReferenceNumber = "386456", ServiceType = "Same Day", ShippedDate = new DateTime(2017, 01, 05), DeliveredDate = new DateTime(2017, 01, 05), RecipientName = "Jerry Jia", NumberOfPackages = 1, Origin = "Beijing", Destination = "Hangzhou", Status = "Delivered", ShippingAccountID = 2, ShipmentPayer = true, TaxPayer = true }
            //);

            //context.Shipments.AddOrUpdate(
            //    p => p.WaybillID,
            //    new Shipment
            //    {
            //        WaybillID = 26,
            //        ReferenceNumber = "",
            //        ServiceType = "Next Day 15:00",
            //        ShippedDate = new DateTime(2017, 1, 5, 20, 30, 0),
            //        DeliveredDate = new DateTime(2017, 1, 6, 13, 20, 0),
            //        RecipientName = "J. Wong",
            //        DeliveredAt = "Reception desk",
            //        NumberOfPackages = 2,
            //        Origin = "Tsim Sha Tsui",
            //        Destination = "Shanghai",
            //        Status = "Delivered",
            //        ShippingAccountID = 1
            //    }
            //);

            //// Add invoice 
            //context.Invoices.AddOrUpdate(
            //    p => p.PaymentID,
            //    new Invoice
            //    {
            //        AuthorizationCode = "1313",
            //        WaybillID = 26,
            //        PaymentAmount = 13,
            //        CurrencyCode = "HKD",
            //        UserName = "ejloriot",
            //        PayerCharacter = "Loriot",
            //        PaymentDescription = "Good description",
            //        PaymentID = 1
            //    }
            //);

            //context.Packages.AddOrUpdate(
            //    p => p.PackageID,
            //    new Package
            //    {
            //        PackageID = 1,
            //        WaybillID = 26,
            //        PackageTypeID = 1,
            //        Weight = 1,
            //        PackageTypeSizeID = 1,
            //        CurrencyCode = "HKD"
            //    },
            //    new Package
            //    {
            //        PackageID = 2,
            //        WaybillID = 26,
            //        PackageTypeID = 3,
            //        Weight = 1,
            //        PackageTypeSizeID = 3,
            //        CurrencyCode = "HKD"
            //    }
            //);

            //context.TrackingStatements.AddOrUpdate(
            //    p => p.TrackingID,
            //    new TrackingStatement { WaybillID = 26, DateTime = new DateTime(2017, 1, 6, 13, 20, 0), Description = "Delivered", Location = "Shanghai", Remarks = "" },
            //    new TrackingStatement { WaybillID = 26, DateTime = new DateTime(2017, 1, 6, 12, 00, 0), Description = "On vehicle for delivery", Location = "Shanghai", Remarks = "Vehicle 100023" },
            //    new TrackingStatement { WaybillID = 26, DateTime = new DateTime(2017, 1, 6, 11, 30, 0), Description = "At local sort facility", Location = "Pudong", Remarks = "Waiting for customs clearance" },
            //    new TrackingStatement { WaybillID = 26, DateTime = new DateTime(2017, 1, 6, 7, 30, 0), Description = "Left origin", Location = "Hong Kong", Remarks = "Dragonair KA215" },
            //    new TrackingStatement { WaybillID = 26, DateTime = new DateTime(2017, 1, 5, 23, 15, 0), Description = "At local sort facility", Location = "Tsung Chung", Remarks = "" },
            //    new TrackingStatement { WaybillID = 26, DateTime = new DateTime(2017, 1, 5, 20, 30, 0), Description = "Picked up", Location = "Tsim Sha Tsui", Remarks = "Vehicle 000067" }
            //);

            //context.Packages.AddOrUpdate(
            //    p => p.PackageID,
            //    new Package { WaybillID = 1, PackageTypeID = 1, PackageTypeSizeID = 1, Description = "Correspondence", ContentValue = 140, CurrencyCode = "CNY", Weighed = true, Fee = 0, ServiceTypeID = 2 },
            //    new Package { WaybillID = 1, PackageTypeID = 1, PackageTypeSizeID = 1, Description = "Correspondence", ContentValue = 140, CurrencyCode = "CNY", Weighed = true, Fee = 0, ServiceTypeID = 2 },
            //    new Package { WaybillID = 2, PackageTypeID = 2, PackageTypeSizeID = 2, Description = "Apple iPad Mini", ContentValue = 50, CurrencyCode = "CNY", Weight = 0.5M, Weighed = true, Fee = 0, ServiceTypeID = 5 },
            //    new Package { WaybillID = 3, PackageTypeID = 3, PackageTypeSizeID = 4, Description = "Painting", ContentValue = 160, CurrencyCode = "CNY", Weight = 0.5M, Weighed = true, Fee = 0, ServiceTypeID = 1 },
            //    new Package { WaybillID = 3, PackageTypeID = 4, PackageTypeSizeID = 5, Description = "Perfume", ContentValue = 253, CurrencyCode = "CNY", Weight = 2.3M, Weighed = true, Fee = 0, ServiceTypeID = 1 },
            //    new Package { WaybillID = 4, PackageTypeID = 1, PackageTypeSizeID = 1, Description = "Manual", ContentValue = 25, CurrencyCode = "CNY", Weighed = true, Fee = 0, ServiceTypeID = 6 },
            //    new Package { WaybillID = 4, PackageTypeID = 2, PackageTypeSizeID = 2, Description = "Samples", ContentValue = 35, CurrencyCode = "CNY", Weight = 1.4M, Weighed = true, Fee = 0, ServiceTypeID = 6 },
            //    new Package { WaybillID = 4, PackageTypeID = 2, PackageTypeSizeID = 3, Description = "Samples", ContentValue = 115, CurrencyCode = "CNY", Weight = 4.6M, Weighed = true, Fee = 0, ServiceTypeID = 6 },
            //    new Package { WaybillID = 4, PackageTypeID = 3, PackageTypeSizeID = 4, Description = "Design specifications", ContentValue = 25, CurrencyCode = "CNY", Weight = 1.0M, Weighed = true, Fee = 0, ServiceTypeID = 6 }
            //);

            //context.Invoices.AddOrUpdate(
            //    p => p.PaymentID,
            //    new Invoice { AuthorizationCode = "8261", WaybillID = 1, PaymentAmount = 280, CurrencyCode = "CNY", PayerCharacter = "Monica Mok", PaymentDescription = "" },
            //    new Invoice { AuthorizationCode = "7281", WaybillID = 2, PaymentAmount = 156.5M, CurrencyCode = "HKD", PayerCharacter = "Vincent Au", PaymentDescription = "" },
            //    new Invoice { AuthorizationCode = "4312", WaybillID = 3, PaymentAmount = 841.69M, CurrencyCode = "HKD", PayerCharacter = "Vincent Au", PaymentDescription = "" },
            //    new Invoice { AuthorizationCode = "8261", WaybillID = 4, PaymentAmount = 280, CurrencyCode = "CNY", PayerCharacter = "iGear Computing", PaymentDescription = "" }
            //);

        }
    }
}
