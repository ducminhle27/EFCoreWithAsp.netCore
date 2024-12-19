using EFCoreWithAsp.netCore.Data;
using EFCoreWithAsp.netCore.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWithAsp.netCore.Repositories
{
    public class EmployeeSalaryRepo : IEmployeeSalaryRepo
    {
        private readonly AppDbContext _context;

        public EmployeeSalaryRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TopSalaryEmployee>> GetTop5HighestSalaryAsync()
        {
            return await _context.Employees
                .OrderByDescending(e => e.Salary)
                .Take(5)
                .Select(e => new TopSalaryEmployee
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary
                })
                .ToListAsync();
        }
    }
}
