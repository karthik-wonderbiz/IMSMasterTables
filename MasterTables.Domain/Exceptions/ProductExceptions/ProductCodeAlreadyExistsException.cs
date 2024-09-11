using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTables.Domain.Exceptions.ProductExceptions
{
    public class ProductCodeAlreadyExistsException : Exception
    {
        public ProductCodeAlreadyExistsException(string code)
            : base($"Product with the code '{code}' already exists.")
        {
        }
    }

}
