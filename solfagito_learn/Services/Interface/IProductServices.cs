using solfagito_learn.Models.Products;

namespace solfagito_learn.Services.Interface
{
    public interface IProductServices
    {
        Task<CategoryViewModel> ListCategory(int? page = 1, int? pageSize = 5, string? search = null);

        Task<ProductViewModel> ListProduct(int? page = 1, int? pageSize = 5, string? search = null);

    }
}
