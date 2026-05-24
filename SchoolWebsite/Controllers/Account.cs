using Microsoft.AspNetCore.Mvc;

namespace SchoolWebsite.Controllers
{
    public class Account : Controller
    {
        [HttpGet]
        public IActionResult AdminLogin()
        {
            ViewBag.Title = "AdminLogin";
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                return RedirectToAction("Index", "Admin");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        [HttpGet]
        public IActionResult TeacherLogin()
        {
            ViewBag.Title = "TeacherLogin";
            return View();
        }

        [HttpPost]
        public IActionResult TeacherLogin(string username, string password)
        {
            if (username == "teacher" && password == "teacher123")
            {
                return RedirectToAction("Index", "Teacher");
            }

            ViewBag.Error = "Invalid teacher credentials";
            return View();
        }

        [HttpGet]
        public IActionResult ParentLogin()
        {
            ViewBag.Title = "ParentsLogin";
            return View();
        }

        [HttpPost]
        public IActionResult ParentLogin(string username, string password, bool rememberMe)
        {
            // TODO: Replace with real DB validation
            if (username == "parent" && password == "12345")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }
    }
}
