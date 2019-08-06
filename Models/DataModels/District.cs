using System.ComponentModel.DataAnnotations;

namespace TMP2019.Models.DataModels
{
    public class District
    {
        public int Id { get; set; }

        [Display(Name = "District")]
        public string DistrictName { get; set; }
    }
}