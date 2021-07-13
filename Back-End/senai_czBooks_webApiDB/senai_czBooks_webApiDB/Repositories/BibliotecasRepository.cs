using senai_czBooks_webApiDB.Context;
using senai_czBooks_webApiDB.Domains;
using senai_czBooks_webApiDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Repositories
{
    public class BibliotecasRepository : IBibliotecasRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        czBooksContext ctx = new czBooksContext();

        /// <summary>
        /// Atualiza uma biblioteca existente passando seu ID na URL da requisição
        /// </summary>
        /// <param name="id">ID da biblioteca que será atualizada</param>
        /// <param name="bibliotecaAtualizada">Objeto com as nova informações</param>
        public void Atualizar(int id, bibliotecas bibliotecaAtualizada)
        {
            //Procura a biblioteca que será atualizada pelo ID passado
            bibliotecas bibliotecaBuscada = BuscarPorId(id);

            //IF - Verifica se as informações foram passadas, e caso sejam, atualiza os campos

            if (bibliotecaAtualizada.cnpj != null)
            {
                bibliotecaBuscada.cnpj = bibliotecaAtualizada.cnpj;
            }

            if (bibliotecaAtualizada.endereco != null)
            {
                bibliotecaBuscada.endereco = bibliotecaAtualizada.endereco;
            }

            if (bibliotecaAtualizada.razaoSocial != null)
            {
                bibliotecaBuscada.razaoSocial = bibliotecaAtualizada.razaoSocial;
            }

            //Atualiza a bibliotecaBuscada com as novas informações
            ctx.bibliotecas.Update(bibliotecaBuscada);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um biblioteca pelo seu ID
        /// </summary>
        /// <param name="id">ID da biblioteca que será buscada</param>
        /// <returns>A biblioteca buscada</returns>
        public bibliotecas BuscarPorId(int id)
        {
            //Retorna o resultado da busca na tabela bibliotecas pelo ID
            return ctx.bibliotecas.Find(id);
        }

        /// <summary>
        /// Cadastra uma nova biblioteca
        /// </summary>
        /// <param name="novaBiblioteca">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(bibliotecas novaBiblioteca)
        {
            //Adiciona na tabela bibliotecas o objeto recebido
            ctx.bibliotecas.Add(novaBiblioteca);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma biblioteca existente
        /// </summary>
        /// <param name="id">ID da biblioteca que será deletada</param>
        public void Deletar(int id)
        {
            //Remove da tabela bibliotecas o resultado da busca 
            ctx.bibliotecas.Remove(BuscarPorId(id));

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as bibliotecas
        /// </summary>
        /// <returns>Uma lista com as bibliotecas</returns>
        public List<bibliotecas> ListarTodas()
        {
            //Retorn a listagem das bibliotecas
            return ctx.bibliotecas.ToList();
        }
    }
}
