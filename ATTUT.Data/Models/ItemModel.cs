
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Data.Models
{
    public class ItemModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Company")]
        [Required]
        public int CompanyId { get; set; }
        [Display(Name = "Category")]
        [Required]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        [Display(Name = "Brand")]
        [Required]
        public int BrandID { get; set; }
        public string? BrandName { get; set; } = string.Empty;
        [Display(Name = "Model No.")]
        [Required]
        public string ItemName { get; set; } = string.Empty;
        [Display(Name = "Item Code")]
        [Required]
        public string ItemCode { get; set; } = string.Empty;
        [Display(Name = "UOM")]
        [Required]
        public int UomID { get; set; }
        [Display(Name = "HSN")]
        [Required]
        public int HSNID { get; set; }
        
        [Display(Name = "Photo")]
        public string? PhotoUrl { get; set; } = string.Empty;
        public string? PhotoViewUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        [Display(Name = "Inventory Required")]
        public bool IsInventoryRequired { get; set; } = true;
        [NotMapped]
        public List<ItemPriceModel> ItemPrices { get; set; } = new();


    }

    [Keyless]
    public class ItemFilterModel
    {
        [Display(Name = "Company")] 
        public int? CompanyId { get; set; }
        [Display(Name = "Category")]        
        public int? CategoryID { get; set; } 
        [Display(Name = "Brand")]        
        public int? BrandId { get; set; }
        public List<ItemModel> Items { get; set; } = new List<ItemModel>();
    }
    public class ItemPriceModel
    { 
        [Key]
        public int BranchId { get; set; }
        public string Branch { get; set; } = string.Empty;
        [Required]
        public decimal MRP { get; set; }
        [Display(Name = "Discount(%)")]
        public decimal Discount { get; set; }
        [Required]
        [Display(Name = "Selling Price")]
        public decimal SellingPrice { get; set; }
        [Required]
        [Display(Name = "CTC")]
        public decimal CTC { get; set; }
        [NotMapped]
        public int WarehouseId { get; set; }



    }
}
