using EFCoreWithAsp.netCore.Data;
using EFCoreWithAsp.netCore.Models;
using EFCoreWithAsp.netCore.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWithAsp.netCore.Repositories
{
    public class Teacherrepo : ITeacherrepo
    {
        private readonly AppDbContext _dbContext;
        public Teacherrepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(TeacherViewModel employee)
        {
            var newEmployee = new Teacher()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                PhoneNumber = employee.PhoneNumber,
                Gender = employee.Gender,
                Email = employee.Email,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId,

            };
            await _dbContext.Teacher.AddAsync(newEmployee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            Teacher employee = await _dbContext.Teacher.FindAsync(Id);
            _dbContext.Teacher.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TeacherViewModel> GetAllAsync()
        {
            var employees = _dbContext.Teacher
            .Include(e => e.Department)
            .Select(e => new TeacherViewModel
            {
                TeacherId = e.TeacherId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                DateOfBirth = e.DateOfBirth,
                Gender = e.Gender,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Address = e.Address,
                IsActive = e.IsActive,
                Salary = e.Salary,
                DepartmentId = e.DepartmentId,
                Name = e.Department.Name
            });

            return employees;
        }



        public async Task<TeacherViewModel> GetByIdAsync(int id)
        {
            var employee = await _dbContext.Teacher.FindAsync(id);
            var employeeViewModel = new TeacherViewModel
            {
                TeacherId = employee.TeacherId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId
            };
            return employeeViewModel;
        }

        public async Task UpdateAsync(TeacherViewModel employeeUpdated)
        {
            var employee = await _dbContext.Teacher.FindAsync(employeeUpdated.TeacherId);
            employee.FirstName = employeeUpdated.FirstName;
            employee.LastName = employeeUpdated.LastName;
            employee.Email = employeeUpdated.Email;
            employee.DateOfBirth = employeeUpdated.DateOfBirth;
            employee.PhoneNumber = employeeUpdated.PhoneNumber;
            employee.Address = employeeUpdated.Address;
            employee.Salary = employeeUpdated.Salary;
            employee.DepartmentId = employeeUpdated.DepartmentId;
            employee.IsActive = employeeUpdated.IsActive;
            _dbContext.Teacher.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
