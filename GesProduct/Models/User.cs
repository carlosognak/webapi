using System.ComponentModel.DataAnnotations;

namespace GesProduct.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Le Nom de l'utilisateur est obligatoire")]
        public string NomUser { get; set; }

        [Required(ErrorMessage = "Le Prénom de l'utilisateur est obligatoire")]
        public string PrenUser { get; set; }

        [Required(ErrorMessage = "Le Login est obligatoire")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [StringLength(12, ErrorMessage = "Doit comporter entre 4 et 12 caractères", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Mdp { get; set; }
    }
}
