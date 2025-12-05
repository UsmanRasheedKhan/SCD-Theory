using Microsoft.AspNetCore.Mvc;
using Models;
using technova_ecom.Models.Entities;

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

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                if(_db.Users.Any(u => u.UserName == user.UserName))
                {
                    ViewBag.ErrorMessage = "Username Already Exists! Please try another Username";
                    return View(user);
                }

                user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(user.HashedPassword);
                    
                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                return RedirectToAction("Login", "Auth");
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (_db.Users.Any(u => u.UserName == user.UserName))
                {
                    var loggedInUser = await _db.Users.FirstOrDefault(u => u.UserName.Equals(user.UserName));
                    //user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(user.HashedPassword);

                    if (BCrypt.Net.BCrypt.Verify(user.HashedPassword, loggedInUser.HashedPassword))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Incorrect Password";
                    }
                } else 
                {
                    ViewBag.ErrorMessage = "Incorrect Username";
                    return View(user);
                }
            }
            return View(user);
        }
    }
}
