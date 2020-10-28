using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Monitoramento.Models
{
    public class Cadastro 
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string anoFabricacao { get; set; }
    }

}
