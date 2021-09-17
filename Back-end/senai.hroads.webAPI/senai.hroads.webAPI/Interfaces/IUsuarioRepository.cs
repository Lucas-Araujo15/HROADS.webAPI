using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Busca um único usuário em específico
        /// </summary>
        /// <param name="id">ID do usuário a ser buscado</param>
        /// <returns>Objeto Usuario que foi buscado</returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Deleta um usuário específico
        /// </summary>
        /// <param name="IdUsuario">ID do usuário a ser deletado</param>
        void Deletar(int IdUsuario);

        /// <summary>
        /// Atualiza um determinado usuário
        /// </summary>
        /// <param name="idUsuario">ID do usuário a ser modificado</param>
        /// <param name="novoUsuario">Objeto Usuario com as novas informações</param>
        void Atualizar(int idUsuario, Usuario novoUsuario);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Objeto Usuario que será cadastrado</param>
        void Inserir(Usuario usuario);

        /// <summary>
        /// Busca um usuário através de sua senha e email
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Usuário que foi buscado</returns>
        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
