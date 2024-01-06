using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATTUT.Data.Models.Basics
{
    internal class BasicsMasterModel
    {

    }

    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; } = string.Empty;

        [Display(Name = "Country Remarks")]
        public string CountryRemarks { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }


    public class StateModel
    {

        public int? CountryId { get; set; } = 0;
        [Required]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; } = string.Empty;
        [Key]
        public int StateId { get; set; }
        [Required]
        [Display(Name = "State Name")]

        public string StateName { get; set; } = string.Empty;

        [Display(Name = "State Remarks")]
        public string StateRemarks { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }


    public class DistrictModel
    {

        public int? CountryId { get; set; } = 0;
        [Required]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; } = string.Empty;
        
        public int StateId { get; set; }
       
        [Display(Name = "State Name")]
        public string StateName { get; set; } = string.Empty;

        [Key]
        public int DistrictId { get; set;}         
        [Required]
        [Display(Name = "District Name")]

        public string DistrictName { get; set; } = string.Empty;

        [Display(Name = "District Remarks")]
        public string DistrictRemarks { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
