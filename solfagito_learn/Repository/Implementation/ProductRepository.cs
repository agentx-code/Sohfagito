using Microsoft.EntityFrameworkCore;
using solfagito_learn.Data;
using solfagito_learn.Models.Products;
using solfagito_learn.Models.Users;
using solfagito_learn.Repository.Interface;
using System.Reflection.Metadata.Ecma335;

namespace solfagito_learn.Repository.Implementation
{

    public class ProductRepository  : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CategoryViewModel> ListCategory(int? page = 1, int? pageSize = 5, string? search = null)
        {
            try
            {
                var query = _context.Category.AsQueryable();
                if (!string.IsNullOrEmpty(search)) 
                {
                    query = query.Where(c => c.category_name.Contains(search) || c.description.Contains(search));
                }
                var totalcategory = await query.CountAsync();
                if (page.HasValue && pageSize.HasValue)
                {
                    query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
                }

                var categories = await query.ToListAsync();

                return new CategoryViewModel
                {
                    page = page ?? 1,
                    pageSize = pageSize ?? 5,
                    totalItems = totalcategory,
                    Category = categories
                };
            }
            catch (Exception ex) 
            {
                throw;
            }
        }


        public async Task<ProductViewModel> ListProduct(int? page = 1, int? pageSize = 5, string? search = null)
        {
            try
            {
                var query = _context.Product.Include(c => c.category).AsQueryable();
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(c => c.product_name.Contains(search) || c.description.Contains(search));
                }
                var totalproduct = await query.CountAsync();

                if (page.HasValue && pageSize.HasValue)
                {
                    query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
                }

                var Products = await query.ToListAsync();

                return new ProductViewModel
                {
                    page = page ?? 1,
                    pageSize = pageSize ?? 10,
                    totalItems = totalproduct,
                    Product = Products
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<Products?> CreateProduct(Products products)
        {
           
            products.id = Guid.NewGuid();
            products.created_at = DateTime.Now;
            await _context.Product.AddAsync(products);
            await _context.SaveChangesAsync();

            return products;
        }

        public async Task<List<Categorys>> ReturnCategory()
        {
            return await _context.Category.ToListAsync();
            
        }
    }
}
