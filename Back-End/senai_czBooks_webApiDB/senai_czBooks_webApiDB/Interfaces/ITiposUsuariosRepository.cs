using senai_czBooks_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Interfaces
{
    interface ITiposUsuariosRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuarios cadastrados no sistema
        /// </summary>
        /// <returns>Uma lista com os tipos de usuários</returns>
        List<tiposUsuarios> ListarTodos();

        /// <summary>
        /// Busca um tipo de usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do tipo de usuario que será buscado</param>
        /// <returns>O tipo de usuário buscado</returns>
        tiposUsuarios BuscarPorId(int id);

        /// <summary>
        /// Deleta um tipo de usuário existente pelo seu ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(tiposUsuarios novoTipo);

        /// <summary>
        /// Atualiza um tipo de usuário passando seu ID na URL da requisição
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualiza</param>
        /// <param name="tipoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, tiposUsuarios tipoAtualizado);
    }
}
