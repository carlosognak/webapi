using System.ComponentModel.DataAnnotations;

namespace GesProduct.Models
{
    public class Product
    {
        [Key]
        public int IdPro { get; set; }
        [Required(ErrorMessage = "veuillez remplir ce champ")]
        public string NomPro { get; set; }
        [Required(ErrorMessage = "veuillez remplir ce champ")]
        public string DesPro { get; set; }
        [Required(ErrorMessage = "veuillez sélectionner une image")]
        public string ImagePro { get; set; }
        
        public int IdCat { get; set; }

        public virtual Category Category { get; set; }
    }
}
