using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels.AccountingModels.DataModels
{
    public class AccountsToPerson
    {
        public int Id { get; set; }

        [Display(Name = "Person")]
        public int? PersonId { get; set; }
        [Display(Name = "Person")]
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        [Display(Name ="Swish #")]
        [DataType(DataType.PhoneNumber)]
        public string SwishNumber { get; set; }

        [Display(Name ="Bank #")]        
        public string BankAccount { get; set; }


        [Display(Name="Bank")]
        public string BankName { get; set; }

    }
}
