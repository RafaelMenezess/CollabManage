using CollabManage.Models.ViewModel;
using CollabManage.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CollabManage.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HomeService _homeService;

    public HomeController(ILogger<HomeController> logger, HomeService employeeService)
    {
        _logger = logger;
        _homeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
    }

    public IActionResult Index()
    {
        var employees = _homeService.FindAllEmployee();

        return View(employees);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
