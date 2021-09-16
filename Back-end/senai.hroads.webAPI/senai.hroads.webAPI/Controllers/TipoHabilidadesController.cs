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
    public class TipoHabilidadesController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipohabRepository { get; set; }

        public TipoHabilidadesController()
        {
            _tipohabRepository = new TipoHabilidadeRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_tipohabRepository.Listar());
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
                return Ok(_tipohabRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidade novoTipoHab)
        {
            try
            {
                _tipohabRepository.Cadastrar(novoTipoHab);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idAtualiza}")]
        public IActionResult Atualizar(int idAtualiza, TipoHabilidade tipoHabatualizada)
        {
            try
            {
                _tipohabRepository.Atualizar(idAtualiza, tipoHabatualizada);
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
                _tipohabRepository.Deletar(idDeleta);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
