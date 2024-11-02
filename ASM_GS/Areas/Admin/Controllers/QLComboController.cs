using ASM_GS.Controllers;
using ASM_GS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Thêm thư viện này để sử dụng Include
using System.Linq;
using X.PagedList;
using X.PagedList.Extensions;

namespace ASM_GS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QLComboController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QLComboController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Index - Hiển thị danh sách Combo
        public IActionResult Index(string searchTerm, int? page, int pageSize = 5, int? trangThai = null, string sortBy = "TenCombo")
        {
            // Truy vấn tất cả các combo và bao gồm dữ liệu liên quan
            var combos = _context.Combos
                                 .Include(c => c.ChiTietCombos)
                                 .AsQueryable();

            // Lọc combo theo từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                combos = combos.Where(c => c.TenCombo.Contains(searchTerm) || c.MaCombo.Contains(searchTerm));
            }

            // Lọc combo theo trạng thái nếu được chỉ định
            if (trangThai.HasValue)
            {
                combos = combos.Where(c => c.TrangThai == trangThai.Value);
            }

            // Sắp xếp theo tiêu chí được chọn
            switch (sortBy)
            {
                case "MaCombo":
                    combos = combos.OrderBy(c => c.MaCombo);
                    break;
                case "TenCombo":
                default:
                    combos = combos.OrderBy(c => c.TenCombo);
                    break;
            }

            // Phân trang kết quả
            var pageNumber = page ?? 1;
            var pagedCombos = combos.ToPagedList(pageNumber, pageSize);

            // Truyền tham số về lại view
            ViewBag.SearchTerm = searchTerm;
            ViewBag.PageSize = pageSize;
            ViewBag.TrangThai = trangThai;
            ViewBag.SortBy = sortBy;

            return View(pagedCombos);
        }


        // Hiển thị form tạo mới Combo
        public IActionResult Create()
        {
            // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            ViewBag.SanPhams = _context.SanPhams.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Combo combo, List<string> selectedSanPhams)
        {
            // Kiểm tra nếu không có sản phẩm nào được chọn
            if (selectedSanPhams == null || !selectedSanPhams.Any())
            {
                ModelState.AddModelError("selectedSanPhams", "Vui lòng chọn ít nhất một sản phẩm.");
            }

            // Kiểm tra mã Combo đã tồn tại hay chưa
            if (_context.Combos.Any(c => c.MaCombo == combo.MaCombo))
            {
                ModelState.AddModelError("MaCombo", "Mã Combo đã tồn tại. Vui lòng nhập mã khác.");
            }

            // Kiểm tra nếu ModelState không hợp lệ
            if (!ModelState.IsValid)
            {
                // Truyền lại danh sách sản phẩm vào ViewBag để hiển thị trong form
                ViewBag.SanPhams = _context.SanPhams.ToList();
                return View(combo); // Trả về view với thông tin lỗi
            }

            // Thêm Combo vào cơ sở dữ liệu
            _context.Combos.Add(combo);
            _context.SaveChanges();

            // Thêm các sản phẩm vào Combo
            foreach (var maSanPham in selectedSanPhams)
            {
                var chiTietCombo = new ChiTietCombo
                {
                    MaCombo = combo.MaCombo,
                    MaSanPham = maSanPham,
                    SoLuong = 1 // Mặc định là 1
                };
                _context.ChiTietCombos.Add(chiTietCombo);
            }
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Thêm combo thành công!";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combo = _context.Combos
                                .Include(c => c.ChiTietCombos)
                                .FirstOrDefault(c => c.MaCombo == id);
            if (combo == null)
            {
                return NotFound();
            }

            // Xóa các sản phẩm trong ChiTietCombos trước khi xóa Combo
            foreach (var chiTiet in combo.ChiTietCombos)
            {
                _context.ChiTietCombos.Remove(chiTiet);
            }

            _context.Combos.Remove(combo);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Xóa combo thành công!";
            return RedirectToAction("Index");
        }
        // Phương thức hiển thị chi tiết Combo
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Lấy Combo cùng với các ChiTietCombos và AnhSanPhams
            var combo = _context.Combos
                                .Include(c => c.ChiTietCombos)
                                    .ThenInclude(ct => ct.MaSanPhamNavigation)
                                        .ThenInclude(sp => sp.AnhSanPhams)
                                .FirstOrDefault(c => c.MaCombo == id);

            if (combo == null)
            {
                return NotFound();
            }

            // Trả về một partial view cho yêu cầu AJAX
            return PartialView("_ComboDetailsPartial", combo);
        }
        // Phương thức Edit
        public IActionResult Edit(string id)
        {
            if (id == null) return NotFound();

            var combo = _context.Combos
                                .Include(c => c.ChiTietCombos)
                                .FirstOrDefault(c => c.MaCombo == id);
            if (combo == null) return NotFound();

            // Truyền danh sách sản phẩm vào ViewBag để hiển thị checkbox
            ViewBag.SanPhams = _context.SanPhams.ToList();

            // Trả về partial view với chi tiết combo
            return PartialView("_ComboEditPartial", combo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Combo combo, List<string> selectedSanPhams)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SanPhams = _context.SanPhams.ToList();
                return PartialView("_ComboEditPartial", combo); // Trả về partial view với thông tin lỗi
            }
            if (selectedSanPhams == null || !selectedSanPhams.Any())
            {
                ModelState.AddModelError("selectedSanPhams", "Vui lòng chọn ít nhất một sản phẩm.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.SanPhams = _context.SanPhams.ToList();
                return PartialView("_ComboEditPartial", combo);
            }

            var existingCombo = _context.Combos.Include(c => c.ChiTietCombos).FirstOrDefault(c => c.MaCombo == combo.MaCombo);
            if (existingCombo == null) return NotFound();

            existingCombo.TenCombo = combo.TenCombo;
            existingCombo.MoTa = combo.MoTa;
            existingCombo.Gia = combo.Gia;
            existingCombo.TrangThai = combo.TrangThai;

            _context.ChiTietCombos.RemoveRange(existingCombo.ChiTietCombos);

            foreach (var maSanPham in selectedSanPhams)
            {
                var chiTietCombo = new ChiTietCombo
                {
                    MaCombo = combo.MaCombo,
                    MaSanPham = maSanPham,
                    SoLuong = 1
                };
                _context.ChiTietCombos.Add(chiTietCombo);
            }

            _context.SaveChanges();

            TempData["SuccessMessage"] = "Cập nhật combo thành công!";
            return RedirectToAction("Index");
        }
    }
}

