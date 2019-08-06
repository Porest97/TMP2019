using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMP2019.Models.DataModels
{
    public class Club
    {
        public int Id { get; set; }

        [Display(Name = "Club")]
        public string ClubName { get; set; }


        [Display(Name = "District")]
        public int? DistrictId { get; set; }
        [Display(Name = "District")]
        [ForeignKey("DistrictId")]
        public District District { get; set; }
    }
}