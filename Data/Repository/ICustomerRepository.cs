using ProductCustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCustomer.Data.Repository
{
    public interface ICustomerRepository : IEntityBaseRepository<Customer>
    {
    }
}
