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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idHabilidade, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = BuscarPorId(idHabilidade);

            if (habilidadeAtualizada.IdTipoHab != null && habilidadeAtualizada.NomeHab != null)
            {
                habilidadeBuscada.IdTipoHab = habilidadeAtualizada.IdTipoHab;
                habilidadeBuscada.NomeHab = habilidadeAtualizada.NomeHab;
            }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int idHabilidade)
        {
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == idHabilidade);
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidades.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idHabilidade)
        {
            Habilidade habilidadeBuscada = BuscarPorId(idHabilidade);

            ctx.Habilidades.Remove(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.OrderBy(h => h.IdHabilidade).ToList();
        }

        public List<Habilidade> ListarComTipos()
        {
            return ctx.Habilidades.Include(h => h.IdTipoHabNavigation).OrderBy(h => h.IdHabilidade).ToList();
        }
    }
}
