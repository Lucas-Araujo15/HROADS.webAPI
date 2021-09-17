using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webAPI.Domains;
using senai.hroads.webAPI.Interfaces;
using senai.hroads.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_UsuarioRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_UsuarioRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Usuario usuarioInserir)
        {
            _UsuarioRepository.Inserir(usuarioInserir);
            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _UsuarioRepository.Deletar(id);
            return NoContent();
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {

            if (usuarioAtualizado.Nome == null || usuarioAtualizado.Senha == null || usuarioAtualizado.Email == null || usuarioAtualizado.IdTipoUsuario == 0 || id == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram informadas!"
                    }
                );
            }

            Usuario usuarioBuscado = _UsuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                _UsuarioRepository.Atualizar(id, usuarioAtualizado);
                return Ok();
            }

            return NotFound(
                    new
                    {
                        mensagemErro = "Usuário não encontrado!",
                        codErro = true
                    }
                );
        }
        
    }
}
