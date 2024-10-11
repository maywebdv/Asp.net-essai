using System.ComponentModel.DataAnnotations;

namespace tp3.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Confim password")]
        [Compare("Password",
            ErrorMessage ="Pssword and confirmation paswword do not match.")]
        public string? ConfirmPassword { get; set; } 
    }
}
