using CollabManage.Data;
using CollabManage.Models;
using CollabManage.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CollabManage.Services;

public class CompanyService
{
    private readonly CollabManageContext _context;
    public CompanyService(CollabManageContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Company> FindAll()
    {
        return _context.Company.OrderBy(x => x.Name).ToList();
    }

    public Task<Company> FindById(int? id)
    {
        if (id == null || _context.Employee == null)
        {
            throw new NotFoundException("Id não pode ser nulo");
        }

        return _context.Company.FirstOrDefaultAsync(m => m.Id == id);
    }

    public Task<Company> Details(int? id)
    {
        if (id == null || _context.Employee == null)
        {
            throw new NotFoundException("Id não encontrado");            
        }

        Task<Company> company = _context.Company
            .FirstOrDefaultAsync(m => m.Id == id);
        if (company == null)
        {
            throw new NotFoundException("Id não encontrado");            
        }
        return company;
    }

    public void Update(Company company)
    {
        if (!_context.Company.Any(x=> x.Id == company.Id))
        {
            throw new NotFoundException("Id não encontrado");
        }
        try
        {
            _context.Company.Update(company);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new DbUpdateException(ex.Message);
        }
    }
}
