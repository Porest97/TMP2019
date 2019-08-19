using System.ComponentModel.DataAnnotations;

namespace TMP2019.Models.DataModels.AccountingModels.DataModels
{
    public class Article
    {
        public int Id { get; set; }

        public string ArticleDescription { get; set; }

        [Display(Name ="Price")]
        [DataType(DataType.Currency)]
        public double ArticlePrice { get; set; }
    }
}