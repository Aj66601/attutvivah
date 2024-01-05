using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Data.Models
{
    [Keyless]
    public class InventoryBookedModel
    {
        public string? InvoiceNo { get; set; }
        public string InvoiceDate { get; set; } = string.Empty;
        public string? ItemName { get; set; }
        public string? ColorId { get; set; }
        public decimal BookedQuantity { get; set; }
    }
}
