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
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int idPersonagem, Personagem novoPersonagem)
        {
            Personagem personagemBuscado = BuscarPorId(idPersonagem);

            if (personagemBuscado != null)
            {
                personagemBuscado.IdClasse = novoPersonagem.IdClasse;
                personagemBuscado.Nome = novoPersonagem.Nome;
                personagemBuscado.CapVida = novoPersonagem.CapVida;
                personagemBuscado.CapMana = novoPersonagem.CapMana;
                personagemBuscado.DataAtt = novoPersonagem.DataAtt;
                personagemBuscado.DataCriacao = novoPersonagem.DataCriacao;
            }

            ctx.Personagems.Update(personagemBuscado);
            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagems.Include(x => x.IdClasseNavigation).FirstOrDefault(p => p.IdPersonagem == id);
        }

        public void Deletar(int id)
        {
            Personagem personagemBuscado = BuscarPorId(id);

            if (personagemBuscado != null)
            {
                ctx.Personagems.Remove(personagemBuscado);
                ctx.SaveChanges();
            }
        }

        public void Inserir(Personagem personagem)
        {
            ctx.Personagems.Add(personagem);
            ctx.SaveChanges();
        }

        public List<Personagem> ListarTodos()
        {
            return ctx.Personagems.Include(c => c.IdClasseNavigation).ToList();
        }
    }
}
