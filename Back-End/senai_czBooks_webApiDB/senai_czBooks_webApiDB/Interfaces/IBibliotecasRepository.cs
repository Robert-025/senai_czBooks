using senai_czBooks_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Interfaces
{
    interface IBibliotecasRepository
    {
        /// <summary>
        /// Lista todas as bibliotecas
        /// </summary>
        /// <returns>Uma lista com as bibliotecas</returns>
        List<bibliotecas> ListarTodas();

        /// <summary>
        /// Busca um biblioteca pelo seu ID
        /// </summary>
        /// <param name="id">ID da biblioteca que será buscada</param>
        /// <returns>A biblioteca buscada</returns>
        bibliotecas BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova biblioteca
        /// </summary>
        /// <param name="novaBiblioteca">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(bibliotecas novaBiblioteca);

        /// <summary>
        /// Atualiza uma biblioteca existente passando seu ID na URL da requisição
        /// </summary>
        /// <param name="id">ID da biblioteca que será atualizada</param>
        /// <param name="bibliotecaAtualizada">Objeto com as nova informações</param>
        void Atualizar(int id, bibliotecas bibliotecaAtualizada);

        /// <summary>
        /// Deleta uma biblioteca existente
        /// </summary>
        /// <param name="id">ID da biblioteca que será deletada</param>
        void Deletar(int id);
    }
}
