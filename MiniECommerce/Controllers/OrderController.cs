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
        public async Task<IActionResult> Create([FromBody] OrderCreateModel model)
        {
            if (model.ItemId == Guid.Empty)
            {
                return BadRequest("ItemId cannot be all zero");
            }

            (var item, var message) = await this.orderService.CheckItem(model.ItemId);
            if (item == null)
            {
                if (string.IsNullOrEmpty(message) == false)
                {
                    return BadRequest(message);
                }
                return BadRequest("Item cannot be found");
            }

            var newOrder = this.orderService.Create(item);
            orderList.Add(newOrder);
            return Ok(newOrder);
        }
    }
}