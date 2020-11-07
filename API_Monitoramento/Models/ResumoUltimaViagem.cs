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
        public double nivelTanque { get; set; }
        public int avarias { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }
        public int codigoVeiculo { get; set; }
        public double temperaturaMaxima { get; set; }
        public double velocidadeMaxima { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }

    }
    public class ResumoRequest : ResumoUltimaViagem
    {
        public int codigoUsuario { get; set; }
        
    }
}
