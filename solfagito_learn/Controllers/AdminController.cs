using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using solfagito_learn.Services.Interface;

namespace solfagito_learn.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IProductServices _productServices;
        public AdminController( IUserServices userServices, IProductServices productServices )
        {
            _userServices = userServices;
            _productServices = productServices;
        }
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> Users(int? page = 1, int? pageSize = 10, string? search = null)
        {
            var users = await _userServices.User(page, pageSize, search);
            return View(users);
        }
        public async Task<IActionResult> Category(int? page = 1, int? pageSize = 5, string? search = null)
        {
            var category = await _productServices.ListCategory(page, pageSize, search);
            return View(category);
        }

        public async Task<IActionResult> Products(int? page = 1, int? pageSize = 5, string? search = null)
        {
            var product = await _productServices.ListProduct(page, pageSize, search);
            return View(product);
        }

       
    }
}
