using Microsoft.AspNetCore.Mvc;
using ASM_GS.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore; // Để sử dụng các phương thức của EF Core

namespace ASM_GS.Controllers
{
    public class DonHangLSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonHangLSController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách đơn hàng
        public IActionResult Index()
        {
            // Lấy ID người dùng đăng nhập từ session
            string userAccount = HttpContext.Session.GetString("UserAccount");
            string userId = HttpContext.Session.GetString("User");

            // Nếu session không có giá trị, chuyển hướng về trang đăng nhập
            if (string.IsNullOrEmpty(userAccount) || string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "LoginAndSignUp"); // Điều này sẽ chuyển người dùng tới trang đăng nhập
            }

            // Lấy danh sách đơn hàng của người dùng dựa trên ID khách hàng
            var orders = _context.DonHangs
                .Where(h => h.MaKhachHang == userId) // Lọc theo mã khách hàng
                .Select(h => new DonHangViewModel
                {
                    MaHoaDon = h.MaDonHang,
                    MaKhachHang = h.MaKhachHang,
                    NgayXuatHoaDon = h.NgayDatHang,
                    TongTien = h.TongTien,
                    TrangThai = h.TrangThai
                }).ToList();

            return View(orders);
        }

        // Hiển thị chi tiết một đơn hàng
        public IActionResult Details(string id)
        {
            var order = _context.DonHangs
                .Where(h => h.MaDonHang == id) // Lọc theo mã đơn hàng
                .Select(h => new DonHangViewModel
                {
                    MaHoaDon = h.MaDonHang,
                    MaKhachHang = h.MaKhachHang,
                    NgayXuatHoaDon = h.NgayDatHang, // Sử dụng NgayDatHang (Ngày đặt hàng)
                    TongTien = h.TongTien,
                    TrangThai = h.TrangThai,
                    ChiTietHoaDons = h.ChiTietDonHangs.Select(ct => new ChiTietHoaDonViewModel
                    {
                        MaSanPham = ct.MaSanPham,
                        SoLuong = ct.SoLuong,
                        Gia = ct.Gia
                    }).ToList()
                })
                .FirstOrDefault();

            if (order == null)
            {
                return NotFound();
            }

            return View(order); // Truyền chi tiết đơn hàng vào view
        }
    }
}
