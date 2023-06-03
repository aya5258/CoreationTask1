
using ProductCustomer.Data.Repository;
using ProductCustomer.Models;

namespace ProductCustomer.Data.Services
{
    public interface ICustomerService : IEntityBaseRepository<Customer>
    {
    }
}
