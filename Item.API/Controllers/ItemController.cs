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
        public ActionResult<List<ItemGetModel>> GetAll()
        {
            return itemList;
        }

        [HttpPost("/GetItem")]
        public ActionResult<ItemGetModel> GetOne([FromBody] ItemFindModel model)
        {
            var item = itemList
                .Where(Q => Q.ItemId.Equals(model.ItemId))
                .FirstOrDefault();

            if (item == null)
            {
                return NotFound(null);
            }

            return item;
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