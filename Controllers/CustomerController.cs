using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductCustomer.Data.Services;
using ProductCustomer.Models;
using System.Data;

namespace ProductCustomer.Controllers
{

    [Authorize]
    public class CustomerController :Controller
    {
    
           private readonly ICustomerService _service;
 
        public CustomerController(ICustomerService service)
            {
                _service = service;
    
            }
        //get all Customers
            public  async Task<IActionResult> Index()
        {
            var customers = await _service.GetAllAsync();
            return View(customers);
        }
        //Get: Customers/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,Mobile,address")] Customer customer)
        {
           
              
           
            await _service.AddAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        //get order history
        public    IActionResult getorderhistory()
        {
         //   var customers = await _service.GetByIdAsync(customer.Id);

            var HistoryDto = new OrderDTO
            {
                ProductName = "Carpet", 
                customerName = "Aia",
                Price=675
            };
            return View(HistoryDto);
        }

    }
}
