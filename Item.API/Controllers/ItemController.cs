using Item.API.Models;
using Item.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Item.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private static readonly List<ItemGetModel> itemList = new List<ItemGetModel>();
        private readonly ItemService itemService;

        public ItemController(ItemService _itemService)
        {
            this.itemService = _itemService;
        }

        [HttpGet("/GetItems")]
        public ActionResult<List<ItemGetModel>> Get()
        {
            return itemList;
        }

        [HttpPost("/CreateItem")]
        public ActionResult<ItemGetModel> Create([FromBody] ItemCreateModel model)
        {
            if (string.IsNullOrEmpty(model.ItemName) == true)
            {
                return BadRequest("Item name cannot be empty");
            }

            var newItem = this.itemService.Create(model);

            itemList.Add(newItem);

            return newItem;
        }
    }
}