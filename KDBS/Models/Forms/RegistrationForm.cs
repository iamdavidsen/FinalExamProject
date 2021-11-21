using System.ComponentModel.DataAnnotations;

namespace KDBS.Models.Forms
{
    public class RegistrationForm
    {
        [Required]
        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Virksomhedsnavn")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Addresse")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "By")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Postnummer")]
        public int Zipcode { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
