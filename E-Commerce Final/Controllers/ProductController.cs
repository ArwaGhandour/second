using E_Commerce_Final.Models;
using E_Commerce_Final.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Final.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDBContext _appdb;
        public ProductController(AppDBContext appdb) { 
         _appdb=appdb;
        }
        public async Task<IActionResult> GetAllProducts()
        {
            var pro = await _appdb.Products.ToListAsync();
            return View(pro);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult>Create(Product product)
        {
            if (product != null)
            {
                await _appdb.AddAsync(product);
                await _appdb.SaveChangesAsync();
                return RedirectToAction("GetAllProducts");
            }
            return View(product); 
        }
        //public async Task <IActionResult>GetbyID(int id)
        //{
        //    var get = await _appdb.Products.FirstOrDefaultAsync(x => x.ProductID == id);
        //    return View(get);
        //}
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            //var upd = await GetbyID(id);
            var upd = await _appdb.Products.FirstOrDefaultAsync(x => x.ProductID == id);
            return View(upd);
        }
        [HttpPost]
        public async Task <IActionResult>Update(Product product)
        {
            if (product != null)
            {
                _appdb.Update(product);
                await _appdb.SaveChangesAsync();
                return RedirectToAction("GetAllProducts");
            }
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var del = await _appdb.Products.FirstOrDefaultAsync(x => x.ProductID == id);
            return View(del);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> Delete(Product product)
        {
            if (product != null)
            {
                 _appdb.Remove(product);
               await _appdb.SaveChangesAsync();
                return RedirectToAction("GetAllProducts");
            }
            return View(product);
        }
        public async Task<IActionResult> Details(int id)
        {
            var det = await _appdb.Products.FirstOrDefaultAsync(x => x.ProductID == id);
            return View(det);
        }
    }
}
