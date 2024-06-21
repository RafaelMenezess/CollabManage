using CollabManage.Data;
using CollabManage.Models;

namespace CollabManage.Services.Exceptions;

public class HomeService
{
    private readonly CollabManageContext _context;
    public HomeService(CollabManageContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Employee> FindAllEmployee()
    {
        return _context.Employee.OrderByDescending(x => x.Id).Take(10).ToList();
    }

    public List<Company> FindAllCompanys()
    {
        return _context.Company.OrderBy(x => x.Name).ToList();
    }
}
