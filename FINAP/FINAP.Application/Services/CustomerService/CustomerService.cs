using FINAP.Application.Interfaces.ICustomerService;
using FINAP.Domain.Interfaces.ICustomerRepository;
using FINAP.Domain.Models.Customer;
using FINAP.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAP.Application.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var response = await _customerRepository.GetCustomers();

            return response;
        }
        public async Task<Response> addEditCustomer(Customer customer)
        {
            var response = await _customerRepository.addEditCustomer(customer);

            return response;
        }


    }
}
