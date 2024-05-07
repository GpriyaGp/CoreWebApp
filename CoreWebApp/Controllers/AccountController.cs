using CoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult WeaklyTypedLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPost(string username, string password)
        {
            ViewBag.Username = username;
            ViewBag.Password = password;
            return View();
        }
        public IActionResult StronglyTypedLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginSuccess(LoginViewModel login)
        {
            if(login.Name != null && login.Password != null)
            {
                if(login.Name == "Admin" && login.Password == "admin")
                {
                    ViewBag.Message = "Successfully logged in as admin";
                    return View();
                }
            }
            ViewBag.Message = "Invalid credentials";
            return View();
        }

        public IActionResult defaultLogin()
        {
            var user = new LoginViewModel()
            {
                Name = "Priya",
                Password = "TheBest"
            };
            return View(user);
        }

        public IActionResult usersList()
        {
            var usersList = new List<LoginViewModel>() { 
            new LoginViewModel(){Name="Gp",Password="123" },
            new LoginViewModel(){Name="Gokula",Password="456" },
            new LoginViewModel(){Name="Gokuls",Password="789" }
            };
            return View(usersList);
        }

        public IActionResult GetAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostAccount(Account account)
        {
            if (ModelState.IsValid)
            {
                return View(account);
            }
            return View("GetAccount");
        }

    }
}
