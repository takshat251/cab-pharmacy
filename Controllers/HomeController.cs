using Microsoft.AspNetCore.Mvc;

namespace CAB_Pharmacy.Controllers
{
    public class HomeController : Controller
    {
            public IActionResult Index()
            {
                return View();
            }
    }

}
