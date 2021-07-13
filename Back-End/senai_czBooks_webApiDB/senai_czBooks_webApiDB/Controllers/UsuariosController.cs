using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_czBooks_webApiDB.Domains;
using senai_czBooks_webApiDB.Interfaces;
using senai_czBooks_webApiDB.Repositories;
using senai_czBooks_webApiDB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Controllers
{
    /// <summary>
    /// Controller responsavel pelos endpoints ao Login
    /// </summary>
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador de API 
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuariosRepository _usuarioRepository { get; set; }


        public UsuariosController()
        {
            //Atribui o _usuarioRepository ao UsuariosRepository para ter referências aos métodos lá montados
            _usuarioRepository = new UsuariosRepository();
        }

        /// <summary>
        /// Lista todos os usuarios 
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de usuarios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um usuario pelo seu ID
        /// </summary>
        /// <param name="id">ID do usuario que será buscado</param>
        /// <returns>Um status code 200 - Ok com o usuario buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(usuarios novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um usuario passando seu ID na url
        /// </summary>
        /// <param name="id">ID do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, usuarios usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.Atualizar(id, usuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um usuario passando seu ID
        /// </summary>
        /// <param name="id">ID do usuario que será deletado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

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
