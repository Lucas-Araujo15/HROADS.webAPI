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
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idTipoHabilidade, TipoHabilidade TipoHabilidadeAtualizada)
        {
            TipoHabilidade TipoHabBuscada = BuscarPorId(idTipoHabilidade);

            if (TipoHabilidadeAtualizada.NomeTipoHab != null)
            {
                TipoHabBuscada.NomeTipoHab = TipoHabilidadeAtualizada.NomeTipoHab;
            }

            ctx.TipoHabilidades.Update(TipoHabBuscada);

            ctx.SaveChanges();
        }

        public TipoHabilidade BuscarPorId(int idTipoHabilidade)
        {
            return ctx.TipoHabilidades.FirstOrDefault(th => th.IdTipoHab == idTipoHabilidade);
        }

        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            ctx.TipoHabilidades.Add(novoTipoHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoHabilidade)
        {
            TipoHabilidade TipoHabBuscada = BuscarPorId(idTipoHabilidade);

            ctx.TipoHabilidades.Remove(TipoHabBuscada);

            ctx.SaveChanges();
        }

        public List<TipoHabilidade> Listar()
        {
            return ctx.TipoHabilidades.OrderBy(th => th.IdTipoHab).ToList();
        }

        public List<TipoHabilidade> ListarComHabilidades()
        {
            return ctx.TipoHabilidades.Include(Th => Th.Habilidades).OrderBy(Th => Th.IdTipoHab).ToList();
        }
    }
}
