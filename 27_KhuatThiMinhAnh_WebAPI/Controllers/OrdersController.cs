using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _27_KhuatThiMinhAnh_BusinessObjects.Models;
using _27_KhuatThiMinhAnh_Repositories.Interfaces;
using _27_KhuatThiMinhAnh_Repositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_KhuatThiMinhAnh_Asignment01.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository repository = new OrderRepository();

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders() => repository.GetOrders();

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var member = repository.GetOrderById(id);
            if (member == null)
            {
                return NotFound();
            }
            return member;
        }

        [HttpGet("GetOrdersByMember/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByMember(int id, Member member)
        {
            if (member == null)
            {
                return NotFound();
            }
            return repository.GetOrdersByMember(member);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            try
            {
                repository.UpdateOrder(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create")]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            repository.AddOrder(order);
            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = repository.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            repository.DeleteOrder(order);

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return repository.GetOrderById(id) != null;
        }
    }
}
