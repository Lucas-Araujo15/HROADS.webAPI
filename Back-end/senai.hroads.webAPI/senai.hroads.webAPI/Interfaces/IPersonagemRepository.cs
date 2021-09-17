using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webAPI.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="personagem">Objeto Personagem que será cadastrado</param>
        void Inserir(Personagem personagem);

        /// <summary>
        /// Deleta um personagem em específico
        /// </summary>
        /// <param name="id">ID do personagem que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um personagem específico
        /// </summary>
        /// <param name="idPersonagem">ID do personagem a ser cadastrado</param>
        /// <param name="novoTipoUsuario">Objeto Personagem com as novas informações</param>
        void Atualizar(int idPersonagem, Personagem novoPersonagem);

        /// <summary>
        /// Lista todos os personagens cadastrados
        /// </summary>
        /// <returns>Lista de personagens</returns>
        List<Personagem> ListarTodos();

        /// <summary>
        /// Lista um personagem em específico
        /// </summary>
        /// <param name="id">ID do personagem a ser listado</param>
        /// <returns>Objeto Personagem que foi encontrado</returns>
        Personagem BuscarPorId(int id);
    }
}
