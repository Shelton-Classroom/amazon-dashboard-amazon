using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AmazonModel.Expenses
{
    [MetadataType(typeof(ExpenseCaptureMetadata))]
    public partial class ExpenseCapture
    {
        private sealed class ExpenseCaptureMetadata
        {
            [Display(Name = "Date")]
            [DataType(DataType.Date)]
            public int ExpenseDate { get; set; }


            [Display(Name = "Amount")]
            [DataType(DataType.Currency)]
            public string ExpenseAmount { get; set; }

            [Display(Name = "Merchant Id")]
            public int MerchantId { get; set; }

            [Display(Name = "Expense Code")]
            public int ExpenseCode { get; set; }
        }
    }
}
