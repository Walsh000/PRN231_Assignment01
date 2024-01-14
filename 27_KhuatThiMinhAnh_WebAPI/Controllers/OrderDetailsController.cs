using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    [Route("api/OrderDetails")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailRepository repository = new OrderDetailRepository();

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails() => repository.GetOrderDetails();

        // GET: api/OrderDetails/5
        [HttpGet("OrderId/{id}")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetail = repository.GetOrderDetailsByOrderId(orderId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return orderDetail;
        }

        [HttpGet("ProductId/{id}")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetailsByProductId(int productId)
        {
            var orderDetail = repository.GetOrderDetailsByProductId(productId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return orderDetail;
        }

        [HttpGet("{orderId}/{productId}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(int orderId, int productId)
        {
            var orderDetail = repository.GetOrderDetail(orderId, productId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return orderDetail;
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{orderId}/{productId}")]
        public async Task<IActionResult> PutOrderDetail(int orderId, int productId, OrderDetail orderDetail)
        {
            try
            {
                repository.UpdateOrderDetail(orderDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(orderId, productId))
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

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Create")]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail([FromBody] OrderDetail orderDetail)
        {
            repository.AddOrderDetail(orderDetail);
            return NoContent();
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> DeleteOrderDetail(int orderId, int productId)
        {
            var orderDetail = repository.GetOrderDetail(orderId, productId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            repository.DeleteOrderDetail(orderDetail);
            return NoContent();
        }

        private bool OrderDetailExists(int orderId, int productId)
        {
            return repository.GetOrderDetail(orderId, productId) != null;
        }
    }
}
