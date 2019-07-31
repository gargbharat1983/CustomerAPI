using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerAPI.Models;
using CustomerAPI.Models.Repository;
using Microsoft.AspNetCore.Cors;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
      public class CustomersController : ControllerBase
    {

        private readonly IDataRepository<Customer> _dataRepository;
        public CustomersController(IDataRepository<Customer> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult> GetCustomerAsync()
        {
            IEnumerable<Customer> customers = await _dataRepository.GetAllAsync();
            return Ok(customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "GetCustomerAsync")]
        public async Task<ActionResult> GetCustomerAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = await _dataRepository.GetAsync(id);

            if (customer == null)
            {
                return NotFound("The Customer record couldn't be found.");
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCustomerAsync([FromRoute] int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (customer == null)
            {
                return BadRequest("Customer is null.");
            }
            if (id != customer.Id)
            {
                return BadRequest("Invalid Customer.");
            }
            Customer customerToUpdate =  await _dataRepository.GetAsync(id);
            if (customerToUpdate == null)
            {
                return NotFound("The Customer record couldn't be found.");
            }
            await _dataRepository.UpdateAsync(customerToUpdate, customer);
            return NoContent();

        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult> PostCustomerAsync([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (customer == null)
            {
                return BadRequest("Customer is null.");
            }

           await _dataRepository.AddAsync(customer);
            // return Created()
            return CreatedAtRoute(
                  "GetCustomerAsync",
                  new { Id = customer.Id },
                  customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomerAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = await _dataRepository.GetAsync(id);
            if (customer == null)
            {
                return NotFound("The Customer record couldn't be found.");
            }

            await _dataRepository.DeleteAsync(customer);

            return Ok(customer);
        }

    }
}
