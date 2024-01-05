using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATTUT.Data.Models
{
    [Keyless]
    public class CreateOrUpdateModel
    {
        public int InfoCode { get; set; }
        public string InfoMessage { get; set; } = string.Empty;
        public string? InsertedID { get; set; } = string.Empty;
    }
}
