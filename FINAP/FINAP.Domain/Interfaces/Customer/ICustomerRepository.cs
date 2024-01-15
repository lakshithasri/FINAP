using FINAP.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FINAP.Domain.Models.Customer;

namespace FINAP.Domain.Interfaces.ICustomerRepository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Response> addEditCustomer(Customer customer);
    }
}
