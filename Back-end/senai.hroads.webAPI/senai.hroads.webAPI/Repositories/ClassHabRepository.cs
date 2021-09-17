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
    public class ClassHabRepository : IClassHabRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idClassHab, ClassHab ClassHabAtualizada)
        {
            ClassHab classHabBuscada = BuscarPorId(idClassHab);

            if (ClassHabAtualizada.IdClasse != null && ClassHabAtualizada.IdHabilidade != null)
            {
                classHabBuscada.IdClasse = ClassHabAtualizada.IdClasse;
                classHabBuscada.IdHabilidade = ClassHabAtualizada.IdHabilidade;
            }

            ctx.ClassHabs.Update(classHabBuscada);

            ctx.SaveChanges();
        }

        public ClassHab BuscarPorId(int idClassHab)
        {
            return ctx.ClassHabs.FirstOrDefault(ch => ch.IdClassHab == idClassHab);
        }

        public void Cadastrar(ClassHab novaClassHab)
        {
            ctx.ClassHabs.Add(novaClassHab);

            ctx.SaveChanges();
        }

        public void Deletar(int idClassHab)
        {
            ClassHab classHabBuscada = BuscarPorId(idClassHab);

            ctx.ClassHabs.Remove(classHabBuscada);

            ctx.SaveChanges();
        }

        public List<ClassHab> Listar()
        {
            return ctx.ClassHabs.Include(ch => ch.IdHabilidadeNavigation).Include(ch => ch.IdClasseNavigation).OrderBy(ch => ch.IdClassHab).ToList();
        }
    }
}
