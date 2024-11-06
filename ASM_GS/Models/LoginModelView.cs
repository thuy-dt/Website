using System.ComponentModel.DataAnnotations;

namespace ASM_GS.Models
{
    public class LoginModelView
    {
        [Required(ErrorMessage = "Email hoặc tên tài khoản không được để trống")]
        public string EmailOrUsername { get; set; } = null!;

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; } = null!;
    }
}