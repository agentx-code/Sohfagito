using solfagito_learn.Models.Products;

namespace solfagito_learn.Repository.Interface
{
    public interface IProductRepository
    {
        Task<CategoryViewModel> ListCategory(int? page = 1, int? pageSize = 5, string? search = null);

        Task<ProductViewModel> ListProduct(int? page = 1, int? pageSize = 5, string? search = null);

        Task<Products?> CreateProduct(Products products);
       
    }
}
