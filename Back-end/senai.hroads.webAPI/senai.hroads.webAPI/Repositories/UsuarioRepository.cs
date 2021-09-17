using Microsoft.EntityFrameworkCore;
using senai.hroads.webAPI.Contexts;
using senai.hroads.webAPI.Domains;
using senai.hroads.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idUsuario, Usuario novoUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            if(usuarioBuscado != null)
            {
                usuarioBuscado.Email = novoUsuario.Email;
                usuarioBuscado.IdTipoUsuario = novoUsuario.IdTipoUsuario;
                usuarioBuscado.Nome = novoUsuario.Nome;
                usuarioBuscado.Senha = novoUsuario.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(x => x.IdUsuario == id);
        }

        public void Deletar(int IdUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(IdUsuario);

            if(usuarioBuscado != null)
            {
                ctx.Usuarios.Remove(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public void Inserir(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }
    }
}
