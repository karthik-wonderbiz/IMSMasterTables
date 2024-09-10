using MediatR;

namespace MasterTables.Application.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }

        //public CreateProductCommand(string productName, double price, string code, bool isActive)
        //{
        //    ProductName = productName;
        //    Price = price;
        //    Code = code;
        //    IsActive = isActive;
        //}
    }

}
