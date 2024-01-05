using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace ATTUT.Data.Models
{
    public class PerformaInvoiceModel
    {
        [Key]
        public int ID { get; set; } = 0;
        [Display(Name = "Company")]
        [Required]
        public int CompanyId { get; set; }
        [Display(Name = "Branch")]
        [Required(ErrorMessage = "Select Branch")]
        public int BranchId { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Contact No")]
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid contact number")]
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
        [Display(Name = "Bill Date")]
        [Required(ErrorMessage = "Select Billing date")]
        public string BillDate { get; set; } = string.Empty;
        public string? Remarks { get; set; } = string.Empty;
        [Display(Name = "Total")]
        [Required]
        public decimal TotalBillAmount { get; set; }
        [Required]
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
        [Required]
        [Display(Name = "Advance")]
        public decimal Advance { get; set; }
        [Display(Name = "Status")]
        [Required]
        public string InvoiceStatus { get; set; } = string.Empty;
        [NotMapped]
        public List<PerformaInvoiceItemsModel> InvoiceItems { get; set; } = new();
         
    }

    public class PerformaInvoiceItemsModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PerformaInvoiceId { get; set; }
        [Display(Name = "Item")]
        [Required]
        public int ItemId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        [Display(Name = "Item Description")]
        [Required]
        public string ItemDescription { get; set; } = string.Empty;
        [Required]
        public decimal MRP { get; set; }
        [Display(Name = "Discount(%)")]
        [Required]
        public decimal DiscountPercent { get; set; }
        [Required]
        [Display(Name = "Flat Discount")]
        public decimal FlatDiscount { get; set; }
        [Display(Name = "Quantity")]
        [Required]
        public decimal Qty { get; set; }
        [Required]
        public decimal Total { get; set; }
        [NotMapped]
        public int IsHide { get; set; }
        [Required]
        [Display(Name = "Color")]
        public string ColorId { get; set; } = string.Empty;
        public string? ColorName { get; set; }

    }

    [Keyless]
    public class InvoiceFilterModel
    {
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "From Date")]
        public string? FromDate { get; set; }
        [Display(Name = "To Date")]
        public string? ToDate { get; set; }
        [Display(Name = "Status")]
        public int InvoiceStatus { get; set; }
        public string? Search { get; set; }
        [NotMapped]
        public List<PerformaInvoiceModel> Invoices { get; set; } = new List<PerformaInvoiceModel>();
    }
    [Keyless]
    public class PrintPIHeader
    {
        public string CompanyName { get; set; } = string.Empty;
        public string Division { get; set; } = string.Empty;
        public string CompanyAddress { get; set; } = string.Empty;
        public string CompanyEmail { get; set; } = string.Empty;
        public string CompanyContactNo { get; set; } = string.Empty;
        public string CIN { get; set; } = string.Empty;
        public string GST { get; set; } = string.Empty;

        public int ID { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public string BillDate { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;
        public string CustomerContactNo { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;


        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal Advance { get; set; }
        public decimal Balance { get; set; }


        public string BankName { get; set; } = string.Empty;
        public string BankAddress { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public string IFSCCode { get; set; } = string.Empty;


        [NotMapped]
        public string TotalInWord { get; set; } = string.Empty;
        [NotMapped]
        public List<PrintPIItems> Items { get; set; } = new List<PrintPIItems>();
    }
    [Keyless]
    public class PrintPIItems
    {
        public string ItemName { get; set; } = string.Empty;
        public decimal MRP { get; set; }
        public decimal Discount { get; set; }
        public int DiscountType { get; set; }
        public decimal UnitRate { get; set; }
        public int Quantity { get; set; }
        public decimal TaxableValue { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal IGST { get; set; }
        public decimal Total { get; set; }
        public string? PhotoUrl { get; set; } 
        public string? ColorName { get; set; }
    }

    public class InvoiceModel
    {
        [Key]
        public int ID { get; set; } 
        public int PerformaInvoiceId { get; set; } 
        [Display(Name = "Company")]
        [Required]
        public int CompanyId { get; set; }
        [Display(Name = "Branch")]
        [Required(ErrorMessage = "Select Branch")]
        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Contact No")]
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid contact number")]
        public string ContactNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter email id")]
        [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Not a valid email")]
        [Display(Name = "Email")]
        public string EmailId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Select State")]
        [Display(Name = "State")]
        public int StateID { get; set; }
        public string? StateName { get; set; }
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
        [Display(Name = "Bill Date")]
        [Required(ErrorMessage = "Select Billing date")]
        public string BillDate { get; set; } = string.Empty;
        [Display(Name = "Billing  Remarks")]
        public string? Remarks { get; set; } = string.Empty;
        [Display(Name = "Total")]
        [Required]
        public decimal TotalBillAmount { get; set; }
        [Required]
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
        [Required]
        [Display(Name = "Advance")]
        public decimal Advance { get; set; }
        [Display(Name = "Balance")]
        public decimal? Paid { get; set; }
        [Display(Name = "Status")]
        [Required]
        public string InvoiceStatus { get; set; } = string.Empty;

        [Display(Name = "Delivery Date")]
        [Required]
        public string DeliverDate { get; set; } = string.Empty;
        [Display(Name = "Delivery  Remarks")]
        public string? DeliverRemarks { get; set; } = string.Empty;

        [NotMapped]
        public List<InvoiceItemsModel> Items { get; set; } = new();
    }
    public class InvoiceItemsModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [Display(Name = "Item")]
        [Required]
        public int ItemId { get; set; }
        [Display(Name = "Warehouse")]
        [Required]
        public int WarehouseId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        [Display(Name = "Item Description")]
        [Required]
        public string ItemDescription { get; set; } = string.Empty;
        [Required]
        public decimal MRP { get; set; }
        [Display(Name = "Discount(%)")]
        [Required]
        public decimal DiscountPercent { get; set; }
        [Required]
        [Display(Name = "Flat Discount")]
        public decimal FlatDiscount { get; set; }
        [Display(Name = "Quantity")]
        [Required]
        public decimal Qty { get; set; }
        [Required]
        public decimal Total { get; set; } 
        public string? Remarks { get; set; }
        [NotMapped]
        public int IsHide { get; set; }
        [Required]
        [Display(Name = "Color")]
        public string ColorId { get; set; }
        public string? ColorName { get; set; }

    }
}
