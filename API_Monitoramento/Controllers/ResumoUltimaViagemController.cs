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
        
        protected readonly dbContext db;

        public ResumoUltimaViagemController(dbContext _db) => db = _db;


        /// <summary>
        /// Obter Resumo de viagens.
        /// </summary>
        /// <response code="200">A lista de resumo foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de resumo.</response>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ResumoUltimaViagem>>> GetAction([FromServices] dbContext context)
        {
            var resumo = await db.resumoUltimaViagem.ToListAsync();
            return resumo;
        }

        /// <summary>
        /// Obter um Resumo específico por ID.
        /// </summary>
        /// <param name="id">ID do resumo.</param>
        /// <response code="200">O resumo foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado resumo com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o resumo.</response>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ResumoUltimaViagem>> GetById([FromServices] dbContext context, int id)
        {
            var resumo = await db.resumoUltimaViagem.FirstOrDefaultAsync(x => x.codigo == id);
            return resumo;
        }

        /// <summary>
        /// Criar um novo resumo
        /// </summary>
        /// <response code="200">O resumo foi cadastrado com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao cadastrar o resumo.</response>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ResumoUltimaViagem>> Post([FromServices] dbContext context, [FromBody] ResumoUltimaViagem model)
        {
           
            db.resumoUltimaViagem.Add(model);
            await context.SaveChangesAsync();
            return model;
            
        }

        /// <summary>
        /// Alterar um resumo.
        /// </summary>
        /// <response code="200">O resumo foi alterado com sucesso.</response>
        /// <response code="404">Não foi encontrado o resumo especificado.</response>
        /// <response code="500">Ocorreu um erro ao alterar o resumo.</response>
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<string>> Put([FromServices] dbContext context, [FromBody] ResumoUltimaViagem model)
        {
            context.resumoUltimaViagem.Update(model);
            await context.SaveChangesAsync();
            return "ok";
           
        }

        /// <summary>
        /// Remover um resumo específico por ID.
        /// </summary>
        /// <param name="id">ID do veículo.</param>
        /// <response code="200">O resumo foi removido com sucesso.</response>
        /// <response code="404">Não foi encontrado resumo com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao alterar o resumo.</response>
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<string>> Delete([FromServices] dbContext context, int id)
        {
            
            var resumo = await db.resumoUltimaViagem.FirstOrDefaultAsync(x => x.codigo == id);
            context.resumoUltimaViagem.Remove(resumo);
            await context.SaveChangesAsync();
            return "ok";
           
        }
    }
}
