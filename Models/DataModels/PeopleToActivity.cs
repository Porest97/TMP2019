using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMP2019.Models.DataModels
{
    public class PeopleToActivity
    {
        public int Id { get; set; }

        public int? ActivityId { get; set; }
        [Display(Name = "Activity")]
        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }

        public int? PersonId { get; set; }
        [Display(Name = "Person")]
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
