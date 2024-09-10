using AutoMapper;
using MasterTables.Application.DTOs;
using MasterTables.Application.Interfaces;
using MasterTables.Domain.Entities;
using MasterTables.Domain.Interfaces;

namespace MasterTables.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<Guid> CreateProductAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            product.CreatedBy = "";
            product.UpdatedBy = "";
            product.IsActive = true;

            await _productRepository.AddProductAsync(product);
            return product.Id;
        }

        public async Task UpdateProductAsync(Guid id, ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            _mapper.Map(productDto, existingProduct);
            existingProduct.UpdatedAt = DateTime.UtcNow;

            await _productRepository.UpdateProductAsync(existingProduct);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            await _productRepository.DeleteProductAsync(id);
        }
    }
}
