
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATTUT.Data.Models
{
    public class StockInModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Company")]
        [Required]
        public int CompanyId { get; set; }
        [Display(Name = "Branch")]
        [Required]
        public int BranchId { get; set; }

        [Display(Name = "Seller Name")]
        [Required]
        public string SellerName { get; set; } = string.Empty;
        [Display(Name = "Contact No.")]
        [Required]
        public string ContactNo { get; set; } = string.Empty;
        [Display(Name = "Email-Id")]
        [DataType(DataType.EmailAddress)]
        // [Required]
        public string? EmailId { get; set; } = string.Empty;
        [Display(Name = "Invoice Date")]
        [Required]
        public string InvoiceDate { get; set; } = string.Empty;
        [Display(Name = "Invoice No.")]
        [Required]
        public string InvoiceNo { get; set; } = string.Empty;

        [Display(Name = "Amount")]
        [Required]
        public decimal InvoiceAmount { get; set; }
        [Required]
        public decimal CGST { get; set; }
        [Required]
        public decimal IGST { get; set; }
        [Required]
        public decimal SGST { get; set; } 
        public string? Remarks { get; set; }
        [Display(Name = "Upload Invoice")] 
        public string? UploadInvoiceUrl { get; set; }
      
        [NotMapped]
        public List<StockInItemsModel> StockItems { get; set; } = new();
    }

    public class StockInItemsModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int StockInId { get; set; }
        [Display(Name = "Item")]
        [Required]
        public int ItemId { get; set; }
        [Display(Name = "Warehouse")]
        [Required]
        public int WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        [NotMapped]
        public string ItemCode { get; set; } = string.Empty;
        [NotMapped]
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
        [Required]
        [Display(Name = "Color")]
        public string ColorId { get; set; } = string.Empty;
        public string? ColorName { get; set; }
        [NotMapped]
        public int IsHide { get; set; }

    }
}
