using ASM_GS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.Json;
namespace ASM_GS.Controllers
{
    public class LoginAndSignUp : Controller
    {
        private readonly ApplicationDbContext _context;
        private string MaTaiKhoanDuocTao;
        public LoginAndSignUp(ApplicationDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        private readonly IConfiguration _configuration;
        private string GenerateNewAccountId()
        {
            var lastAccount = _context.TaiKhoans
                                      .OrderByDescending(t => t.MaTaiKhoan)
                                      .FirstOrDefault();

            int newIdNumber = 0;

            if (lastAccount != null && lastAccount.MaTaiKhoan.StartsWith("TK"))
            {

                string lastIdNumberPart = lastAccount.MaTaiKhoan.Substring(2);

                if (int.TryParse(lastIdNumberPart, out int lastIdNumber))
                {
                    newIdNumber = lastIdNumber + 1;
                }
            }

            
            return "TK" + newIdNumber.ToString("D3"); // 
        }
        public IActionResult Index()
        {
            var clientId = _configuration["Authentication:Google:ClientId"];
            ViewData["GoogleClientId"] = clientId;

            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginModelView model)
        {
            if (!ModelState.IsValid)
            {
                var errors = new Dictionary<string, string>();

                // Kiểm tra và thêm lỗi cho từng trường
                if (ModelState.ContainsKey(nameof(model.EmailOrUsername)))
                {
                    var emailErrors = ModelState[nameof(model.EmailOrUsername)].Errors;
                    if (emailErrors.Any())
                        errors["EmailOrUsername"] = emailErrors.First().ErrorMessage;
                }

                if (ModelState.ContainsKey(nameof(model.Password)))
                {
                    var passwordErrors = ModelState[nameof(model.Password)].Errors;
                    if (passwordErrors.Any())
                        errors["Password"] = passwordErrors.First().ErrorMessage;
                }

                return Json(new { success = false, errors });
            }

            var user = _context.TaiKhoans
                .FirstOrDefault(u => (u.Email == model.EmailOrUsername || u.TenTaiKhoan == model.EmailOrUsername)
                                     && u.MatKhau == model.Password && (u.TinhTrang==1 || u.TinhTrang==2));

            if (user == null)
            {
                return Json(new { success = false, message = "Sai email, tên tài khoản hoặc mật khẩu" });
            }
            var Kh = _context.KhachHangs.FirstOrDefault(u => (u.MaKhachHang == user.MaKhachHang));
            string khJson = JsonSerializer.Serialize(Kh);
            HttpContext.Session.SetString("UserId", user.MaTaiKhoan);
            HttpContext.Session.SetString("User", khJson);
            return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
        }
        [HttpPost]
        public IActionResult SignUp(RegisterModelView model)
        {
            if (!ModelState.IsValid)
            {
                // Create a dictionary to store errors for each field
                var errors = new Dictionary<string, string>();

                // Add specific field errors if they exist in the model state
                if (ModelState.ContainsKey(nameof(model.TenTaiKhoan)))
                {
                    var usernameErrors = ModelState[nameof(model.TenTaiKhoan)].Errors;
                    if (usernameErrors.Any())
                        errors["TenTaiKhoan"] = usernameErrors.First().ErrorMessage;
                }

                if (ModelState.ContainsKey(nameof(model.Email)))
                {
                    var emailErrors = ModelState[nameof(model.Email)].Errors;
                    if (emailErrors.Any())
                        errors["Email"] = emailErrors.First().ErrorMessage;
                }

                if (ModelState.ContainsKey(nameof(model.Password)))
                {
                    var passwordErrors = ModelState[nameof(model.Password)].Errors;
                    if (passwordErrors.Any())
                        errors["Password"] = passwordErrors.First().ErrorMessage;
                }

                if (ModelState.ContainsKey(nameof(model.ConfirmPassword)))
                {
                    var confirmPasswordErrors = ModelState[nameof(model.ConfirmPassword)].Errors;
                    if (confirmPasswordErrors.Any())
                        errors["ConfirmPassword"] = confirmPasswordErrors.First().ErrorMessage;
                }

                return Json(new { success = false, errors });
            }

            // Check if username or email already exists
            if (_context.TaiKhoans.Any(u => u.TenTaiKhoan == model.TenTaiKhoan || u.Email == model.Email))
            {
                return Json(new { success = false, message = "Tên tài khoản hoặc email đã tồn tại" });
            }

            MaTaiKhoanDuocTao=GenerateNewAccountId();
            var newUser = new TaiKhoan
            {
                MaTaiKhoan = MaTaiKhoanDuocTao,
                TenTaiKhoan = model.TenTaiKhoan,
                Email = model.Email,
                MatKhau = model.Password,
                VaiTro = "User",
                TinhTrang = 1,
            };
            _context.TaiKhoans.Add(newUser);
            _context.SaveChanges();
            return Json(new { success = true, message = "Đăng ký thành công!" });
        }
        [HttpPost]
        public JsonResult ValidateCustomer(string TenKhachHang, string SoDienThoai, string DiaChi, string GioiTinh, string Cccd, string NgaySinh)
        {
            var errors = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(TenKhachHang))
            {
                errors.Add("TenKhachHang", "Tên khách hàng không được để trống.");
            }

            // Kiểm tra SoDienThoai
            if (string.IsNullOrEmpty(SoDienThoai))
            {
                errors.Add("SoDienThoai", "Số điện thoại không được để trống.");
            }
            else if (!Regex.IsMatch(SoDienThoai, @"^\d{10,11}$"))
            {
                errors.Add("SoDienThoai", "Số điện thoại không hợp lệ.");
            }

            // Kiểm tra DiaChi
            if (string.IsNullOrEmpty(DiaChi))
            {
                errors.Add("DiaChi", "Địa chỉ không được để trống.");
            }

            // Kiểm tra Cccd
            if (string.IsNullOrEmpty(Cccd))
            {
                errors.Add("Cccd", "Căn cước công dân không được để trống.");
            }

            // Kiểm tra NgaySinh
            if (string.IsNullOrEmpty(NgaySinh))
            {
                errors.Add("NgaySinh", "Ngày sinh không được để trống.");
            }

            // Kiểm tra nếu có lỗi
            if (errors.Count > 0)
            {
                return Json(new { success = false, errors = errors });
            }

            // Nếu tất cả hợp lệ
            return Json(new { success = true });
        }

    }
}
