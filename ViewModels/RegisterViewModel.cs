using System.ComponentModel.DataAnnotations;

namespace ASPDotnetWebApplication.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$",
            ErrorMessage = "Password must be at least 6 characters long and include at least one uppercase letter, one lowercase letter, one number, and one symbol."
        )]
        public string? Password { get; set; }
    }
}

