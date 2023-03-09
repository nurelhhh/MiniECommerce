using Item.API.Models;

namespace Item.API.Services
{
    public class ItemService
    {

        public ItemGetModel Create(ItemCreateModel model)
        {
            var newItemId = Guid.NewGuid();
            var newItem = new ItemGetModel
            {
                ItemId = newItemId,
                ItemName = model.ItemName
            };
            return newItem;
        }

    }
}
