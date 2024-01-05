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
}
