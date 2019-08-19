using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMP2019.Models.DataModels.AccountingModels.DataModels
{
    public class InvoiceRow
    {
        public int Id { get; set; }

        public int? ArticleId { get; set; }
        [Display(Name = "Article")]
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        [Display(Name = "Qty")]
        public double Quantity { get; set; }


        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public double ArticlePrice { get; set; }


        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public double RowTotal { get; set; }

        
    }
}