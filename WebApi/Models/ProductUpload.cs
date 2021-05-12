using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ProductUpload
    {
        public int IdPro { get; set; }
        public string NomPro { get; set; }
        public string DesPro { get; set; }
        public string ImagePro { get; set; }
        public int IdCat { get; set; }

        public virtual Category Category { get; set; }
        private IFormFile file { get; set; } 
    }
}
