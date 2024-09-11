using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTables.Application.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }

        public UpdateProductCommand(Guid id, string productName, double price, string code, bool isActive)
        {
            Id = id;
            ProductName = productName;
            Price = price;
            Code = code;
            IsActive = isActive;
        }
    }

}
