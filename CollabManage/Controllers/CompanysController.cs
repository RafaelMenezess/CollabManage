using CollabManage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollabManage.Controllers
{
    public class CompanysController : Controller
    {
        private readonly CollabManageContext _context;

        public CompanysController(CollabManageContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Company.ToListAsync());
        }
    }
}
