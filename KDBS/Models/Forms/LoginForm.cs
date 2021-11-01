using System.ComponentModel.DataAnnotations;

namespace KDBS.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Forbliv logget ind?")]
        public bool RememberMe { get; set; }
    }
}
