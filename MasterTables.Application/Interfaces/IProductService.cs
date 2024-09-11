using MasterTables.Application.DTOs;
using MasterTables.Domain.Entities;

namespace MasterTables.Application.Interfaces
{
    //public interface IProductService
    //{
    //    Task<IEnumerable<Product>> GetAllProductsAsync();
    //    Task<Product> GetProductByIdAsync(Guid id);
    //    Task<Product> CreateProductAsync(Product product);
    //    Task<Product> UpdateProductAsync(Product product);
    //    Task DeleteProductAsync(Guid id);
    //}

    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<Guid> CreateProductAsync(ProductDto productDto);
        Task UpdateProductAsync(Guid id, ProductDto productDto);
        Task DeleteProductAsync(Guid id);
    }
}
