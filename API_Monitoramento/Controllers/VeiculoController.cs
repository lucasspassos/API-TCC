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

        protected readonly dbContext db;



        /// <summary>
        /// Obter Veículos.
        /// </summary>
        /// <response code="200">A lista de veículos foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de veículos.</response>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Veiculo>>> GetAction([FromServices] dbContext context)
        {
            var veiculos = await db.veiculo.ToListAsync();
            return veiculos;
        }

        /// <summary>
        /// Obter um veículo específico por ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <response code="200">O veículo foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado veículo com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o veículo.</response>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Veiculo>> GetById([FromServices] dbContext context, int id)
        {
            var users = await db.veiculo.FirstOrDefaultAsync(x => x.codigo == id);
            return users;
        }

        /// <summary>
        /// Criar um novo veículo
        /// </summary>
        /// <response code="200">O veículo foi cadastrado com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar o veículo.</response>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Veiculo>> Post([FromServices] dbContext context, [FromBody] Veiculo model)
        {
            if (ModelState.IsValid)
            {
                db.veiculo.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Alterar um veículo.
        /// </summary>
        /// <param name="id">ID do veículo.</param>
        /// <response code="200">O veículo foi alterado com sucesso.</response>
        /// <response code="404">Não foi encontrado o veículo especificado.</response>
        /// <response code="500">Ocorreu um erro ao alterar o veículo.</response>
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<string>> Put([FromServices] dbContext context, [FromBody] Veiculo model)
        {
            if (ModelState.IsValid)
            {
               
                context.veiculo.Update(model);
                await context.SaveChangesAsync();
                return "ok";
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Remover um veículo específico por ID.
        /// </summary>
        /// <param name="id">ID do veículo.</param>
        /// <response code="200">O veículo foi alterado com sucesso.</response>
        /// <response code="404">Não foi encontrado veículo com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao alterar o veículo.</response>
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<string>> Delete([FromServices] dbContext context, int id)
        {
            if (ModelState.IsValid)
            {
                var veiculo = await db.veiculo.FirstOrDefaultAsync(x => x.codigo == id);
                context.veiculo.Remove(veiculo);
                await context.SaveChangesAsync();
                return "ok";
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
