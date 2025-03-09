using HelpDesk.Core.Entities;
using HelpDesk.Infrastructure.Dtos;
using HelpDesk.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("GetCustomers")]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("GetCustomerById/{id}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var value = await _customerRepository.GetByIdAsync(id);
            if (value == null) return NotFound("Customer not found.");
            return Ok(value);
        }

        [HttpGet("GetCustomerByEmail/{email}")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var value = await _customerRepository.GetUserByEmailAsync(email);
            if (value == null) return NotFound("Customer not found.");
            return Ok(value);
        }

        [HttpGet("GetCustomerByUserName/{userName}")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomerByUserName(string userName)
        {
            var value = await _customerRepository.GetUserByUserNameAsync(userName);
            if (value == null) return NotFound("Customer not found.");
            return Ok(value);
        }

        [HttpPost("CreateCustomer")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCustomer(CustomerDto dto)
        {
            await _customerRepository.CreateAsync(dto);
            return Ok("Customer created successfully.");
        }

        [HttpDelete("DeleteCustomer/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerRepository.DeleteAsync(id);
            return Ok("Customer deleted successfully.");
        }

        [HttpPut("UpdateCustomer/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCustomer(Guid id, CustomerDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await _customerRepository.UpdateAsync(dto);
            return Ok("Customer updated successfully.");
        }
    }
}
