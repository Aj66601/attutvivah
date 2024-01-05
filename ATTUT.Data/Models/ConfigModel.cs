using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Data.Models
{
    internal class ConfigModel
    {
    }
    #region CompanyDetails
    public class CompanyModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter company name")]
        [Display(Name = "Company")]
        public string CompanyName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter company address")]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter email id")]
        [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Not a valid email")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter website")]
        [Display(Name = "Website")]
        public string Website { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter Phone/Mobile")]
        [Display(Name = "Phone/Mobile")]
        public string Mobile { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter gst no")]
        [Display(Name = "GST No.")]
        public string GSTIN { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter pan no")]
        [Display(Name = "PAN No.")]
        public string PanNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter bank name")]
        [Display(Name = "Bank Nmae")]
        public string BankName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter bank address")]
        [Display(Name = "Address")]
        public string BankAddress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter account no")]
        [Display(Name = "Account No.")]
        public string AccountNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter ifsc code")]
        [Display(Name = "IFSC Code")]
        public string IFSCCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter paytm no")]
        [Display(Name = "Paytm No.")]
        public string Paytm { get; set; } = string.Empty;
        public string? CIN { get; set; }
    }

    #endregion-------CompanyDetails--------

    #region-------Branch-----------
    public class BranchModel
    {
        [Key]
        public int BranchID { get; set; }
        [Required(ErrorMessage = "Select company")]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Enter Branch")]
        [Display(Name = "Branch")]
        public string BranchName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter BranchCode")]
        [Display(Name = "Branch Code")]
        public string BranchCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Select State")]
        [Display(Name = "State")]
        public int StateID { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;
        [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Not a valid email")]
        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Enter ContactNo")]
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Enter PinCode")]
        [Display(Name = "Pin Code")]
        public string PinCode { get; set; } = string.Empty;
        [Display(Name = "GSTIN")]
        public string? GSTIN { get; set; }
        [Required(ErrorMessage = "Select bank details to print on invoice ")]
        [Display(Name = "Bank Type")]
        public int AccountType { get; set; }
        [NotMapped]
        public BankAccountModel Account { get; set; } = new BankAccountModel();
        [Display(Name = "Billing Branch")]
        public int? BillingBranchId { get; set; }
        [Display(Name = "Name")]
        public string? ContactPerson { get; set; }
        [Display(Name = "Contact No.")]
        public string? ContactPersonNo { get; set; }
    }

    public class BankAccountModel
    {
        [Required(ErrorMessage = "Enter bank name")]
        [Display(Name = "Bank Nmae")]
        public string BankName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter bank address")]
        [Display(Name = "Address")]
        public string BankAddress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter account no")]
        [Display(Name = "Account No.")]
        [Key]
        public string AccountNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter ifsc code")]
        [Display(Name = "IFSC Code")]
        public string IFSCCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter paytm no")]
        [Display(Name = "Paytm No.")]
        public string Paytm { get; set; } = string.Empty;
    }

    #endregion-------Branch--------
    #region UserRights
    public class MenusModel
    {
        [Required(ErrorMessage = "Select Role")]
        public int RoleId { get; set; }
        public List<MenuAccessModel> ParentList { get; set; } = new();
    }

    public class DDlRolesModel
    {
        public int Id { get; set; }
        public string title { get; set; } = string.Empty;
    }
    #endregion
}
