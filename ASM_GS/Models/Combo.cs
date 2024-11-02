using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models
{
    public partial class Combo
    {
        [Key]
        [Required(ErrorMessage = "Mã Combo không được để trống")]

        public string MaCombo { get; set; } = null!;

        [Required(ErrorMessage = "Tên Combo không được để trống")]
        public string TenCombo { get; set; } = null!;

        public string? MoTa { get; set; } // Không bắt buộc, có thể để trống

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải là một số dương")]
        public decimal Gia { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn trạng thái")]
        public int TrangThai { get; set; }

        public virtual ICollection<ChiTietCombo> ChiTietCombos { get; set; } = new List<ChiTietCombo>();
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }
}
