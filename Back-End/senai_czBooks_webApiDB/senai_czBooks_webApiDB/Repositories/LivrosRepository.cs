using Microsoft.EntityFrameworkCore;
using senai_czBooks_webApiDB.Context;
using senai_czBooks_webApiDB.Domains;
using senai_czBooks_webApiDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Repositories
{
    public class LivrosRepository : ILivrosRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        czBooksContext ctx = new czBooksContext();

        /// <summary>
        /// Atualiza um livro passando seu ID na url da requisição
        /// </summary>
        /// <param name="id">ID do livro que será atualizada</param>
        /// <param name="livroAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, livros livroAtualizado)
        {
            //Procura o livro que será atualizado
            livros livroBuscado = BuscarPorId(id);

            //IF - Verifica se os campos foram passados, e se forem, atualiza os campos com as novas informações

            if (livroAtualizado.titulo != null)
            {
                livroBuscado.titulo = livroAtualizado.titulo;
            }

            if (livroAtualizado.sinopse != null)
            {
                livroBuscado.sinopse = livroAtualizado.sinopse;
            }

            if (livroAtualizado.dataPublicacao != null)
            {
                livroBuscado.dataPublicacao = livroAtualizado.dataPublicacao;
            }

            if (livroAtualizado.preco != null)
            {
                livroBuscado.preco = livroAtualizado.preco;
            }

            if (livroAtualizado.idAutor != null)
            {
                livroBuscado.idAutor = livroAtualizado.idAutor;
            }

            if (livroAtualizado.idBiblioteca != null)
            {
                livroBuscado.idBiblioteca = livroAtualizado.idBiblioteca;
            }

            if (livroAtualizado.idCategoria != null)
            {
                livroBuscado.idCategoria = livroAtualizado.idCategoria;
            }

            //Atualiza o livroBuscado com as novas informações
            ctx.livros.Update(livroBuscado);

            //Saçva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma livro pelo seu ID
        /// </summary>
        /// <param name="id">ID do livro que será buscado</param>
        /// <returns>O livro buscada</returns>
        public livros BuscarPorId(int id)
        {
            //Retorna o resultado da busca pelo livro com o ID passado
            return ctx.livros.Find(id);
        }

        /// <summary>
        /// Cadastra um nov livro
        /// </summary>
        /// <param name="novoLivro">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(livros novoLivro)
        {
            //Adiciona na tabela livros o Objeto informado
            ctx.livros.Add(novoLivro);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um livro existente
        /// </summary>
        /// <param name="id">ID do livro existente</param>
        public void Deletar(int id)
        {
            //Remova da lista o resultado da busca
            ctx.livros.Remove(BuscarPorId(id));

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os livros que um determinado autor escreveu
        /// </summary>
        /// <param name="id">ID do usuario que escreveu os livros</param>
        /// <returns>Uma lista com os livros do usuario</returns>
        public List<livros> ListarMeus(int id)
        {
            //Retorna uma lista com todas as informações das consultas
            return ctx.livros
                         //Adiciona na busca as informações da categoria
                        .Include(l => l.idCategoriaNavigation)
                        //Adiciona nas informações as informações da biblioteca
                        .Include(l => l.idBibliotecaNavigation)
                        //Estabelece como parâmetro de consulta o ID do usuario recebido
                        .Where(l => l.idAutorNavigation.idUsuario == id)
                            .ToList();
        }

        /// <summary>
        /// Lista todas os livros do sistema
        /// </summary>
        /// <returns>Uma lista com os livros</returns>
        public List<livros> ListarTodos()
        {
            //Retorna a tabela de livros
            return ctx.livros.Include(l => l.idAutorNavigation)
                             .Include(l => l.idBibliotecaNavigation)
                             .Include(l => l.idCategoriaNavigation)
                             .ToList();
        }
    }
}
