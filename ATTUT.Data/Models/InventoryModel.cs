using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Data.Models
{
    [Keyless]
    public class InventoryModel
    {

        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? Warehouse { get; set; }

        public string? CategoryName { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; } 
        public decimal BookedQty { get; set; }
        public decimal AvailableQty { get; set; }

        public string? Color { get; set; }

    }
}
