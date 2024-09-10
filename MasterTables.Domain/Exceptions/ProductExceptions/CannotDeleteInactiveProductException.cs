using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTables.Domain.Exceptions.ProductExceptions
{
    public class CannotDeleteInactiveProductException : Exception
    {
        public CannotDeleteInactiveProductException(Guid productId)
            : base($"Cannot delete the product with ID {productId} because it is inactive.")
        {
        }
    }

}
