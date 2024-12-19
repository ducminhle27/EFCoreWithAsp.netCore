using EFCoreWithAsp.netCore.ViewModels;
using EFCoreWithAsp.netCore.Data;
namespace EFCoreWithAsp.netCore.Repositories
{
    public interface IEmployeeSalaryRepo
    {
        Task<List<TopSalaryEmployee>> GetTop5HighestSalaryAsync();
    }
}
