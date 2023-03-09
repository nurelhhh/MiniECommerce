using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Models;

namespace MiniECommerce.Services
{
    public class OrderService
    {
        public OrderGetModel Create(OrderCreateModel model)
        {
            var newOrderId = Guid.NewGuid();

            var newOrder = new OrderGetModel
            {
                OrderId = newOrderId,
                Date = DateTime.Now,
                ItemId = model.ItemId,
                ItemName = "testing" // for testing only
            };
            return newOrder;
        }
    }
}
