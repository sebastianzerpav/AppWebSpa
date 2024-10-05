using Microsoft.AspNetCore.Mvc;
using AppWebSpa.Data;
using AppWebSpa.Models;
namespace AppWebSpa.Controllers
{
    public class SpaServicesController : Controller
    {
        private readonly AppDbContext _context;
        public SpaServicesController(AppDbContext context) {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //IEnumerable<SpaService> services = await _context.SpaService;
            return View();
        }
    }
}
