using System.ComponentModel.DataAnnotations;

namespace NextwoFinalApp.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password" ,ErrorMessage ="Not Match")]
        public string? ConfirmPassword { get; set; }

    }
}
