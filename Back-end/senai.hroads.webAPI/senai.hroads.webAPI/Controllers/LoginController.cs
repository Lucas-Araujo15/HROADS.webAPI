using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.hroads.webAPI.Domains;
using senai.hroads.webAPI.Interfaces;
using senai.hroads.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace senai.hroads.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUsuarioRepository usuarioLogin { get; set; }

        public LoginController()
        {
            usuarioLogin = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Logar(Usuario usuarioAutenticacao)
        {
            Usuario usuarioBuscado = usuarioLogin.BuscarPorEmailSenha(usuarioAutenticacao.Email, usuarioAutenticacao.Senha);

            if(usuarioBuscado != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.NameId, usuarioBuscado.Nome),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var TokenGerado = new JwtSecurityToken(
                    issuer: "senai.hroads.webAPI",  
                    audience: "senai.hroads.webAPI", 
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(TokenGerado)
                });
            }

            return NotFound("O usuário não foi encontrado. Tente novamente.");
        }
    }
}
