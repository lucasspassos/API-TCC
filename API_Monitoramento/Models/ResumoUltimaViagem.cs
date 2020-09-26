using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Monitoramento.Models
{
    public class ResumoUltimaViagem
    {
        [Key]
        public int codigo { get; set; }
        public double consumo { get; set; }
        public double notaConducao { get; set; }
        public double distancia { get; set; }
        public double distanciaAbastecimento { get; set; }
        public int avarias { get; set; }
        public double proximaRevisao { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }

        [ForeignKey("resumo_fk_veiculo")]
        public Veiculo veiculo { get; set; }

    }
}
