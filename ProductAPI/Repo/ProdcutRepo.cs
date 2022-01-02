using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.DataAccess;
using ProductAPI.DataAccess.DTO;
using ProductAPI.DataAccess.Model;

namespace ProductAPI.Repo
{
    public class ProdcutRepo : IProductRepo
    {
        private readonly ProductContext _db;
        private IMapper _mapper;

       public ProdcutRepo(ProductContext db,IMapper mapper) {
            _db = db;
            _mapper = mapper;
        }


        public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDTO);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            return _mapper.Map<List<ProductDTO>>(await _db.Products.ToListAsync());
        }
    }
}
