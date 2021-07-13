using senai_czBooks_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Interfaces
{
    interface IAutoresRepository
    {
        /// <summary>
        /// Lista todos os autores
        /// </summary>
        /// <returns>Uma lista com os autores</returns>
        List<autores> ListarTodos();

        /// <summary>
        /// Busca um autor pelo seu ID
        /// </summary>
        /// <param name="id">ID do autor que será buscado</param>
        /// <returns>O autor buscad<o/returns>
        autores BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo autor
        /// </summary>
        /// <param name="novoAutor">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(autores novoAutor);

        /// <summary>
        /// Atualiza um autor passando seu ID na url da requisição
        /// </summary>
        /// <param name="id">ID do autor que será atualizado</param>
        /// <param name="autorAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, autores autorAtualizado);

        /// <summary>
        /// Deleta um autor existente
        /// </summary>
        /// <param name="id">ID do autor que será deletado</param>
        void Deletar(int id);
    }
}
