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
    public class TiposUsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface ITiposUsuariosRepository
        /// </summary>
        private ITiposUsuariosRepository _tiposUsuariosRepository { get; set; }

        public TiposUsuariosController()
        {
            //Atribui o _tiposUsuariosRepository ao TiposUsuariosRepository para ter referências aos métodos lá montados
            _tiposUsuariosRepository = new TiposUsuariosRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuarios
        /// </summary>
        /// <returns>Uma lista com os tipos de usuarios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposUsuariosRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna um status code com o tipo de usuario buscado
                return Ok(_tiposUsuariosRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return NotFound(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipo">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(tiposUsuarios novoTipo)
        {
            try
            {
                //Cadastra o novo tipo de usuario
                _tiposUsuariosRepository.Cadastrar(novoTipo);

                //Retorna o status code 
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um tipo de usuario existente pelo seu ID
        /// </summary>
        /// <param name="id">ID do tipo de usuario que será atualizado</param>
        /// <param name="tipoAtualizado">Objeto com as novas informações </param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, tiposUsuarios tipoAtualizado)
        {
            try
            {
                //chama o método de atualizar passando os parâmetros
                _tiposUsuariosRepository.Atualizar(id, tipoAtualizado);

                //Retorna o status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuario pelo seu ID
        /// </summary>
        /// <param name="id">ID do tipo de usuario que será deletado</param>
        /// <returns>um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar passando o ID do tipo de usuário
                _tiposUsuariosRepository.Deletar(id);

                //Retorna o status code
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
