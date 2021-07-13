using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_czBooks_webApiDB.Domains;
using senai_czBooks_webApiDB.Interfaces;
using senai_czBooks_webApiDB.Repositories;
using System;
using System.Collections.Generic;
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
    public class AutoresController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface IAutoresRepository
        /// </summary>
        private IAutoresRepository _autoresRepository { get; set; }

        public AutoresController()
        {
            //Atribui o _bibliotecasRepository ao _autoresRepository para ter referências aos métodos lá montados
            _autoresRepository = new AutoresRepository();
        }

        /// <summary>
        /// Lista todos os autors
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de autores</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_autoresRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um autor pelo seu ID
        /// </summary>
        /// <param name="id">Id do autor que será buscado</param>
        /// <returns>Um status code 200 - OK com o autor buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_autoresRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo autor
        /// </summary>
        /// <param name="novoAutor">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(autores novoAutor)
        {
            try
            {
                _autoresRepository.Cadastrar(novoAutor);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um autor passando seu ID na url da requisição
        /// </summary>
        /// <param name="id">Id do autor que será atualizado</param>
        /// <param name="autorAtualizado">Obejto com as novas infoemações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, autores autorAtualizado)
        {
            try
            {
                _autoresRepository.Atualizar(id, autorAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um autor passando seu Id na url
        /// </summary>
        /// <param name="id">ID do autor que será deletado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _autoresRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }
    }
}
