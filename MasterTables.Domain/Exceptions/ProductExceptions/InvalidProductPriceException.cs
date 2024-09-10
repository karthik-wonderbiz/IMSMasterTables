using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTables.Domain.Exceptions.ProductExceptions
{
    public class InvalidProductPriceException : Exception
    {
        public InvalidProductPriceException(double price)
            : base($"Invalid price value: {price}. The price must be greater than zero.")
        {
        }
    }

}
