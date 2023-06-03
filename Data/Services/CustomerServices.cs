
using System;

using ProductCustomer.Data.Repository;
using ProductCustomer.Models;


namespace ProductCustomer.Data.Services
{

    public class Customerservice : EntityBaseRepository<Customer> ,ICustomerService
    {
        public Customerservice(PCContex context) : base(context)
        {
        }
    }


}
