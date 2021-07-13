using senai_czBooks_webApiDB.Context;
using senai_czBooks_webApiDB.Domains;
using senai_czBooks_webApiDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Repositories
{
    public class AutoresRepository : IAutoresRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        czBooksContext ctx = new czBooksContext();

        /// <summary>
        /// Atualiza um autor passando seu ID na url da requisição
        /// </summary>
        /// <param name="id">ID do autor que será atualizado</param>
        /// <param name="autorAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, autores autorAtualizado)
        {
            //Busca o autor que será atualizado
            autores autorBuscado = BuscarPorId(id);


            //IF - Verifica se os campos foram passados e caso sejam, atualiza os campos
            if (autorAtualizado.sobrenome != null)
            {
                autorBuscado.sobrenome = autorAtualizado.sobrenome;
            }

            if (autorAtualizado.idUsuario != null)
            {
                autorBuscado.idUsuario = autorAtualizado.idUsuario;
            }

            //Atualiza o usuarioBuscado com as novas informações
            ctx.autors.Update(autorBuscado);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um autor pelo seu ID
        /// </summary>
        /// <param name="id">ID do autor que será buscado</param>
        /// <returns>O autor buscadi</returns>
        public autores BuscarPorId(int id)
        {
            //Retorna o resultado da busca na tabela de autors
            return ctx.autors.Find(id);
        }

        /// <summary>
        /// Cadastra um novo autor
        /// </summary>
        /// <param name="novoAutor">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(autores novoAutor)
        {
            //Adiciona na tabela de autores o objeto recebido
            ctx.autors.Add(novoAutor);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um autor existente
        /// </summary>
        /// <param name="id">ID do autor que será deletado</param>
        public void Deletar(int id)
        {
            //Remove da lista o resultado da busca
            ctx.autors.Remove(BuscarPorId(id));

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os autores
        /// </summary>
        /// <returns>Uma lista com os autores</returns>
        public List<autores> ListarTodos()
        {
            //Retorna a lista de autors
            return ctx.autors.ToList();
        }
    }
}
