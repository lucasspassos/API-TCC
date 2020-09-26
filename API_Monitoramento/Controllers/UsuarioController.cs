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



        /// <summary>
        /// Obter Usuários.
        /// </summary>
        /// <response code="200">A lista de usuário foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de usuários.</response>
        [HttpGet]
        [Route("")]
        public IQueryable<Usuario> GetUsuarios([FromServices] dbContext context)
        {

            try
            {
                var listUsuarios = context.usuario.Select(usuario => new Usuario
                {

                    codigo = usuario.codigo,
                    nome = usuario.nome,
                    email = usuario.email,

                });

                return listUsuarios;


            }
            catch (Exception ex)
            {
                return (IQueryable<Usuario>)BadRequest(ex.ToString());
            }
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
        public IQueryable<Usuario> GetById([FromServices] dbContext context, int id)
        {

            try
            {
                var usuario = context.usuario.Where(x => x.codigo == id).Select(usuario => new Usuario
                {

                    codigo = usuario.codigo,
                    nome = usuario.nome,
                    email = usuario.email,

                });

                return usuario;


            }
            catch (Exception ex)
            {
                return (IQueryable<Usuario>)BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Usuario>> Post([FromServices] dbContext context, [FromBody] Usuario model)
        {
            try
            {
                var usuario = new Usuario();
                context.Add(usuario);

                usuario.email = model.email;
                usuario.nome = model.nome;
                usuario.senha = model.senha;

                await context.SaveChangesAsync();
                return usuario;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
                
         
        }


        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Usuario>> Put([FromServices] dbContext context, [FromBody] Usuario model)
        {
            try
            {
                var usuario = new Usuario();
                usuario = await context.usuario.FirstOrDefaultAsync(x => x.codigo == model.codigo);

                if(usuario != null)
                {
                    usuario.nome = model.nome;
                    usuario.email = model.email;

                    context.SaveChanges();
                    usuario.senha = null;
                    return usuario;
                }

                return NotFound();

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
            

            
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<string>> Delete([FromServices] dbContext context,  int id)
        {
            try
            {
                var usuario = new Usuario();
                usuario = await context.usuario.FirstOrDefaultAsync(x => x.codigo == id);

                if(usuario != null)
                {
                    context.usuario.Remove(usuario);
                    context.SaveChanges();
                    return Ok();
                }


                return NotFound();
            }
            catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
