using EFCoreWithAsp.netCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreWithAsp.netCore.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        private readonly IEmployeeSalaryRepo _employeeSalaryRepo;

        public EmployeeSalaryController(IEmployeeSalaryRepo employeeSalaryRepo)
        {
            _employeeSalaryRepo = employeeSalaryRepo;
        }

        // API trả về dữ liệu cho Bar Chart
        [HttpGet]
        public async Task<IActionResult> BarChartData()
        {
            var top5Employees = await _employeeSalaryRepo.GetTop5HighestSalaryAsync();
            return Json(top5Employees);
        }

        // Action render View BarChart.cshtml
        public IActionResult BarChart()
        {
            return View("~/Views/EmployeeSalary/BarChart.cshtml");
        }
    }
}
