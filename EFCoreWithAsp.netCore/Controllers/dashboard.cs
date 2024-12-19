using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class DashboardController : Controller
    {
        private static int count = 0; // Biến lưu trữ số đếm

        // Action hiển thị trang
        public IActionResult dashboard()
        {
            return View(count);  // Trả về view 'Dashboard' và truyền giá trị bộ đếm
        }

        // Action tăng số
        [HttpPost]
        public IActionResult Increment()
        {
            count++; // Tăng số
            return Json(count);  // Trả về giá trị mới dưới dạng JSON
        }

        // Action giảm số
        [HttpPost]
        public IActionResult Decrement()
        {
            count--; // Giảm số
            return Json(count);  // Trả về giá trị mới dưới dạng JSON
        }
    }
}
