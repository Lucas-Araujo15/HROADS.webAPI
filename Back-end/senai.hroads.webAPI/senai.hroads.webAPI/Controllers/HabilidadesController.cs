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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_habilidadeRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(_habilidadeRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Habilidade novaHabilidade)
        {
            try
            {
                _habilidadeRepository.Cadastrar(novaHabilidade);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idAtualiza}")]
        public IActionResult Atualizar(int idAtualiza, Habilidade HabilidadeAtualizada)
        {
            try
            {
                _habilidadeRepository.Atualizar(idAtualiza, HabilidadeAtualizada);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idDeleta}")]
        public IActionResult Deletar(int idDeleta)
        {
            try
            {
                _habilidadeRepository.Deletar(idDeleta);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("tipos")]
        public IActionResult ListarComTipos()
        {
            try
            {
                return Ok(_habilidadeRepository.ListarComTipos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
