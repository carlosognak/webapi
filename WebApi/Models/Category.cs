using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Category
    {
        [Key]
        public int IdCat { get; set; }
        public string Nomcat { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
