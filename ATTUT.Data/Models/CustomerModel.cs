using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Data.Models
{
    public class CustomerModel
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
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid contact number")]
        public string ContactNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter email id")]
        [DataType(DataType.EmailAddress)]
       // [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Not a valid email")]
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
        public string? ShipTo{ get; set; } = string.Empty;
        [NotMapped]
        public List<CustomerBillAddressModel> BillAddresses { get; set; } = new();
        [NotMapped]
        public List<CustomerShipAddressModel> ShipAddresses { get; set; } = new();
    }

    public class CustomerBillAddressModel
    {
        [Key]
        public int BillAddressId { get; set; }
        [Display(Name = "Billing Address")]
        [Required(ErrorMessage = "Enter billing address")]
        public string BillAddress { get; set; } = string.Empty;
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
        [Required]
        public int Pincode { get; set; }
        [Display(Name = "GST No")]
        [Required]
        public string GstNo { get; set; } = string.Empty;
        [NotMapped]
        public int IsHide { get; set; }
    }
    public class CustomerShipAddressModel
    {
        [Key]
        public int ShipAddressId { get; set; }
        [Display(Name = "Shipping Address")]
        //[Required(ErrorMessage = "Enter shipping address")]
        public string ShipAddress { get; set; } = string.Empty;
        //[Required]
        public int CustomerId { get; set; }
        [NotMapped]
        public int IsHide { get; set; }
    }
}
