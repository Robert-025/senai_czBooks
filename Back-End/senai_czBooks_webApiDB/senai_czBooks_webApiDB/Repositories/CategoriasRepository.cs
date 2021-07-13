using senai_czBooks_webApiDB.Context;
using senai_czBooks_webApiDB.Domains;
using senai_czBooks_webApiDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        czBooksContext ctx = new czBooksContext();

        /// <summary>
        /// Atualiza uma categoria passando seu ID na url da requisição
        /// </summary>
        /// <param name="id">ID da categoria que será atualizada</param>
        /// <param name="categoriaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, categorias categoriaAtualizada)
        {
            //Busca a categoria que será atualizada
            categorias categoriaBuscada = BuscarPorId(id);

            //Verifica se algo foi passado
            if (categoriaAtualizada.categoria != null)
            {
                //Caso sim, atualiza os campos da categoria 
                categoriaBuscada.categoria = categoriaAtualizada.categoria;
            }

            //Atualiza a categoria buscada
            ctx.categoria.Update(categoriaBuscada);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma categoria pelo seu ID
        /// </summary>
        /// <param name="id">ID da categoria que será buscada</param>
        /// <returns>A categoria buscada</returns>
        public categorias BuscarPorId(int id)
        {
            //Retorna o resultado da busca 
            return ctx.categoria.Find(id);
        }

        /// <summary>
        /// Cadastra uma nova categoria
        /// </summary>
        /// <param name="novaCategoria">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(categorias novaCategoria)
        {
            //Adiciona na tabela categorias o objeto recebido
            ctx.categoria.Add(novaCategoria);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma categoria existente
        /// </summary>
        /// <param name="id">ID da categoria existente</param>
        public void Deletar(int id)
        {
            //Remove da tabela o resultado da busca de categoria pelo ID
            ctx.categoria.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as categorias do sistema
        /// </summary>
        /// <returns>Uma lista com as categorias</returns>
        public List<categorias> ListarTodas()
        {
            //Retorna a listagem da tabela categoria
            return ctx.categoria.ToList();
        }
    }
}
