using EFCoreWithAsp.netCore.ViewModels;
using EFCoreWithAsp.netCore.Data;
namespace EFCoreWithAsp.netCore.Repositories
{
    public interface IChartRepo
    {
        Task<List<DeptEmployeeCount>> GetDeptEmployeeCountsAsync();
    }
}
