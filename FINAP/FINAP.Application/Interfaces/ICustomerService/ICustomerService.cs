using FINAP.Domain.Models.Customer;
using FINAP.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAP.Application.Interfaces.ICustomerService
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Response> addEditCustomer(Customer customer);
    }
}
