using EFCoreWithAsp.netCore.Models;
using EFCoreWithAsp.netCore.ViewModels;

namespace EFCoreWithAsp.netCore.Repositories
{
    public interface ITeacherrepo

    {
        Task<TeacherViewModel> GetByIdAsync(int id);
        IQueryable<TeacherViewModel> GetAllAsync();
        Task AddAsync(TeacherViewModel employee);
        Task UpdateAsync(TeacherViewModel employee);
        Task DeleteAsync(int Id);

        Task<List<Department>> GetAllDepartments();
    }

}
