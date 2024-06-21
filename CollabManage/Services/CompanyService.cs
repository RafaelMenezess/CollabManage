using CollabManage.Data;
using CollabManage.Models;

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
        return _context.Company.ToList();
    }
}
