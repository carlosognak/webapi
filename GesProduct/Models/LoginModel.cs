using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GesProduct.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Le Nom d'utilisateur est obligatoire")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
