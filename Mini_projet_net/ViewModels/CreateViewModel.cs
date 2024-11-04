using System.ComponentModel.DataAnnotations;

namespace Mini_projet_net.ViewModels
{
    public class CreateViewModel
    {
        public int articleId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Designation { get; set; }
        [Required]
        [Display(Name = "Prix en dinar :")]
        public float Prix { get; set; }
        [Required]
        [Display(Name = "Quantité en unité :")]
        public int Quantite { get; set; }
        [Required]
        [Display(Name = "Image :")]
        public IFormFile ImagePath { get; set; }
        public int categorieId { get; set; }

    }
}
