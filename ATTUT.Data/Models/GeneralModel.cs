using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Data.Models
{
    internal class GeneralModel
    {
    }
    [Keyless]
    public class ValidateResultModel
    {
        public int InfoCode { get; set; }
        public string InfoMessage { get; set; } = string.Empty; 
    }
    public class CompanyDdlModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }
    public class DdlUserRoleModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    public class CountryDdlModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }
    public class StateDdlModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }
    public class BranchDdlModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }


    public class DdlCompanyBranchModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }
    [Keyless]
    public class DefaultAccountModel
    {
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
        public string? AccountNo { get; set; }
        public string? IFSCCode { get; set; }
        public string? Paytm { get; set; }
    }

    public class DdlCategoryModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    public class DdlBrandModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }
    public class DdlUoMModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }
    public class DdlHSNModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    public class DdlMstItemsModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    public class DdlMstWarehouseModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    [Keyless]
    public class DdlFiscalModel
    {
        
        [Display(Name = "Fiscal Year")]
        public string? Value { get; set; }
        public string? Text { get; set; } 
    }

    [Keyless]
    public class HSNDetailsModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter hsn code")]
        [Display(Name = "HSN Code")]
        public string HSNCode { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter CGST(%)")]
        [Display(Name = "CGST(%)")]
        public decimal CGST { get; set; }
        [Required(ErrorMessage = "Enter SGST(%)")]
        [Display(Name = "SGST(%)")]
        public decimal SGST { get; set; }
        [Required(ErrorMessage = "Enter IGST(%)")]
        [Display(Name = "IGST(%)")]
        public decimal IGST { get; set; }
        [Required(ErrorMessage = "Enter surcharge(%)")]
        [Display(Name = "Surcharge(%)")]
        public decimal Surcharge { get; set; }
        [Required(ErrorMessage = "Enter Cess(%)")]
        [Display(Name = "Cess(%)")]
        public decimal Cess { get; set; }
    }
    public class CustomerInfoModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Company")]
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Contact No")]
        [Required]
        public string ContactNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter email id")]
        [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Not a valid email")]
        [Display(Name = "Email")]
        public string EmailId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Select State")]
        [Display(Name = "State")]
        public int StateID { get; set; }
        [RegularExpression(@"[A-Z]{5}\d{4}[A-Z]{1}", ErrorMessage = "Invalid PAN Number")]
        [Display(Name = "PAN Number")]
        public string? PanNo { get; set; } = string.Empty;
        [Display(Name = "GST Number")]
        public string? GSTNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter address")]
        [Display(Name = "Billing Address")]
        public string Address { get; set; } = string.Empty;
        [Display(Name = "Shiping Address")]
        public string? ShipTo { get; set; } = string.Empty;
         
    }
    public class ItemPriceInfoModel
    {
        [Key]
        public int Id { get; set; } 
        public decimal MRP { get; set; }
        public decimal CTC { get; set; }
        [Display(Name = "Discount(%)")]
        public decimal Discount { get; set; } 
        [Display(Name = "FlatDiscount")]
        public decimal FlatDiscount { get; set; } 
        public int Qty { get; set; }  
    }
    public class GetBillingAddressByCustomerIdModel
    {
        [Key]
        public int BillAddressId { get; set; }
        public string BillAddress { get; set; } = string.Empty;
        public string? StateName { get; set; } = string.Empty;
        public int Pincode { get; set; }
    }

    public class GetShippingAddressByCustomerIdModel
    {
        [Key]
        public int ShipAddressId { get; set; }
        public string ShipAddress { get; set; } = string.Empty;
    }

    public class DdlBillAddress
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }
    public class DdlShipAddress
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }

    public class FiscalModel
    {
        [Key]
        public int Id { get; set; }
        public string FiscalValue { get; set; } = string.Empty;
    }

    public class DdlMstColorModel
    {
        [Key]
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
