using ShoeShop.Models;
using ShoeShop.Models.Enum;
using ShoeShop.Models.ViewModel;

namespace ShoeShop.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductListViewModel> GetAllProduct(string sort, int productPage, int pageSize);
        Task<ProductListViewModel> Search(string keyword, int page, int pageSize);
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductsDeal();
        Task<IEnumerable<Product>> GetProductsHint();
        Task<IEnumerable<Product>> GetProductByCategory(Category Category);
        Task<ProductListViewModel> GetProductsByCategory(Category category, Gender gender,string sort , int pageProduct, int pageSize);
        Task<IEnumerable<Product>> GetProductByName(string Name);
        Task<IEnumerable<Product>> GetProductByBrand(Brand Brand);
        Task<IEnumerable<Product>> GetProductByGender(Gender Gender);
        Task<Product> getProductByIdAsyn(int id);
        Task<Product> getProductByIdAsNoTracking(int id);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(int id);
        bool Save();
    }
}
