using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AmazonAPI
{
    class ShipStation
    {
        public HttpClient client { get; set; }
        public void InitializeTwo(string username, string password)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password)));
        }

        public async Task<S> Get<S>(string path)
        {
            using (HttpResponseMessage response = await client.GetAsync(path))
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<S>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
        }
    }

    public class ShipTo
    {
        public string name { get; set; }
        public string company { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public object street3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public object residential { get; set; }
    }

    public class Weight
    {
        public decimal value { get; set; }
        public string units { get; set; }
    }

    public class InsuranceOptions
    {
        public object provider { get; set; }
        public bool insureShipment { get; set; }
        public decimal insuredValue { get; set; }
    }

    public class ShipmentItem
    {
        public int orderItemId { get; set; }
        public object lineItemKey { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public object imageUrl { get; set; }
        public object weight { get; set; }
        public int quantity { get; set; }
        public int unitPrice { get; set; }
        public object warehouseLocation { get; set; }
        public object options { get; set; }
        public int productId { get; set; }
        public object fulfillmentSku { get; set; }
    }

    public class Shipment
    {
        public int shipmentId { get; set; }
        public int orderId { get; set; }
        public string orderKey { get; set; }
        public string userId { get; set; }
        public string orderNumber { get; set; }
        public DateTime createDate { get; set; }
        public string shipDate { get; set; }
        public double shipmentCost { get; set; }
        public decimal insuranceCost { get; set; }
        public string trackingNumber { get; set; }
        public bool isReturnLabel { get; set; }
        public string batchNumber { get; set; }
        public string carrierCode { get; set; }
        public string serviceCode { get; set; }
        public string packageCode { get; set; }
        public string confirmation { get; set; }
        public int warehouseId { get; set; }
        public bool voided { get; set; }
        public object voidDate { get; set; }
        public bool marketplaceNotified { get; set; }
        public object notifyErrorMessage { get; set; }
        public ShipTo shipTo { get; set; }
        public Weight weight { get; set; }
        public object dimensions { get; set; }
        public InsuranceOptions insuranceOptions { get; set; }
        public object advancedOptions { get; set; }
        public List<ShipmentItem> shipmentItems { get; set; }
        public object labelData { get; set; }
        public object formData { get; set; }
    }

    public class Root
    {
        public List<Shipment> shipments { get; set; }
        public int total { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
    }
}
