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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idTipoUsuario, TipoUsuario novoTipoUsuario)
        {
            TipoUsuario tipoUsuarioBuscado = BuscarPorId(idTipoUsuario);

            if (tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado.Titulo = novoTipoUsuario.Titulo;
            }
            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.Include(x => x.Usuarios).FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Deletar(int id)
        {
            TipoUsuario tipoUserDelete = BuscarPorId(id);

            if (tipoUserDelete != null)
            {
                ctx.TipoUsuarios.Remove(tipoUserDelete);
                ctx.SaveChanges();
            }
        }

        public void Inserir(TipoUsuario tipoUsuario)
        {
            ctx.TipoUsuarios.Add(tipoUsuario);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.Include(y => y.Usuarios).ToList();
        }
    }
}
