using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages.Authentication
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Xóa token từ cookie
            Response.Cookies.Delete("AccessToken");

            // Chuyển hướng người dùng đến trang nào đó sau khi logout thành công
            return RedirectToPage("/Authentication/Login");
        }
    }
}
