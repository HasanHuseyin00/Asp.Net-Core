using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly DbBaglanti _context;

        public UrunlerController(DbBaglanti context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index(string sortOrder, string search, string currentFilter, int? pageNumber, int?[] kategori, Category category)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = search;

            ViewData["Category"] = _context.Categories;


            if (search != null)
            {
                pageNumber = 1;
            }
            else
            {
                search = currentFilter;
            }

            var product = from s in _context.Products
                          where s.ProductIsActive == true
                          select s;


            if (kategori != null)
            {
                for (int i = 1; i < kategori.Length; i++)
                {
                    product = product.Where(s => s.CategoryId == i);
                }
            }



            if (!String.IsNullOrEmpty(search))
            {
                product = product.Where(s => s.ProductName.Contains(search));
            }



            int pageSize = 6;
            return View(await PaginatedList<Product>.CreateAsync(product.Include(c => c.Category).AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
