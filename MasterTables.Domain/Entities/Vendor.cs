using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTables.Domain.Entities
{
    public class Vendor : BaseEntity
    {
        public string VendorName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string ContactPersonName { get; set; } = string.Empty;
        public string ContactPersonPhone { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
