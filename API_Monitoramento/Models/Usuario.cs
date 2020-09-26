using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Monitoramento.Models
{
    public class Usuario
    {
        [Key]
        public int codigo { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

    }
}
