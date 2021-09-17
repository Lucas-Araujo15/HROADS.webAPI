using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> Listar();

        Habilidade BuscarPorId(int idHabilidade);

        void Cadastrar(Habilidade novaHabilidade);

        void Atualizar(int idHabilidade, Habilidade habilidadeAtualizada);

        void Deletar(int idHabilidade);

        List<Habilidade> ListarComTipos();
    }
}
