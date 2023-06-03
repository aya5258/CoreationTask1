using Microsoft.AspNetCore.Mvc;
using ProductCustomer.Data.Services;

namespace ProductCustomer.Controllers
{
    public class ProductController : Controller
    {
   

        private readonly IproductService _service;

        public ProductController(IproductService service)
        {
            _service = service;
        }
        //get all Products
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();
            return View(products);
        }
    }
}
