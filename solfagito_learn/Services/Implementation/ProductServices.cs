using Microsoft.EntityFrameworkCore.Metadata.Internal;
using solfagito_learn.Models.Products;
using solfagito_learn.Repository.Interface;
using solfagito_learn.Services.Interface;

namespace solfagito_learn.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository )
        {
            _productRepository = productRepository;
        }
        public async Task<CategoryViewModel> ListCategory(int? page = 1, int? pageSize = 5, string? search = null)
        {
            return await _productRepository.ListCategory(page, pageSize, search);
        }


        public async Task<ProductViewModel> ListProduct(int? page = 1, int? pageSize = 5, string? search = null)
        {
            return await _productRepository.ListProduct(page, pageSize, search);
        }

    }
}
