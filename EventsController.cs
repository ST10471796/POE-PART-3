using Microsoft.AspNetCore.Mvc;

namespace RaceDay.Web.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
