using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AmazonModel.Inventory
{
    
    [MetadataType(typeof(NewInventoryMetadata))]
    public partial class NewInventory
    {
        private sealed class NewInventoryMetadata
        {
            [Display(Name = "Date of Purchase")]
            [DataType(DataType.Date)]
            public int PurchaseDate { get; set; }

            [Display(Name = "Inventory Type")]
            public string InventoryType { get; set; }

            [Display(Name = "Quantity")]
            public int QuantityPurchased { get; set; }

            [Display(Name = "Amount")]
            [DataType(DataType.Currency)]
            public int Cost { get; set; }

            [Display(Name = "Reason")]
            public int PurchaseReason { get; set; }
           
            [Display(Name = "Percentage Paid")]
            public int PercentagePaid { get; set; }
            
            [Display(Name = "Item Id")]
            public int ItemId { get; set; }
            
            [Display(Name = " Source Id")]
            public int TheSourceId { get; set; }
        }
    }
}
