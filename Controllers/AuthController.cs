using Microsoft.AspNetCore.Mvc;
using Models;

namespace technova_ecom.Controllers
{
    public class AuthController : Controller
    {
        private DatabaseContext _db;

        public AuthController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
