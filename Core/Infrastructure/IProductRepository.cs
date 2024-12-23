using Core.Entities;

namespace Core.Infrastructure
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int i);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
    }
}