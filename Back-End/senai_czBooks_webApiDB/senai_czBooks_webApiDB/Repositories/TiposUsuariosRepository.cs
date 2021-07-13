using senai_czBooks_webApiDB.Context;
using senai_czBooks_webApiDB.Domains;
using senai_czBooks_webApiDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        czBooksContext ctx = new czBooksContext();

        /// <summary>
        /// Atualiza um tipo de usuário passando seu ID na URL da requisição
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualiza</param>
        /// <param name="tipoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, tiposUsuarios tipoAtualizado)
        {
            //Busca o tipo de usuario que será atualizado
            tiposUsuarios tipoBuscado = BuscarPorId(id);

            //Verifica se as foram passadas
            if (tipoAtualizado.tipo != null)
            {
                //Caso sim, atualiza o tipoBuscado
                tipoBuscado.tipo = tipoAtualizado.tipo;
            }

            //Atualiza o tipoBuscado com as novas informações
            ctx.tiposUsuarios.Update(tipoBuscado);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do tipo de usuario que será buscado</param>
        /// <returns>O tipo de usuário buscado</returns>
        public tiposUsuarios BuscarPorId(int id)
        {
            //Retorna o resultado da busca do usuário na tabela tiposUsuarios 
            return ctx.tiposUsuarios.Find(id);
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipo">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(tiposUsuarios novoTipo)
        {
            //Adiciona na tabela tiposUsuarios o objeto recebido
            ctx.tiposUsuarios.Add(novoTipo);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuário existente pelo seu ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        public void Deletar(int id)
        {
            //Remove da tabela tiposUsuarios o resultado do BuscarPorID
            ctx.tiposUsuarios.Remove(BuscarPorId(id));

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de usuarios cadastrados no sistema
        /// </summary>
        /// <returns>Uma lista com os tipos de usuários</returns>
        public List<tiposUsuarios> ListarTodos()
        {
            //Retorna a listagem da tabela tiposUsuarios
            return ctx.tiposUsuarios.ToList();
        }
    }
}
