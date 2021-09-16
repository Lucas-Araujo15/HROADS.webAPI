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
    public class ClassHabsController : ControllerBase
    {
        private IClassHabRepository _classHabRepository { get; set; }

        public ClassHabsController()
        {
            _classHabRepository = new ClassHabRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_classHabRepository.Listar());
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
                return Ok(_classHabRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(ClassHab novaClassHab)
        {
            try
            {
                _classHabRepository.Cadastrar(novaClassHab);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idAtualiza}")]
        public IActionResult Atualizar(int idAtualiza, ClassHab classHabAtualizada)
        {
            try
            {
                _classHabRepository.Atualizar(idAtualiza, classHabAtualizada);
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
                _classHabRepository.Deletar(idDeleta);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
