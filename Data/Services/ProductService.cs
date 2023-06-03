using ProductCustomer.Data.Repository;
using ProductCustomer.Models;

namespace ProductCustomer.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IproductService
    {
        public ProductService(PCContex context) : base(context)
        {
        }
    }
}