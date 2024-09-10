using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTables.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }

}
