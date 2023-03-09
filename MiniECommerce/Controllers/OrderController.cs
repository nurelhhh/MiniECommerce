using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Models;
using MiniECommerce.Services;

namespace MiniECommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly List<OrderGetModel> orderList = new List<OrderGetModel>();
        private readonly OrderService orderService;

        public OrderController(OrderService _orderService)
        {
            this.orderService = _orderService;
        }

        [HttpGet("/GetOrders")]
        public IEnumerable<OrderGetModel> Get()
        {
            return orderList;
        }

        [HttpPost("/CreateOrder")]
        public IActionResult Create([FromBody] OrderCreateModel model)
        {
            if (model.ItemId == Guid.Empty)
            {
                return BadRequest("ItemId cannot be all zero");
            }

            var newOrder = this.orderService.Create(model);
            orderList.Add(newOrder);
            return Ok(newOrder);
        }
    }
}