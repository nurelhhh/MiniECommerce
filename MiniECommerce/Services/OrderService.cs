using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Models;
using RestSharp;

namespace MiniECommerce.Services
{
    public class OrderService
    {
        public async Task<(ItemModel? item, string message)> CheckItem(Guid itemId)
        {
            var baseUrl = "https://localhost:7155/";
            var endPoint = "GetItem";
            var client = new RestClient($"{baseUrl}{endPoint}");

            var jsonBody = new ItemRequestModel
            {
                ItemId = itemId
            };

            var request = new RestRequest()
                .AddJsonBody(jsonBody);

            ItemModel? item;
            try
            {
                item = await client.PostAsync<ItemModel>(request);
            }
            catch(Exception e)
            {
                return (null, e.Message);
            }

            return (item, string.Empty);
        }

        public OrderGetModel Create(ItemModel model)
        {
            var newOrderId = Guid.NewGuid();

            var newOrder = new OrderGetModel
            {
                OrderId = newOrderId,
                Date = DateTime.Now,
                ItemId = model.ItemId,
                ItemName = model.ItemName
            };
            return newOrder;
        }
    }
}
