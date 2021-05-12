using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GesProduct.Models
{
    public class Category
    {
        [Key]
        public int IdCat { get; set; }
        [Required(ErrorMessage = "veuillez remplir ce champ")]
        public string Nomcat { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
