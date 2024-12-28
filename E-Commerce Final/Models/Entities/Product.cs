namespace E_Commerce_Final.Models.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity {  get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
