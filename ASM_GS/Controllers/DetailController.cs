using Microsoft.AspNetCore.Mvc;
using ASM_GS.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASM_GS.Controllers
{
    public class DetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string id)
        {
            var sanPham = _context.SanPhams
                                  .Include(sp => sp.AnhSanPhams)
                                  .Include(sp => sp.DanhGia) // Bao gồm đánh giá để tính toán xếp hạng trung bình
                                  .FirstOrDefault(sp => sp.MaSanPham == id);

            if (sanPham == null)
            {
                return NotFound();
            }

            // Tính trung bình số sao
            double averageRating = 0;
            if (sanPham.DanhGia.Any())
            {
                averageRating = sanPham.DanhGia.Average(dg => dg.SoSao);
            }

            ViewBag.AverageRating = averageRating; // Truyền giá trị trung bình vào View
            return View(sanPham);
        }

        [HttpPost]
        public IActionResult SubmitReview(string maSanPham, string name, int rating, string comment)
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (!User.Identity.IsAuthenticated)
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang LoginAndSignUp
                return RedirectToAction("LoginAndSignUp", "Index");
            }

            if (ModelState.IsValid)
            {
                // Lấy tên người dùng hoặc ID từ thông tin đăng nhập
                string maKhachHang = User.Identity.Name;
                if (string.IsNullOrEmpty(maKhachHang))
                {
                    // Xử lý trường hợp không có tên khách hàng (nếu cần)
                    // Ví dụ: return RedirectToAction("LoginAndSignUp", "Account");
                }

                var review = new DanhGia
                {
                    MaDanhGia = Guid.NewGuid().ToString(),
                    MaSanPham = maSanPham,
                    MaKhachHang = maKhachHang, // Sử dụng tên người dùng đã đăng nhập
                    NoiDung = comment,
                    SoSao = rating
                };

                // Lưu đánh giá vào cơ sở dữ liệu
                _context.DanhGia.Add(review);
                _context.SaveChanges();

                // Chuyển hướng về trang Index sau khi gửi đánh giá thành công
                return RedirectToAction("Index", new { id = maSanPham });
            }

            // Nếu ModelState không hợp lệ, vẫn trả về View hiện tại với model không hợp lệ
            var sanPham = _context.SanPhams
                                  .Include(sp => sp.AnhSanPhams)
                                  .Include(sp => sp.DanhGia)
                                  .FirstOrDefault(sp => sp.MaSanPham == maSanPham);

            double averageRating = sanPham?.DanhGia.Any() == true
                                   ? sanPham.DanhGia.Average(dg => dg.SoSao)
                                   : 0;

            ViewBag.AverageRating = averageRating;
            return View("Index", sanPham);
        }



    }
}
