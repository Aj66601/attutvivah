using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ATTUT.Data.Models
{
    internal class AccountModel
    {
    }
    public class SessionModel
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int Fiscal { get; set; }
    }
    public class LoginModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
    public class MenuAccessModel
    {
        [Key]
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string? Icon { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Controller { get; set; } = string.Empty;
        public string ActionName { get; set; } = string.Empty;
        public bool IsChildMenu { get; set; }
        public bool CheckedStatus { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class ProfileModel
    {
        [Key]
        public int EmpId { get; set; }
        [Display(Name = "Employee Id")]
        public string EmployeeId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter Phone/Mobile")]
        [Display(Name = "Phone/Mobile")]
        public string ContactNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter email id")]
        [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Not a valid email")]
        [Display(Name = "Email")]
        public string EmailId { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        public string? BranchName { get; set; } 
        [Required]
        [Display(Name = "Role")] 
        public string? Role { get; set; }
        [Required]
        public string Address { get; set; } = string.Empty; 
    }

    public class ChangePasswordModel
    {
        [Key]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Old Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string? OldPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "New Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 6 and 255 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword")]
        public string? ConfirmPassword { get; set; }

    }
}
