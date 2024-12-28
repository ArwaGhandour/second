using E_Commerce_Final.Models;
using E_Commerce_Final.Models.Entities;
using E_Commerce_Final.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Final.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDBContext _appdb;
        public OrderController(AppDBContext appdb) { 
         _appdb=appdb;
        }
        public IActionResult Homee()
        {
          return View();
        }
        public async Task<IActionResult> GetAllOrders()
        {
            var ord = await _appdb.Orders.Include(x => x.customer).ToListAsync();
            return View (ord);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cust = await _appdb.Customers.ToListAsync();
            var prod = await _appdb.Products.ToListAsync();
            OrderViewModel o1 = new OrderViewModel()
            {
               customers=cust,
               Products=prod,
            };
            return View(o1);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel ovm,Product product)
        {
            var p = await _appdb.Products.FindAsync(ovm.ProductIDD);
            if (p == null)
            {
                
                return NotFound();
            }

            Order order = new Order()
            {
                CustomerIDD = ovm.CustomerIDD,
                TotalAmount = ovm.Quantity * p.Price,
                OrderDate=DateTime.Now,


            };
            await _appdb.Orders.AddAsync(order);
            await _appdb.SaveChangesAsync();

            OrderItem odt = new OrderItem()
            {
                
                ProductIDD=ovm.ProductIDD,
                Quantity=ovm.Quantity,
                OrderIDD=order.OrderID,
                UnitPrice=product.Price,
            };
            await _appdb.Items.AddAsync(odt);
            await _appdb.SaveChangesAsync();
            return RedirectToAction("Homee");
        }
    }
}
