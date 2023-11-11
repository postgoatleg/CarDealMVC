using CarDealMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealMVC.Controllers
{

    public class CarDealController : Controller
    {
        private readonly CarDealerContext _context;
        public CarDealController(CarDealerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mod = new HomeViewModel(_context);
            return View(model: mod);
        }
    }
}
