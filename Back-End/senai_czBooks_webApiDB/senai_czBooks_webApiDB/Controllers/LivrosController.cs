using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_czBooks_webApiDB.Domains;
using senai_czBooks_webApiDB.Interfaces;
using senai_czBooks_webApiDB.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador de API 
    [ApiController]
    public class LivrosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        ILivrosRepository _livrosRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _livrosRepository para que haja referência aos métodos do repositorio
        /// </summary>
        public LivrosController()
        {
            _livrosRepository = new LivrosRepository();
        }


        /// <summary>
        /// Lista todos os livros 
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de livros</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_livrosRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar os livros se o usuário não estiver logado!",
                    ex
                });
            }
        }

        /// <summary>
        /// Busca um livro pelo seu ID
        /// </summary>
        /// <param name="id">ID do livro que será buscado</param>
        /// <returns>Um status code 200 - OK com o livro buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_livrosRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todos os livros de um autor
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de livros</returns>
        [Authorize(Roles = "2")]
        [HttpGet("meus")]
        public IActionResult GetMy()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retorna a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_livrosRepository.ListarMeus(idUsuario));
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar os livros se o usuário não estiver logado!",
                    ex
                });
            }
        }

        /// <summary>
        /// Cadastra um novo livro
        /// </summary>
        /// <param name="novoLivro">Objeto com as informações que serçao cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(livros novoLivro)
        {
            try
            {
                _livrosRepository.Cadastrar(novoLivro);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um livro passando seu ID na url
        /// </summary>
        /// <param name="id">ID do livro que será atualizado</param>
        /// <param name="livroAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, livros livroAtualizado)
        {
            try
            {
                _livrosRepository.Atualizar(id, livroAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um livro passando seu ID na url
        /// </summary>
        /// <param name="id">ID do livro que será deletado</param>
        /// <returns>Um status cdoe 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _livrosRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(ex);
            }
        }
    }
}
