using CollabManage.Models;
using CollabManage.Models.ViewModel;
using CollabManage.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CollabManage.Controllers;

public class EmployeesController : Controller
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    [Route("colaboradores/{id?}")]
    public async Task<IActionResult> Index()
    {
        var list = _employeeService.FindAll();
        if (list == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Colaboradores não encontrados." });
        }

        return View(list);
    }

    [Route("colaboradores/detalhes/{id?}")]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido." });
        }

        var employee = await _employeeService.Details(id);
        if (employee == null)
        {
            return RedirectToAction(nameof(Error), new { message = $"Colaborador Id:{id} não encontrado." });
        }

        return View(employee);
    }

    [Route("colaboradores/criar/{id?}")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Create(Employee employee)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(nameof(Index));
        }

        await _employeeService.InsertAsync(employee);
        return RedirectToAction(nameof(Index));
    }

    [Route("colaboradores/editar/{id?}")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = $"Id do colaborador não foi fornecido." });
        }

        var employee = await _employeeService.FindById(id);
        if (employee == null)
        {
            return RedirectToAction(nameof(Error), new { message = $"Colaborador ID:{id} não encontrado." });
        }

        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Employee employee)
    {
        if (id != employee.Id)
        {
            return RedirectToAction(nameof(Error), new { message = "Id's não correspondem." });
        }
        try
        {
            _employeeService.Update(employee);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return RedirectToAction(nameof(Error), new { message = $"Erro {ex.Message}" });
        }
    }

    [Route("colaboradores/excluir/{id?}")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = "Id do colaborador não fornecido." });
        }

        var employee = await _employeeService.FindById(id);
        if (employee == null)
        {
            return RedirectToAction(nameof(Error), new { message = $"Colaborador ID:{id} não encontrado." });
        }

        return View(employee);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (id == null)
        {
            return RedirectToAction(nameof(Error), new { message = $"Id do colaborador não fornecido." });
        }
        try
        {
            await _employeeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return RedirectToAction(nameof(Error), new { message = $"Erro {ex.Message}" });
        }
    }

    [Route("colaboradores/erro/{id?}")]
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
