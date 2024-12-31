using Microsoft.AspNetCore.Mvc;

namespace finalproject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Kiểm tra thông tin đăng nhập (không sử dụng database, chỉ kiểm tra với dữ liệu cố định)
            if (username == "admin" && password == "1234")
            {
                // Nếu đăng nhập thành công, chuyển hướng đến trang chủ
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Nếu đăng nhập thất bại, hiển thị thông báo lỗi
                ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return View();
            }
        }
    }
}