using senai_czBooks_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Interfaces
{
    interface IUsuariosRepository
    {
        /// <summary>
        /// Lista todos os usuários do sistema
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        List<usuarios> ListarTodos();

        /// <summary>
        /// Busca um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>O usuário buscado</returns>
        usuarios BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(usuarios novoUsuario);

        /// <summary>
        /// Atualiza um usuário existente passando seu ID na url da requisição
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, usuarios usuarioAtualizado);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void Deletar(int id);
    }
}
