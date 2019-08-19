using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels.AccountingModels.DataModels
{
    public class Invoice
    {
        public int Id { get; set; }

        [Display(Name = "Header")]
        [DataType(DataType.MultilineText)]
        public string InvoceHeader { get; set; }


        public int? CompanyId { get; set; }
        [Display(Name = "Customer")]
        [ForeignKey("CompanyId")]
        public Company Customer { get; set; }

        public int? CompanyId1 { get; set; }
        [Display(Name = "Supplier")]
        [ForeignKey("CompanyId1")]
        public Company Supplier { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime Maturity { get; set; }

        public string PaymentTerms { get; set; }

        public int? InvoiceRowId { get; set; }
        [Display(Name = "Row 1")]
        [ForeignKey("InvoiceRowId")]
        public InvoiceRow Row1 { get; set; }

        public int? InvoiceRowId1 { get; set; }
        [Display(Name = "Row 2")]
        [ForeignKey("InvoiceRowId1")]
        public InvoiceRow Row2 { get; set; }

        public int? InvoiceRowId2 { get; set; }
        [Display(Name = "Row 3")]
        [ForeignKey("InvoiceRowId2")]
        public InvoiceRow Row3 { get; set; }

        public int? InvoiceRowId3 { get; set; }
        [Display(Name = "Row 4")]
        [ForeignKey("InvoiceRowId3")]
        public InvoiceRow Row4 { get; set; }

        public int? InvoiceRowId4 { get; set; }
        [Display(Name = "Row 5")]
        [ForeignKey("InvoiceRowId4")]
        public InvoiceRow Row5 { get; set; }

        public int? InvoiceRowId5 { get; set; }
        [Display(Name = "Row 6")]
        [ForeignKey("InvoiceRowId5")]
        public InvoiceRow Row6 { get; set; }

        public int? InvoiceRowId6 { get; set; }
        [Display(Name = "Row 7")]
        [ForeignKey("InvoiceRowId6")]
        public InvoiceRow Row7 { get; set; }

        public int? InvoiceRowId7 { get; set; }
        [Display(Name = "Row 8")]
        [ForeignKey("InvoiceRowId7")]
        public InvoiceRow Row8 { get; set; }

        public int? InvoiceRowId8 { get; set; }
        [Display(Name = "Row 9")]
        [ForeignKey("InvoiceRowId8")]
        public InvoiceRow Row9 { get; set; }

        public int? InvoiceRowId9 { get; set; }
        [Display(Name = "Row 10")]
        [ForeignKey("InvoiceRowId9")]
        public InvoiceRow Row10 { get; set; }

        [Display(Name = "Footer")]
        [DataType(DataType.MultilineText)]
        public string InvoceFooter { get; set; }

    }
}
