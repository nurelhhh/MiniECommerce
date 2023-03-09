namespace MiniECommerce.Models
{
    public class OrderGetModel
    {
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public DateTime Date { get; set; }
    }
}
