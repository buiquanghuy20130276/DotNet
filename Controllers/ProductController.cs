using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Infrastructure;
using ShoeShop.Interfaces;
using ShoeShop.Models;
using ShoeShop.Models.Enum;
using ShoeShop.Models.ViewModel;
using System.Drawing.Printing;

namespace ShoeShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        private Cart GetCart()
        {
            var Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return Cart;

        }
        public async Task<IActionResult> Index(string genderStr = "All",string sort = "price_lowest", int page = 1, int pageSize = 9)

        {
            ViewData["selectedGenderStr"] = genderStr;
            ViewData["selectedPageSize"] = pageSize;
            ViewData["selectedSort"] = sort;
            ViewData["ActivePage"] = "Product";
            ProductListViewModel products = await repository.GetAllProduct(sort, page, pageSize);
            int cartItemCount = 0;
            foreach (var i in GetCart().Items)
            {
                cartItemCount += i.Quantity;
            }
            ViewBag.CartItemCount = cartItemCount;
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> Search(string keyword, int page = 1, int pageSize = 3)
        {
            ProductListViewModel products = await repository.Search(keyword, page, pageSize);

            return View("Index", products);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductPerPage(int productPerPage, int currentPage)
        {
            return RedirectToAction("Index", new { page = currentPage, pageSize = productPerPage });
        }
        public async Task<IActionResult> Detail(int id)
        {
            var product = await repository.getProductByIdAsyn(id);
            return View(product);
        }
        public async Task<IActionResult> CaterogyProduct(string type,string genderStr  ,string sort = "price_lowest", int page = 1, int pageSize = 9)
        {
            {
                
                    ViewData["selectedGenderStr"] = genderStr;
                if (Enum.TryParse(type, out Category category) && Enum.TryParse(genderStr, out Gender gender))
                {
                    ViewData["selectedType"] = type;
                    ViewData["selectedPageSize"] = pageSize;
                    ViewData["selectedSort"] = sort;
                    var products = await repository.GetProductsByCategory(category, gender, sort, page, pageSize);
                    int cartItemCount = 0;
                    foreach (var i in GetCart().Items)
                    {
                        cartItemCount += i.Quantity;
                    }
                    ViewBag.CartItemCount = cartItemCount;

                    if (products != null)
                    {
                        return View("Index", products);
                    }
                    else
                    {
                        return View("NoProductsFound");
                    }
                }
                else
                {
                    return View("NotFound");
                }
            }
        }
    }
}
