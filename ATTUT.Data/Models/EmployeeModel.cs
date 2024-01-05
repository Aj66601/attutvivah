using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Data.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Mobile No.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string ContactNo { get; set; } = string.Empty;
        [Display(Name = "Email-Id")]
        [DataType(DataType.EmailAddress)]
        public string? EmailId { get; set; } = string.Empty;
        [Display(Name = "Address")]
        public string? Address { get; set; } = string.Empty;
        [Display(Name = "Employee Id")]
        public string? EmployeeId { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
        public string? RoleName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        public string? BranchName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsLoginEnable { get; set; }
    }

}
