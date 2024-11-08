using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Areas.Admin.Models
{
    public class dsCombo
    {
        [Required(ErrorMessage = "Mã Combo không được để trống")]
        public string MaCombo { get; set; } = null!;

        [Required(ErrorMessage = "Tên Combo không được để trống")]
        public string TenCombo { get; set; } = null!;

        public string? MoTa { get; set; } // Không bắt buộc, có thể để trống

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải là một số dương")]
        public decimal Gia { get; set; }

        [Required(ErrorMessage = "Trạng Thái không được để trống")]
        public int TrangThai { get; set; }
    }
}
