using CollabManage.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollabManage.Controllers
{
    public class CompanysController : Controller
    {
        private readonly CompanyService _companyService;

        public CompanysController(CompanyService companyService)
        {
            _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
        }

        public async Task<IActionResult> Index()
        {
            List<Models.Company> list = _companyService.FindAll();
            return View(list);
        }
    }
}
