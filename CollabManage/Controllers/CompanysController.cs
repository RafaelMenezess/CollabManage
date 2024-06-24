using CollabManage.Models;
using CollabManage.Models.ViewModel;
using CollabManage.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            List<Company> list = _companyService.FindAll();
            if (list == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Empresas não encontradas." });
            }

            return View(list);
        }

        [Route("empresa/detalhes/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            var campany = await _companyService.Details(id);
            if (campany == null)
            {
                return RedirectToAction(nameof(Error), new { message = $"Empresa Id:{id} não encontrada." });
            }

            return View(campany);
        }

        [Route("empresa/editar/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = $"Id não fornecido." });
            }

            var campany = await _companyService.FindById(id);
            if (campany == null)
            {
                return RedirectToAction(nameof(Error), new { message = $"Empresa Id:{id} não encontrada." });
            }

            return View(campany);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            if (id != company.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id's não correspondem." });
            }
            try
            {
                _companyService.Update(company);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error), new { message = $"Erro: {ex.Message}" });
            }
        }

        [Route("empresa/erro/{id?}")]
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}

