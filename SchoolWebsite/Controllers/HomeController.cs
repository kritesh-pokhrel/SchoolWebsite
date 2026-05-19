using Microsoft.AspNetCore.Mvc;

namespace GEMS_School.Controllers
{
    public class HomeController : Controller
    {
        private void SetFooterData()
        {
            ViewBag.FooterAbout = "GEMS School is a premier educational institution dedicated to providing quality education and holistic development to students.";
        }

        public IActionResult Index()
        {
            SetFooterData();
            ViewBag.Title = "Home";
            return View();
        }

        public IActionResult About()
        {
            SetFooterData();
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Admission()
        {
            SetFooterData();
            ViewBag.Title = "Admissions";
            return View();
        }

        public IActionResult Academics()
        {
            SetFooterData();
            ViewBag.Title = "Academics";
            return View();
        }

        public IActionResult Activities()
        {
            SetFooterData();
            ViewBag.Title = "Activities";
            return View();
        }

        public IActionResult Contact()
        {
            SetFooterData();
            ViewBag.Title = "Contact";
            return View();
        }
    }
}