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
        /// Obter resumos.
        /// </summary>
        /// <response code="200">A lista de resumo foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de resumos.</response>
        [HttpGet]
        [Route("")]
        public IQueryable<ResumoUltimaViagem> GetresumoUltimaViagems([FromServices] dbContext context)
        {

            try
            {
                var listresumoUltimaViagems = context.resumoUltimaViagem.Select(resumoUltimaViagem => new ResumoUltimaViagem
                {

                    codigo = resumoUltimaViagem.codigo,
                    consumo = resumoUltimaViagem.consumo,
                    notaConducao = resumoUltimaViagem.notaConducao,
                    distancia = resumoUltimaViagem.distancia,
                    distanciaAbastecimento = resumoUltimaViagem.distanciaAbastecimento,
                    avarias = resumoUltimaViagem.avarias,
                    proximaRevisao = resumoUltimaViagem.proximaRevisao,
                    origem = resumoUltimaViagem.origem,
                    destino = resumoUltimaViagem.destino,
                    veiculo = resumoUltimaViagem.veiculo

                });

                return listresumoUltimaViagems;


            }
            catch (Exception ex)
            {
                return (IQueryable<ResumoUltimaViagem>)BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Obter um resumo específico por ID.
        /// </summary>
        /// <param name="id">ID do resumo.</param>
        /// <response code="200">O resumo foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado resumo com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o resumo.</response>
        [HttpGet]
        [Route("{id:int}")]
        public IQueryable<ResumoUltimaViagem> GetById([FromServices] dbContext context, int id)
        {

            try
            {
                var resumoUltimaViagem = context.resumoUltimaViagem.Where(x => x.codigo == id).Select(resumoUltimaViagem => new ResumoUltimaViagem
                {

                    codigo = resumoUltimaViagem.codigo,
                    consumo = resumoUltimaViagem.consumo,
                    notaConducao = resumoUltimaViagem.notaConducao,
                    distancia = resumoUltimaViagem.distancia,
                    distanciaAbastecimento = resumoUltimaViagem.distanciaAbastecimento,
                    avarias = resumoUltimaViagem.avarias,
                    proximaRevisao = resumoUltimaViagem.proximaRevisao,
                    origem = resumoUltimaViagem.origem,
                    destino = resumoUltimaViagem.destino,
                    veiculo = resumoUltimaViagem.veiculo

                }) ;

                return resumoUltimaViagem;


            }
            catch (Exception ex)
            {
                return (IQueryable<ResumoUltimaViagem>)BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ResumoUltimaViagem>> Post([FromServices] dbContext context, [FromBody] ResumoUltimaViagem model)
        {
            try
            {
                var resumoUltimaViagem = new ResumoUltimaViagem();
                context.Add(resumoUltimaViagem);

                resumoUltimaViagem.consumo = model.consumo;
                resumoUltimaViagem.notaConducao = model.notaConducao;
                resumoUltimaViagem.distancia = model.distancia;
                resumoUltimaViagem.distanciaAbastecimento = model.distanciaAbastecimento;
                resumoUltimaViagem.avarias = model.avarias;
                resumoUltimaViagem.proximaRevisao = model.proximaRevisao;
                resumoUltimaViagem.origem = model.origem;
                resumoUltimaViagem.destino = model.destino;
                resumoUltimaViagem.veiculo = model.veiculo;

                await context.SaveChangesAsync();
                return resumoUltimaViagem;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }


        [HttpPut]
        [Route("")]
        public async Task<ActionResult<ResumoUltimaViagem>> Put([FromServices] dbContext context, [FromBody] ResumoUltimaViagem model)
        {
            try
            {
                var resumoUltimaViagem = new ResumoUltimaViagem();
                resumoUltimaViagem = await context.resumoUltimaViagem.FirstOrDefaultAsync(x => x.codigo == model.codigo);

                if (resumoUltimaViagem != null)
                {
                    resumoUltimaViagem.consumo = model.consumo;
                    resumoUltimaViagem.notaConducao = model.notaConducao;
                    resumoUltimaViagem.distancia = model.distancia;
                    resumoUltimaViagem.distanciaAbastecimento = model.distanciaAbastecimento;
                    resumoUltimaViagem.avarias = model.avarias;
                    resumoUltimaViagem.proximaRevisao = model.proximaRevisao;
                    resumoUltimaViagem.origem = model.origem;
                    resumoUltimaViagem.destino = model.destino;
                    resumoUltimaViagem.veiculo = model.veiculo;

                    context.SaveChanges();
                    return resumoUltimaViagem;
                }

                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<string>> Delete([FromServices] dbContext context, int id)
        {
            try
            {
                var resumoUltimaViagem = new ResumoUltimaViagem();
                resumoUltimaViagem = await context.resumoUltimaViagem.FirstOrDefaultAsync(x => x.codigo == id);

                if (resumoUltimaViagem != null)
                {
                    context.resumoUltimaViagem.Remove(resumoUltimaViagem);
                    context.SaveChanges();
                    return Ok();
                }


                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}