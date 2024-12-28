using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Final.Models.Entities
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int  OrderIDD{ get; set; }
        [ForeignKey("OrderIDD")]
        public Order order {  get; set; }
        public int ProductIDD { get; set; }
        [ForeignKey("ProductIDD")]
        public Product product { get; set; }
        public int Quantity {  get; set; }
        public decimal UnitPrice { get; set; }
    }
}
