using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Monitoramento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Monitoramento.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ResumoUltimaViagemController : ControllerBase
    {

        /// <summary>
        /// Obter ultimo resumo pelo id do cliente.
        /// </summary>
        /// <response code="200">A lista de resumo foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de resumos.</response>
        [HttpGet]
        [Route("{id:int}")]
        public ResumoUltimaViagem GetresumoUltimaViagem([FromServices] dbContext context, int id)
        {

            try
            {

                var veiculo = context.veiculo.FirstOrDefault(x => x.cod_usuario == id);

                var UltimoResumo = context.resumoUltimaViagem
                                   .Where(x => x.codigoVeiculo == veiculo.codigo)
                                   .OrderByDescending(x => x.dataTermino)
                                   .FirstOrDefault();

                return UltimoResumo;


            }

            catch (Exception ex)
            {
                return null;
            }
        }

       

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ResumoUltimaViagem>> Post([FromServices] dbContext context, [FromBody] ResumoRequest model)
        {
            try
            {
                var resumoUltimaViagem = new ResumoUltimaViagem();
                context.Add(resumoUltimaViagem);

                var veiculo = context.veiculo.FirstOrDefault(v => v.cod_usuario == model.codigoUsuario);


                resumoUltimaViagem.consumo = model.consumo;
                resumoUltimaViagem.notaConducao = model.notaConducao;
                resumoUltimaViagem.distancia = model.distancia;
                resumoUltimaViagem.avarias = model.avarias;
                resumoUltimaViagem.origem = model.origem;
                resumoUltimaViagem.destino = model.destino;
                resumoUltimaViagem.nivelTanque = model.nivelTanque;
                resumoUltimaViagem.temperaturaMaxima = model.temperaturaMaxima;
                resumoUltimaViagem.velocidadeMaxima = model.velocidadeMaxima;
                resumoUltimaViagem.codigoVeiculo = veiculo.codigo;
                resumoUltimaViagem.dataInicio = model.dataInicio;
                resumoUltimaViagem.dataTermino = model.dataTermino;

                await context.SaveChangesAsync();
                return resumoUltimaViagem;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

    }
}