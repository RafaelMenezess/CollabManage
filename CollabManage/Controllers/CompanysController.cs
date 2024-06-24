using CollabManage.Models;
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


        [Route("empresa/{id?}")]
        public async Task<IActionResult> Index()
        {
            List<Models.Company> list = _companyService.FindAll();
            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }

        [Route("empresa/detalhes/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            var campany = await _companyService.Details(id);
            if (campany == null)
            {
                return NotFound();
            }

            return View(campany);
        }

        [Route("empresa/editar/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campany = await _companyService.FindById(id);
            if (campany == null)
            {
                return NotFound();
            }

            return View(campany);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }
            try
            {
                _companyService.Update(company);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}

