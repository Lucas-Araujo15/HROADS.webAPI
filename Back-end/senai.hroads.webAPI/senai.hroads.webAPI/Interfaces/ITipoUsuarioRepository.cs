using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario">Objeto TipoUsuario que será cadastrado</param>
        void Inserir(TipoUsuario tipoUsuario);

        /// <summary>
        /// Deleta um tipo de usuário em específico
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um usuário específico
        /// </summary>
        /// <param name="idTipoUsuario">ID do tipo de usuário a ser cadastrado</param>
        /// <param name="novoTipoUsuario">Objeto TipoUsuario com as novas informações</param>
        void Atualizar(int idTipoUsuario, TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Lista todos os tipos de usuários cadastrados
        /// </summary>
        /// <returns>Lista de tipos de usuários</returns>
        List<TipoUsuario> ListarTodos();

        /// <summary>
        /// Lista um tipo de usuário em específico
        /// </summary>
        /// <param name="id">ID do tipo de usuário a ser listado</param>
        /// <returns>Objeto TipoUsuario que foi encontrado</returns>
        TipoUsuario BuscarPorId(int id);
    }
}
