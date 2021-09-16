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
    public class ClassesController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set;  }

        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_classeRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idClasse}")]
        public IActionResult BuscarPorId(int idClasse)
        {
            try
            {
                return Ok(_classeRepository.BuscarPorId(idClasse));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Classe novaClasse)
        {
            try
            {
                _classeRepository.Cadastrar(novaClasse);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [HttpPut("{idAtualiza}")]
        public IActionResult Atualizar(int idAtualiza, Classe classeAtualizada)
        {
            try
            {
                _classeRepository.Atualizar(idAtualiza, classeAtualizada);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        [HttpDelete("{idDeletar}")]
        public IActionResult Deletar(int idDeletar)
        {
            try
            {
                _classeRepository.Deletar(idDeletar);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("personagens")]
        public IActionResult ListarComPersonagens()
        {
            try
            {
                return Ok(_classeRepository.ListarComPersonagens());

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
