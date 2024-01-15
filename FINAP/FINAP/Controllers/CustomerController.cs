using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Newtonsoft.Json.Linq;
using System.Linq;
using FINAP.Insfrastructure.Repositories.CustomerRepo;
using FINAP.Domain.Models.Customer;
using FINAP.Application.Interfaces.ICustomerService;

namespace FINAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customer;

        public CustomerController(ICustomerService customer)
        {
            _customer = customer;
        }

        [HttpGet]
        [Route("getCustomer")]
        public async Task<IActionResult> GetCustomers()
        {
            var response = await _customer.GetCustomers();
            return Ok(new { result = response });
        }

        [HttpPost]
        [Route("addEditCustomer")]
        public async Task<IActionResult> addEditCustomer([FromBody] Customer customer)
        {
            var response = await _customer.addEditCustomer(customer);
            return Ok(new { result = response });
        }
    }
}
