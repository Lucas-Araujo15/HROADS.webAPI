using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Interfaces
{
    interface IClasseRepository
    {
        List<Classe> Listar();

        Classe BuscarPorId(int idClasse);

        void Cadastrar(Classe novaClasse);

        void Atualizar(int idClasse, Classe classeAtualizada);

        void Deletar(int idClasse);

        List<Classe> ListarComPersonagens();

    }
}
