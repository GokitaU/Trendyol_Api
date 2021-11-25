using System;
using System.Collections.Generic;
using System.Text;

namespace Trendyol_Api
{
   public class Models
    {
        public class TrendyolOrder
        {
          
            public class ShipmentAddress
            {
                public int id { get; set; }
                public string firstName { get; set; }
                public string lastName { get; set; }
                public string address1 { get; set; }
                public string address2 { get; set; }
                public string city { get; set; }
                public int cityCode { get; set; }
                public string district { get; set; }
                public int districtId { get; set; }
                public string postalCode { get; set; }
                public string countryCode { get; set; }
                public string fullName { get; set; }
                public string fullAddress { get; set; }
            }

            public class InvoiceAddress
            {
                public int id { get; set; }
                public string firstName { get; set; }
                public string lastName { get; set; }
                public string company { get; set; }
                public string address1 { get; set; }
                public string address2 { get; set; }
                public string city { get; set; }
                public string district { get; set; }
                public string postalCode { get; set; }
                public string countryCode { get; set; }
                public string fullName { get; set; }
                public string fullAddress { get; set; }
            }

            public class DiscountDetail
            {
                public double lineItemPrice { get; set; }
                public double lineItemDiscount { get; set; }
            }

            public class Line
            {
                public int quantity { get; set; }
                public int salesCampaignId { get; set; }
                public string productSize { get; set; }
                public string merchantSku { get; set; }
                public string productName { get; set; }
                public int productCode { get; set; }
                public int merchantId { get; set; }
                public double amount { get; set; }
                public double discount { get; set; }
                public double price { get; set; }
                public List<DiscountDetail> discountDetails { get; set; }
                public string currencyCode { get; set; }
                public string productColor { get; set; }
                public int id { get; set; }
                public string sku { get; set; }
                public int vatBaseAmount { get; set; }
                public string barcode { get; set; }
                public string orderLineItemStatusName { get; set; }
            }

            public class PackageHistory
            {
                public object createdDate { get; set; }
                public string status { get; set; }
            }

            public class Content
            {
                public ShipmentAddress shipmentAddress { get; set; }
                public string orderNumber { get; set; }
                public double grossAmount { get; set; }
                public double totalDiscount { get; set; }
                public double totalPrice { get; set; }
                public object taxNumber { get; set; }
                public InvoiceAddress invoiceAddress { get; set; }
                public string customerFirstName { get; set; }
                public string customerEmail { get; set; }
                public int customerId { get; set; }
                public string customerLastName { get; set; }
                public int id { get; set; }
                public long cargoTrackingNumber { get; set; }
                public string cargoTrackingLink { get; set; }
                public string cargoSenderNumber { get; set; }
                public string cargoProviderName { get; set; }
                public List<Line> lines { get; set; }
                public long orderDate { get; set; }
                public string tcIdentityNumber { get; set; }
                public string currencyCode { get; set; }
                public List<PackageHistory> packageHistories { get; set; }
                public string shipmentPackageStatus { get; set; }
                public long estimatedDeliveryStartDate { get; set; }
                public long estimatedDeliveryEndDate { get; set; }
                public string deliveryAddressType { get; set; }
                public long agreedDeliveryDate { get; set; }
            }

            public class Root
            {
                public int page { get; set; }
                public int size { get; set; }
                public int totalPages { get; set; }
                public int totalElements { get; set; }
                public List<Content> content { get; set; }
            }


        }

        public class TrendyolUnPackedOrder
        {
            public class ShipmentAddress
            {
                public Nullable<int> id { get; set; }
                public string firstName { get; set; }
                public string lastName { get; set; }
                public string address1 { get; set; }
                public string address2 { get; set; }
                public string city { get; set; }
                public Nullable<int> cityCode { get; set; }
                public string district { get; set; }
                public Nullable<int> districtId { get; set; }
                public string postalCode { get; set; }
                public string countryCode { get; set; }
                public Nullable<int> neighborhoodId { get; set; }
                public string neighborhood { get; set; }
                public string fullAddress { get; set; }
                public string fullName { get; set; }
            }

            public class InvoiceAddress
            {
                public Nullable<int> id { get; set; }
                public string firstName { get; set; }
                public string lastName { get; set; }
                public string company { get; set; }
                public string address1 { get; set; }
                public string address2 { get; set; }
                public string city { get; set; }
                public Nullable<int> cityCode { get; set; }
                public string district { get; set; }
                public Nullable<int> districtId { get; set; }
                public string postalCode { get; set; }
                public string countryCode { get; set; }
                public Nullable<int> neighborhoodId { get; set; }
                public string neighborhood { get; set; }
                public string phone { get; set; }
                public string fullAddress { get; set; }
                public string fullName { get; set; }
            }

            public class DiscountDetail
            {
                public Nullable<double> lineItemPrice { get; set; }
                public Nullable<int> lineItemDiscount { get; set; }
            }

            public class Line
            {
                public List<string> packageItemIds { get; set; }
                public List<int> lineItemIds { get; set; }
                public Nullable<int> quantity { get; set; }
                public Nullable<int> salesCampaignId { get; set; }
                public string productSize { get; set; }
                public string merchantSku { get; set; }
                public string productName { get; set; }
                public Nullable<int> productCode { get; set; }
                public Nullable<int> merchantId { get; set; }
                public Nullable<double> amount { get; set; }
                public Nullable<int> discount { get; set; }
                public List<DiscountDetail> discountDetails { get; set; }
                public string currencyCode { get; set; }
                public Nullable<int> id { get; set; }
                public string sku { get; set; }
                public Nullable<double> vatBaseAmount { get; set; }
                public string barcode { get; set; }
                public string orderLineItemStatusName { get; set; }
                public Nullable<double> price { get; set; }
            }

            public class PackageHistory
            {
                public object createdDate { get; set; }
                public string status { get; set; }
            }

            public class Content
            {
                public ShipmentAddress shipmentAddress { get; set; }
                public string orderNumber { get; set; }
                public Nullable<double> grossAmount { get; set; }
                public Nullable<double> totalDiscount { get; set; }
                public object taxNumber { get; set; }
                public InvoiceAddress invoiceAddress { get; set; }
                public string customerFirstName { get; set; }
                public string customerEmail { get; set; }
                public Nullable<int> customerId { get; set; }
                public string customerLastName { get; set; }
                public string customerNote { get; set; }
                public Nullable<int> id { get; set; }
                public Nullable<int> orderId { get; set; }
                public object cargoTrackingNumber { get; set; }
                public string cargoProviderName { get; set; }
                public List<Line> lines { get; set; }
                public object orderDate { get; set; }
                public string tcIdentityNumber { get; set; }
                public string currencyCode { get; set; }
                public List<PackageHistory> packageHistories { get; set; }
                public string shipmentPackageStatus { get; set; }
                public string deliveryType { get; set; }
                public Nullable<int> timeSlotId { get; set; }
                public string scheduledDeliveryStoreId { get; set; }
                public object estimatedDeliveryStartDate { get; set; }
                public object estimatedDeliveryEndDate { get; set; }
                public string deliveryAddressType { get; set; }
                public Nullable<double> totalPrice { get; set; }
                public string cargoTrackingLink { get; set; }
                public string cargoSenderNumber { get; set; }
            }

            public class Order
            {
                public Nullable<int> page { get; set; }
                public Nullable<int> size { get; set; }
                public Nullable<int> totalPages { get; set; }
                public Nullable<int> totalElements { get; set; }
                public List<Content> content { get; set; }
            }
        }

        public class TrendyolRebate
        {
            // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
            public class LineItemStatus
            {
                public string name { get; set; }
            }

            public class LineItem
            {
                public Nullable<int> id { get; set; }
                public LineItemStatus lineItemStatus { get; set; }
            }

            public class OrderLine
            {
                public Nullable<int> id { get; set; }
                public string productName { get; set; }
                public string barcode { get; set; }
                public string merchantSku { get; set; }
                public string productSize { get; set; }
                public Nullable<double> price { get; set; }
                public Nullable<double> vatBaseAmount { get; set; }
                public Nullable<int> salesCampaignId { get; set; }
                public string productCategory { get; set; }
                public List<LineItem> lineItems { get; set; }
            }

            public class CustomerClaimItemReason
            {
                public Nullable<int> id { get; set; }
                public string name { get; set; }
                public Nullable<int> externalReasonId { get; set; }
                public string code { get; set; }
            }

            public class TrendyolClaimItemReason
            {
                public Nullable<int> id { get; set; }
                public string name { get; set; }
                public Nullable<int> externalReasonId { get; set; }
                public string code { get; set; }
            }

            public class ClaimItemStatus
            {
                public string name { get; set; }
            }

            public class ClaimItem
            {
                public string id { get; set; }
                public Nullable<int> orderLineItemId { get; set; }
                public CustomerClaimItemReason customerClaimItemReason { get; set; }
                public TrendyolClaimItemReason trendyolClaimItemReason { get; set; }
                public ClaimItemStatus claimItemStatus { get; set; }
                public string note { get; set; }
                public bool resolved { get; set; }
            }

            public class Item
            {
                public OrderLine orderLine { get; set; }
                public List<ClaimItem> claimItems { get; set; }
            }

            public class Content
            {
                public string id { get; set; }
                public string orderNumber { get; set; }
                public object orderDate { get; set; }
                public string customerFirstName { get; set; }
                public string customerLastName { get; set; }
                public object claimDate { get; set; }
                public object cargoTrackingNumber { get; set; }
                public string cargoProviderName { get; set; }
                public Nullable<int> orderShipmentPackageId { get; set; }
                public List<Item> items { get; set; }
            }

            public class Order
            {
                public Nullable<int> totalElements { get; set; }
                public Nullable<int> totalPages { get; set; }
                public Nullable<int> page { get; set; }
                public Nullable<int> size { get; set; }
                public List<Content> content { get; set; }
            }


        }
    }
}
