
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
    internal class MasterModel
    {
    }
    public class HSNCodeModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Select Company")]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Enter HSN Code")]
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

    public class BrandModel
    {
        [Key]
        public int BrandID { get; set; }
        public int CompanyId { get; set; }
        [Required]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        public int CompanyId { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class WarehouseModel
    {
        [Key]
        public int WarehouseId { get; set; } 
        public int CompanyId { get; set; }
        [Required]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Warehouse Name")]
        public string WarehouseName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Address")]
        public string WarehouseAddress { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class DomesticProductModel
    {
        [Key]
        public int PId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string? ModelNo { get; set; }
        public string? ImageURL { get; set; }
        public string? CompanyName { get; set; }
        public string? BranchName { get; set; }
        public bool IsActive { get; set; }

        public string? PhotoViewUrl { get; set; } = string.Empty;

     
    }
}
