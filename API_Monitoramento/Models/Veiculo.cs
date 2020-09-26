using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Monitoramento.Models
{
    public class Veiculo
    {
        [Key]
        public int codigo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string anoFabricacao { get; set; }

        [ForeignKey("veiculo_fk_usuario")]
        public Usuario usuario { get; set; }


    }
}
