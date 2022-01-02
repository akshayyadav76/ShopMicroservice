using ProductAPI.DataAccess.DTO;

namespace ProductAPI.Repo
{
    public interface IProductRepo
    {
        public Task<List<ProductDTO>> GetProducts();
        public Task<ProductDTO> GetProductById(int productId);
        public Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO);
        public Task<bool> DeleteProduct(int productId);


    }
}
