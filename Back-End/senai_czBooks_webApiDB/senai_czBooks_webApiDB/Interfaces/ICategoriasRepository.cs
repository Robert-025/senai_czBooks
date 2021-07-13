using senai_czBooks_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Interfaces
{
    interface ICategoriasRepository
    {
        /// <summary>
        /// Lista todas as categorias do sistema
        /// </summary>
        /// <returns>Uma lista com as categorias</returns>
        List<categorias> ListarTodas();

        /// <summary>
        /// Busca uma categoria pelo seu ID
        /// </summary>
        /// <param name="id">ID da categoria que será buscada</param>
        /// <returns>A categoria buscada</returns>
        categorias BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova categoria
        /// </summary>
        /// <param name="novaCategoria">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(categorias novaCategoria);

        /// <summary>
        /// Atualiza uma categoria passando seu ID na url da requisição
        /// </summary>
        /// <param name="id">ID da categoria que será atualizada</param>
        /// <param name="categoriaAtualizada">Objeto com as novas informações</param>
        void Atualizar(int id, categorias categoriaAtualizada);

        /// <summary>
        /// Deleta uma categoria existente
        /// </summary>
        /// <param name="id">ID da categoria existente</param>
        void Deletar(int id);
    }
}
