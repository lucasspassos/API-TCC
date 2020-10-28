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
    public class VeiculoController : ControllerBase
    {

        /// <summary>
        /// Obter veículos.
        /// </summary>
        /// <response code="200">A lista de veículo foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de veículos.</response>
        [HttpGet]
        [Route("")]
        public IQueryable<Veiculo> Getveiculos([FromServices] dbContext context)
        {

            try
            {
                var listveiculos = context.veiculo.Select(veiculo => new Veiculo
                {

                    codigo = veiculo.codigo,
                    marca = veiculo.marca,
                    modelo = veiculo.modelo,
                    anoFabricacao = veiculo.anoFabricacao,
                    cod_usuario = veiculo.cod_usuario

                });

                return listveiculos;


            }
            catch (Exception ex)
            {
                return (IQueryable<Veiculo>)BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Obter um veículo específico por ID.
        /// </summary>
        /// <param name="id">ID do veículo.</param>
        /// <response code="200">O veículo foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado veículo com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o veículo.</response>
        [HttpGet]
        [Route("{id:int}")]
        public IQueryable<Veiculo> GetById([FromServices] dbContext context, int id)
        {

            try
            {
                var veiculo = context.veiculo.Where(x => x.codigo == id).Select(veiculo => new Veiculo
                {

                    codigo = veiculo.codigo,
                    marca = veiculo.marca,
                    modelo = veiculo.modelo,
                    anoFabricacao = veiculo.anoFabricacao,
                    cod_usuario = veiculo.cod_usuario

                });

                return veiculo;


            }
            catch (Exception ex)
            {
                return (IQueryable<Veiculo>)BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Veiculo>> Post([FromServices] dbContext context, [FromBody] Veiculo model)
        {
            try
            {
                var veiculo = new Veiculo();
                context.Add(veiculo);

                veiculo.marca = model.marca;
                veiculo.modelo = model.modelo;
                veiculo.anoFabricacao = model.anoFabricacao;
                veiculo.cod_usuario = model.cod_usuario;

                await context.SaveChangesAsync();
                return veiculo;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }


        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Veiculo>> Put([FromServices] dbContext context, [FromBody] Veiculo model)
        {
            try
            {
                var veiculo = new Veiculo();
                veiculo = await context.veiculo.FirstOrDefaultAsync(x => x.codigo == model.codigo);

                if (veiculo != null)
                {
                    veiculo.codigo = model.codigo;
                    veiculo.marca = model.marca;
                    veiculo.modelo = model.modelo;
                    veiculo.anoFabricacao = model.anoFabricacao;
                    veiculo.cod_usuario = model.cod_usuario;

                    context.SaveChanges();
                    return veiculo;
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
                var veiculo = new Veiculo();
                veiculo = await context.veiculo.FirstOrDefaultAsync(x => x.codigo == id);

                if (veiculo != null)
                {
                    context.veiculo.Remove(veiculo);
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