using senai_czBooks_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Interfaces
{
    interface ILivrosRepository
    {
        /// <summary>
        /// Lista todos os livros do sistema
        /// </summary>
        /// <returns>Uma lista de livros</returns>
        List<livros> ListarTodos();

        /// <summary>
        /// Busca um livro pelo seu ID
        /// </summary>
        /// <param name="id">Id do livro que será buscado</param>
        /// <returns>O livro buscado</returns>
        livros BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo livro
        /// </summary>
        /// <param name="novoLivro">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(livros novoLivro);

        /// <summary>
        /// Atualiza um livro passando seu ID na url da requisição
        /// </summary>
        /// <param name="id">ID do livro que será atualizado</param>
        /// <param name="livroAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, livros livroAtualizado);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        void Deletar(int id);
    }
}
