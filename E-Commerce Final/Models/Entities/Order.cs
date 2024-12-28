using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Final.Models.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerIDD {  get; set; }
        [ForeignKey("CustomerIDD")]
        public Customer customer { get; set; }
        public DateTime OrderDate {  get; set; }
        public decimal TotalAmount {  get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
