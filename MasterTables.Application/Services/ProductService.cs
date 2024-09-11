using MasterTables.Application.Interfaces;
using MasterTables.Domain.Entities;
using MasterTables.Domain.Interfaces;

namespace MasterTables.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                product.CreatedAt = DateTime.UtcNow;
                return await _productRepository.AddProductAsync(product);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            product.UpdatedAt = DateTime.UtcNow;
            return await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
