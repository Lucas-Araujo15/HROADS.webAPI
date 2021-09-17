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

    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_TipoUsuarioRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_TipoUsuarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuarioCadastrar)
        {
            _TipoUsuarioRepository.Inserir(tipoUsuarioCadastrar);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _TipoUsuarioRepository.Deletar(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario novoTipoUsuario)
        {
            if (id == 0 || novoTipoUsuario.Titulo == null)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram informadas!"
                    }
                );
            }

            TipoUsuario tipoUsuarioBuscado = _TipoUsuarioRepository.BuscarPorId(id);

            if(tipoUsuarioBuscado != null)
            {
                _TipoUsuarioRepository.Atualizar(id, novoTipoUsuario);
                return Ok();
            }

            return NotFound(
                    new
                    {
                        mensagemErro = "Tipo de usuário não encontrado!",
                        codErro = true
                    }
                );
        }
    }
}
