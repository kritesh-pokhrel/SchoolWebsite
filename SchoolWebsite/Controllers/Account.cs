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

    }
}
