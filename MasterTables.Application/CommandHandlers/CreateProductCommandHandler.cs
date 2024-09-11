using MasterTables.Application.Commands;
using MasterTables.Application.DTOs;
using MasterTables.Application.Interfaces;
using MediatR;

namespace MasterTables.Application.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productDto = new ProductDto
            {
                ProductName = request.ProductName,
                Price = request.Price,
                Code = request.Code,
                IsActive = true
            };

            return await _productService.CreateProductAsync(productDto);
        }
    }
}
