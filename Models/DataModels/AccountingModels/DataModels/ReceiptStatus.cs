using System.ComponentModel.DataAnnotations;

namespace TMP2019.Models.DataModels.AccountingModels.DataModels
{
    public class ReceiptStatus
    {
        public int Id { get; set; }

        [Display(Name ="Status")]
        public string ReceiptStatusName { get; set; }

    }
}