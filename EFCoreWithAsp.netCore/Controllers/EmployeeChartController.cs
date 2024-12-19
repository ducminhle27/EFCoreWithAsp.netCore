using EFCoreWithAsp.netCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EFCoreWithAsp.netCore.Controllers
{
    public class EmployeeChartController : Controller
    {
        private readonly IChartRepo _chartRepo;

        // Dependency Injection
        public EmployeeChartController(IChartRepo chartRepo)
        {
            _chartRepo = chartRepo;
        }

        // GET: /EmployeeChart/PieChart
        public IActionResult PieChart()
        {
            return View(); // Hiển thị trang Pie Chart
        }

        // API GET: /EmployeeChart/GetEmployeeCounts
        [HttpGet]
        public async Task<IActionResult> GetEmployeeCounts()
        {
            // Lấy dữ liệu từ Repository
            var data = await _chartRepo.GetDeptEmployeeCountsAsync();
            return Json(data); // Trả về dữ liệu JSON cho biểu đồ
        }
    }
}
