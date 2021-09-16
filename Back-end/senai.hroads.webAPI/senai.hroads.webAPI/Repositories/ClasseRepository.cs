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
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idClasse, Classe classeAtualizada)
        {
            Classe classeBuscada = BuscarPorId(idClasse);

            if (classeAtualizada.NomeClasse != null)
            {
                classeBuscada.NomeClasse = classeAtualizada.NomeClasse;
            }

            ctx.Classes.Update(classeBuscada);

            ctx.SaveChanges();
        }

        public Classe BuscarPorId(int idClasse)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == idClasse);
        }

        public void Cadastrar(Classe novaClasse)
        {
            ctx.Classes.Add(novaClasse);

            ctx.SaveChanges();
        }

        public void Deletar(int idClasse)
        {
            Classe classeBuscada = BuscarPorId(idClasse);

            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.OrderBy(classe => classe.IdClasse).ToList();
        }

        public List<Classe> ListarComPersonagens()
        {
            return ctx.Classes.Include(c => c.Personagems).OrderBy(classe => classe.IdClasse).ToList();
        }
    }
}
