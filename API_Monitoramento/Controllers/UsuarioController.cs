using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_Monitoramento.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Monitoramento.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        protected readonly dbContext db;

        public UsuarioController(dbContext _db) => db = _db;


        /// <summary>
        /// Obter Usuários.
        /// </summary>
        /// <response code="200">A lista de usuário foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de usuários.</response>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Usuario>>> GetAction([FromServices] dbContext context)
        {
            var users = await db.usuario.ToListAsync();
            return users;
        }

        /// <summary>
        /// Obter um usuário específico por ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <response code="200">O usuário foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrado usuário com ID especificado.</response>
        /// <response code="500">Ocorreu um erro ao obter o usuário.</response>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Usuario>> GetById([FromServices] dbContext context, int id)
        {
            var users = await db.usuario.FirstOrDefaultAsync(x => x.codigo == id);
            return users;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Usuario>> Post([FromServices] dbContext context, [FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                db.usuario.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPut]
        [Route("")]
        public async Task<ActionResult<string>> Put([FromServices] dbContext context, [FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                context.usuario.Remove(model);
                await context.SaveChangesAsync();
                return "ok";
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<string>> Delete([FromServices] dbContext context, [FromBody] Usuario model)
        {
            if (ModelState.IsValid)
            {
                context.usuario.Remove(model);
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
