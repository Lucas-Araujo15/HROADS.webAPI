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
    public class PersonagensController : ControllerBase
    {
        IPersonagemRepository _PersonagemRepository { get; set; }

        public PersonagensController()
        {
            _PersonagemRepository = new PersonagemRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_PersonagemRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_PersonagemRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagem personagemCadastrar)
        {
            _PersonagemRepository.Inserir(personagemCadastrar);
            return StatusCode(201);
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _PersonagemRepository.Deletar(id);
            return NoContent();
        }

        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem personagemAtual)
        {
            if (personagemAtual.IdClasse == 0 || personagemAtual.Nome == null || personagemAtual.CapVida == 0 || personagemAtual.CapMana == 0)
            {
                return BadRequest(
                    new
                    {
                        mensagemErro = "Algumas informações não foram informadas!"
                    }
                );
            }

            Personagem personagemBuscado = _PersonagemRepository.BuscarPorId(id);

            if(personagemBuscado != null)
            {
                _PersonagemRepository.Atualizar(id, personagemAtual);
                return Ok();
            }

            return NotFound(
                    new
                    {
                        mensagemErro = "Personagem não encontrado!",
                        codErro = true
                    }
                );
        }
    }
}
