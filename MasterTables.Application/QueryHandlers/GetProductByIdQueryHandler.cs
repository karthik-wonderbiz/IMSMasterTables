using AutoMapper;
using MasterTables.Application.DTOs;
using MasterTables.Application.Queries;
using MasterTables.Domain.Interfaces;
using MediatR;

namespace MasterTables.Application.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null)
                throw new Exception("Product not found");

            return _mapper.Map<ProductDto>(product);
        }
    }
}
