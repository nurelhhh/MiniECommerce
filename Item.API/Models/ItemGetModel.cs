namespace Item.API.Models
{
    public class ItemGetModel
    {
        public Guid ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
    }
}
