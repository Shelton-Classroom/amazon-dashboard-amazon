using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAPI
{
    public class DataRetriever
    {
        public HttpClient client { get; set; }
        public void Initialize(string username, string password)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password)));
        }

        public async Task<T> Get<T>(string path)
        {
            using (HttpResponseMessage response = await client.GetAsync(path))
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
        }
    }

    public class ProductVendor
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone1 { get; set; }
        public string ContactPhone2 { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmail { get; set; }
        public int Threshold { get; set; }
    }

    public class Location
    {
        public string LocationName { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public int? LocationPriority { get; set; }
    }

    public class ProductGroup
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int InventoryCount { get; set; }
        public string Site { get; set; }
        public int GroupFloorPrice { get; set; }
        public int GroupCeilingPrice { get; set; }
        public int GroupDefaultPrice { get; set; }
        public int GroupPrice { get; set; }
    }

    public class ProductSite
    {
        public string Site { get; set; }
        public string Price { get; set; }
        public int? Quantity { get; set; }
        public string CurrencyISO { get; set; }
        public string FloorPrice { get; set; }
        public string CeilingPrice { get; set; }
        public string DefaultPrice { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public int? LeadtimeToShip { get; set; }
        public DateTime? RestockDate { get; set; }
        public int? SalePrice { get; set; }
        public DateTime? SaleStartDate { get; set; }
        public DateTime? SaleEndDate { get; set; }
        public string AmazonShippingGroup { get; set; }
        public int? MinThreshold { get; set; }
        public int? MaxVisible { get; set; }
        public bool? IsBuyBoxOwned { get; set; }
    }

    public class BundledItem
    {
        public string SKU { get; set; }
        public string Title { get; set; }
        public int? Quantity { get; set; }
        public int? AmountPerBundle { get; set; }
    }

    public class SAInventory
    {
        public string SKU { get; set; }
        public string ProductID { get; set; }
        public string ProductType { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string WPID { get; set; }
        public string eBayItemId { get; set; }
        public string ASIN { get; set; }
        public string Condition { get; set; }
        public string ConditionNote { get; set; }
        public int? MAPPrice { get; set; }
        public string RetailPrice { get; set; }
        public string ItemWeight { get; set; }
        public int? ItemHeight { get; set; }
        public int? ItemLength { get; set; }
        public int? ItemWidth { get; set; }
        public string ImageURLSmall { get; set; }
        public string ImageURLBig { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public bool Active { get; set; }
        public string Cost { get; set; }
        public string ModelNumber { get; set; }
        public string Brand { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public string Attribute5 { get; set; }
        public string Attribute6 { get; set; }
        public string Attribute7 { get; set; }
        public string Attribute8 { get; set; }
        public string UPC { get; set; }
        public string HSCode { get; set; }
        public ProductVendor ProductVendor { get; set; }
        public List<Location> Locations { get; set; }
        public List<ProductSite> ProductSites { get; set; }
        public List<BundledItem> BundledItems { get; set; }
    }
}
