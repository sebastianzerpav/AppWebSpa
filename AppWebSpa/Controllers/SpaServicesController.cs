using Microsoft.AspNetCore.Mvc;
using AppWebSpa.Data;
using AppWebSpa.Models;
using Microsoft.EntityFrameworkCore;
namespace AppWebSpa.Controllers
{
    public class SpaServicesController : Controller
    {
        private readonly AppDbContext _context;
        public SpaServicesController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<SpaService> services = await _context.spaService.ToListAsync();
            return View(services);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpaService(SpaService service) {
            if (service == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else { 
                await _context.spaService.AddAsync(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<SpaService> FindSpaService(int id) {

            SpaService service = await _context.spaService.FindAsync(id);
            return service;
        }


    }
}
