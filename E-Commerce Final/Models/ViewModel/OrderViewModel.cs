using E_Commerce_Final.Models.Entities;

namespace E_Commerce_Final.Models.ViewModel
{
    public class OrderViewModel
    {
        
        public int CustomerIDD {  get; set; }
        public IEnumerable<Customer> customers{  get; set; }
        public int ProductIDD {  get; set; }
        public IEnumerable<Product> Products { get; set; }
        public int Quantity {  get; set; }
        public int TotalAmount {  get; set; }
    }
}
