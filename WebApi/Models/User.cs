using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string NomUser { get; set; }
        public string PrenUser { get; set; }
        public string Login { get; set; }
        public string Mdp { get; set; }
    }
}
