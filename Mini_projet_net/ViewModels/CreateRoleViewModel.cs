using System.ComponentModel.DataAnnotations;

namespace Mini_projet_net.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]

        public string RoleName { get; set; }
    }
}
