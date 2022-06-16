using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {

        private readonly DbBaglanti _context;

        public AccountController(DbBaglanti context)
        {
            _context = context;
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string ID, string PW)
        {
            string x = "admin";
            string y = "123";
            if (ID == x && PW == y)
            {
                HttpContext.Session.SetString("id", x);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
