namespace E_Commerce_Final.Models.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name {  get; set; }
        public string Email { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
