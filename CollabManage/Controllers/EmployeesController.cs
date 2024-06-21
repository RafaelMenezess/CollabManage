using CollabManage.Models;
using CollabManage.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollabManage.Controllers;

public class EmployeesController : Controller
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    public async Task<IActionResult> Index()
    {
        var list = _employeeService.FindAll();
        if (list == null)
        {
            return NotFound();
        }

        return View(list);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _employeeService.Details(id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

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

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _employeeService.FindById(id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Employee employee)
    {
        if (id != employee.Id)
        {
            return BadRequest();
        }
        try
        {
            _employeeService.Update(employee);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _employeeService.FindById(id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (id == null)
        {
            return NotFound();
        }
        try
        {
            await _employeeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception)
        {
            throw;
        }
    }
}
