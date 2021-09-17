using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        List<TipoHabilidade> Listar();

        TipoHabilidade BuscarPorId(int idTipoHabilidade);

        void Cadastrar(TipoHabilidade novoTipoHabilidade);

        void Atualizar(int idTipoHabilidade, TipoHabilidade TipoHabilidadeAtualizada);

        void Deletar(int idTipoHabilidade);

        List<TipoHabilidade> ListarComHabilidades();

    }
}
