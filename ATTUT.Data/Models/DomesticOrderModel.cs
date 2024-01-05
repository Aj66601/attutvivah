using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Data.Models
{
    public class DomesticOrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public string? OrderNo { get; set; }
        public int CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public int BranchID { get; set; }
        public string? BranchName { get; set; }
        
        public bool IsActive { get; set; }

       
        public List<DomesticOrderItemModel> domesticOrderItems { get; set; } = new();
    }

    public class DomesticOrderItemModel
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string Remarks { get; set; } = string.Empty;
        [NotMapped]
        public int IsHide { get; set; }
    }
}
