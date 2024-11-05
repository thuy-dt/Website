using ASM_GS.Controllers;
using ASM_GS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASM_GS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public KhachHangController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/KhachHang
        public async Task<IActionResult> Index()
        {
            var khachHangs = await _context.KhachHangs.ToListAsync();
            return View(khachHangs);
        }

        // GET: Admin/KhachHang/Create
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_UserCreatePartial");
        }

        // POST: Admin/KhachHang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KhachHang khachHang)
        {
            if (string.IsNullOrWhiteSpace(khachHang.MaKhachHang))
            {
                ModelState.AddModelError("MaKhachHang", "Mã khách hàng không được để trống.");
            }

            if (ModelState.IsValid)
            {
                if (khachHang.Anh != null)
                {
                    var fileName = $"{Guid.NewGuid()}_{khachHang.Anh.FileName}";
                    var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "img/AnhKhachHang");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    var filePath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await khachHang.Anh.CopyToAsync(stream);
                    }
                    khachHang.HinhAnh = $"img/AnhKhachHang/{fileName}";
                }

                khachHang.NgayDangKy = DateOnly.FromDateTime(DateTime.Now);
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thêm khách hàng thành công!";
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_UserCreatePartial", khachHang);
        }

        // GET: Admin/KhachHang/Edit/5
        // GET: Admin/KhachHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return PartialView("_UserEditPartial", khachHang);
        }

        // POST: Admin/KhachHang/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, KhachHang khachHang)
        {
            if (id != khachHang.MaKhachHang)
            {
                return NotFound();
            }

            
            
                // Tìm khách hàng hiện tại trong cơ sở dữ liệu
                var existingKhachHang = await _context.KhachHangs.FindAsync(id);
                if (existingKhachHang == null)
                {
                    return NotFound();
                }

                existingKhachHang.TenKhachHang = khachHang.TenKhachHang;
                existingKhachHang.DiaChi = khachHang.DiaChi;
                existingKhachHang.SoDienThoai = khachHang.SoDienThoai;
                existingKhachHang.Cccd = khachHang.Cccd;
                existingKhachHang.NgaySinh = khachHang.NgaySinh;
                existingKhachHang.GioiTinh = khachHang.GioiTinh;
                existingKhachHang.TrangThai = khachHang.TrangThai;

                // Xử lý ảnh mới nếu có
                if (khachHang.Anh != null)
                {
                    var fileName = $"{Guid.NewGuid()}_{khachHang.Anh.FileName}";
                    var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "img/AnhKhachHang");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    var filePath = Path.Combine(folderPath, fileName);

                    // Xóa ảnh cũ nếu tồn tại
                    if (!string.IsNullOrEmpty(existingKhachHang.HinhAnh))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, existingKhachHang.HinhAnh);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await khachHang.Anh.CopyToAsync(stream);
                    }
                    existingKhachHang.HinhAnh = $"img/AnhKhachHang/{fileName}";
                }
                _context.Update(existingKhachHang);
                var result = await _context.SaveChangesAsync();

                if (result > 0) 
                {
                    TempData["SuccessMessage"] = "Cập nhật khách hàng thành công!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Không có thay đổi nào được thực hiện.");
                }     
            TempData["ErrorMessage"] = "Cập nhật không thành công!";
            return PartialView("_UserEditPartial", khachHang);
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var khachHang = _context.KhachHangs.Find(id); 
            if (khachHang == null)
            {
                return NotFound();
            }

            _context.KhachHangs.Remove(khachHang);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Xoá khách hàng thành công!";
            return Json(new { success = true, message = "Xóa thành công." });
        }

        private bool KhachHangExists(string id)
        {
            return _context.KhachHangs.Any(e => e.MaKhachHang == id);
        }
    }
}
