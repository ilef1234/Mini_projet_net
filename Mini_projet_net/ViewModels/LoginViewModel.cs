using System.ComponentModel.DataAnnotations;

namespace Mini_projet_net.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
