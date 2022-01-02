

using Shop.Web.Models;

namespace Shop.Web.Service.IService
{
    public interface IProductService
    {

        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDTO productDto);
        Task<T> UpdateProductAsync<T>(ProductDTO productDto);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
