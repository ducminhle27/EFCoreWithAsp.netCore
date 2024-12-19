using EFCoreWithAsp.netCore.ViewModels;
using EFCoreWithAsp.netCore.Data;
using Microsoft.EntityFrameworkCore;
namespace EFCoreWithAsp.netCore.Repositories
{
    public class ChartRepo : IChartRepo
    {
        private readonly AppDbContext _context;

        public ChartRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DeptEmployeeCount>> GetDeptEmployeeCountsAsync()
        {
            var data = await _context.Employees
                .GroupBy(e => e.DepartmentId)
                .Select(g => new DeptEmployeeCount
                {
                    DeptName = _context.Departments
                        .Where(d => d.DepartmentId == g.Key)
                        .Select(d => d.Name)
                        .FirstOrDefault(),
                    EmployeeCount = g.Count()
                })
                .ToListAsync();

            return data;
        }
    }
}
