using senai_czBooks_webApiDB.Context;
using senai_czBooks_webApiDB.Domains;
using senai_czBooks_webApiDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        czBooksContext ctx = new czBooksContext();

        /// <summary>
        /// Atualiza um usuário existente passando seu ID na url da requisição
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, usuarios usuarioAtualizado)
        {
            //Busca o usuario que será atualizado
            usuarios usuarioBuscado = BuscarPorId(id);

            //IF - Verifica se os campos foram passados. Caso sejam, atualiza com as novas informações

            if (usuarioAtualizado.idTipoUsuario != null)
            {
                usuarioBuscado.idTipoUsuario = usuarioAtualizado.idTipoUsuario;
            }

            if (usuarioAtualizado.nome != null)
            {
                usuarioBuscado.nome = usuarioAtualizado.nome;
            }

            if (usuarioAtualizado.email != null)
            {
                usuarioBuscado.email = usuarioAtualizado.email;
            }

            if (usuarioAtualizado.senha != null)
            {
                usuarioBuscado.senha = usuarioAtualizado.senha;
            }

            //Atualiza na tabela o usuarioBuscado com as novas informações
            ctx.usuarios.Update(usuarioBuscado);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>O usuário buscado</returns>
        public usuarios BuscarPorId(int id)
        {
            //Retorna o resultado da busca
            return ctx.usuarios.Find(id);
        }

        /// <summary>
        /// Cadastra uma novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(usuarios novoUsuario)
        {
            //Adiciona o novoUsuario na tabela de usuarios 
            ctx.usuarios.Add(novoUsuario);

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        public void Deletar(int id)
        {
            //Remove da tabela usuarios o resultado da busca
            ctx.usuarios.Remove(BuscarPorId(id));

            //Salva as informações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuários do sistema
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        public List<usuarios> ListarTodos()
        {
            //Retorna a listagem de usuarios
            return ctx.usuarios.ToList();
        }

        /// <summary>
        /// Valida o usuario
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns>O usuario encontrado</returns>
        public usuarios Login(string email, string senha)
        {
            //Retorna o primeiro usuario achado com as informações que coincidem com o que foi passado
            return ctx.usuarios.FirstOrDefault(u => u.email == email && u.senha == senha);
        }
    }
}
