using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ASM_GS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var maTaiKhoan = HttpContext.Session.GetString("StaffAccount");
            var profilePicture = HttpContext.Session.GetString("ProfilePicture") ?? "/assets/assets/img/avatars/default.png";
            if (string.IsNullOrEmpty(maTaiKhoan))
            {
                HttpContext.Session.SetString("RedirectUrl", HttpContext.Request.GetDisplayUrl());
                ViewData["RedirectUrl"] = HttpContext.Session.GetString("RedirectUrl");
            }

            // Retrieve session values for name and role
            var userName = HttpContext.Session.GetString("StaffName");
            var userRole = HttpContext.Session.GetString("StaffRole");

            

            // Pass values to the view
            ViewBag.UserName = userName;
            ViewBag.UserRole = userRole;
            ViewBag.ProfilePicture = profilePicture;

            return View();
            
		}
        [HttpPost]
        public IActionResult RemoveRoutedFromLoginSession()
        {
            HttpContext.Session.Remove("RedirectUrl");
            ViewData["RedirectUrl"] = HttpContext.Session.GetString("RedirectUrl");
            return Ok();
        }
        [HttpPost]
        public IActionResult RemoveStaffAccount()
        {
            HttpContext.Session.Remove("StaffAccount");
            HttpContext.Session.Remove("Staff");
            return RedirectToAction("Index", "LoginAdmin", new { area = "" });
        }
    }
}
