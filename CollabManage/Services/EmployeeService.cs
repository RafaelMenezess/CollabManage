using CollabManage.Data;
using CollabManage.Models;
using CollabManage.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CollabManage.Services;

public class EmployeeService
{
    private readonly CollabManageContext _context;
    public EmployeeService(CollabManageContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Employee> FindAll()
    {
        return _context.Employee.OrderBy(x => x.Name).ToList();
    }

    public Task<Employee> FindById(int? id)
    {
        if (id == null || _context.Employee == null)
        {
            throw new NotFoundException("Id não pode ser nulo");
        }

        return _context.Employee.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Employee> Details(int? id)
    {
        if (id == null || _context.Company == null)
        {
            throw new NotFoundException("Id não encontrado");
        }

        var employee = await _context.Employee.FirstOrDefaultAsync(m => m.Id == id);
        if (employee == null)
        {
            throw new NotFoundException("Id não encontrado");
        }
        return employee;
    }

    public async Task InsertAsync(Employee employee)
    {
        _context.Add(employee);
        await _context.SaveChangesAsync();
    }

    public void Update(Employee employee)
    {
        if (!_context.Employee.Any(x => x.Id == employee.Id))
        {
            throw new NotFoundException("Id não encontrado");
        }
        try
        {
            _context.Employee.Update(employee);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new DbUpdateException(ex.Message);
        }
    }

    public async Task Delete(int id)
    {
        var employee = await _context.Employee.FindAsync(id);
        if (employee != null)
        {
            _context.Employee.Remove(employee);
        }

        await _context.SaveChangesAsync();
    }
}
