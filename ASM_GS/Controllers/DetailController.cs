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
            // Lấy thông tin sản phẩm từ bảng SanPhams và bao gồm AnhSanPhams và DanhGia
            var sanPham = _context.SanPhams
                                  .Include(sp => sp.AnhSanPhams)
                                  .Include(sp => sp.DanhGia)
                                  .Include(sp => sp.MaDanhMucNavigation)
                                  .FirstOrDefault(sp => sp.MaSanPham == id);

            // Nếu không tìm thấy sản phẩm, trả về lỗi NotFound
            if (sanPham == null)
            {
                return NotFound();
            }

            // Tính điểm đánh giá trung bình
            double averageRating = 0;
            if (sanPham.DanhGia.Any())
            {
                averageRating = sanPham.DanhGia.Average(dg => dg.SoSao);
            }

            // Lấy tên khách hàng từ session
            string maKhachHang = HttpContext.Session.GetString("User");
            string tenKhachHang = "Khách hàng"; // Mặc định là "Khách hàng"

            if (!string.IsNullOrEmpty(maKhachHang))
            {
                var khachHang = _context.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (khachHang != null)
                {
                    tenKhachHang = khachHang.TenKhachHang;
                }
            }

            // Đặt giá trị vào ViewBag
            ViewBag.TenKhachHang = tenKhachHang; // Tên khách hàng
            ViewBag.AverageRating = averageRating; // Điểm đánh giá trung bình

            // Lấy danh sách đánh giá của sản phẩm theo MaSanPham
            var danhGia = _context.DanhGia
                         .Where(dg => dg.MaSanPham == id)
                         .Include(dg => dg.MaKhachHangNavigation) // Bao gồm khách hàng để lấy tên
                         .ToList();

            // Đặt danh sách đánh giá vào ViewBag
            ViewBag.DanhGia = danhGia;

            // Lấy danh sách sản phẩm liên quan theo danh mục
            var sanPhamLienQuan = _context.SanPhams
                .Include(sp => sp.AnhSanPhams)
                .Where(sp => sp.MaDanhMuc == sanPham.MaDanhMuc && sp.MaSanPham != id)
                .ToList();

            ViewBag.SanPhamLienQuan = sanPhamLienQuan;

            // Trả về View với sản phẩm
            return View(sanPham);
        }




        [HttpPost]
        public IActionResult SubmitReview(string maSanPham, string name, int rating, string comment)
        {
            if (ModelState.IsValid)
            {
                string maKhachHang = HttpContext.Session.GetString("User");
                if (string.IsNullOrEmpty(maKhachHang))
                {
                    return Json(new { success = false, message = "Vui lòng đăng nhập để đánh giá sản phẩm." });
                }

                var khachHang = _context.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (khachHang == null)
                {
                    return Json(new { success = false, message = "Khách hàng không tồn tại." });
                }

                var sanPham = _context.SanPhams.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
                if (sanPham == null)
                {
                    return Json(new { success = false, message = "Sản phẩm không tồn tại." });
                }

                var existingReview = _context.DanhGia.FirstOrDefault(dg => dg.MaSanPham == maSanPham && dg.MaKhachHang == maKhachHang);
                if (existingReview != null)
                {
                    return Json(new { success = false, message = "Bạn đã đánh giá sản phẩm này rồi." });
                }

                var review = new DanhGia
                {
                    MaDanhGia = Guid.NewGuid().ToString(),
                    MaSanPham = maSanPham,
                    MaKhachHang = maKhachHang,
                    NoiDung = comment,
                    SoSao = rating,
                    MaSanPhamNavigation = sanPham,
                    MaKhachHangNavigation = khachHang
                };

                _context.DanhGia.Add(review);
                _context.SaveChanges();

                return Json(new { success = true, message = "Cảm ơn bạn đã đánh giá sản phẩm!" });
            }

            return Json(new { success = false, message = "Đã có lỗi xảy ra." });
        }



    }
}