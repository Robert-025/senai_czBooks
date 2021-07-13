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
    public class BibliotecasController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface IBibliotecasRepository
        /// </summary>
        private IBibliotecasRepository _bibliotecasRepository { get; set; }

        public BibliotecasController()
        {
            //Atribui o _bibliotecasRepository ao BibliotecasRepository para ter referências aos métodos lá montados
            _bibliotecasRepository = new BibliotecasRepository();
        }

        /// <summary>
        /// Lista todas as bibliotecas
        /// </summary>
        /// <returns>Um status code 200 - Ok com a lista de bibliotecas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista todas as bibliotecas
                return Ok(_bibliotecasRepository.ListarTodas());
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca uma biblioteca pelo seu ID
        /// </summary>
        /// <param name="id">ID da biblioteca que será buscada</param>
        /// <returns>Um status code 200 - Ok com a biblioteca buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna um status code com a biblioteca
                return Ok(_bibliotecasRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra uma nova biblioteca
        /// </summary>
        /// <param name="novaBiblioteca">Obejto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(bibliotecas novaBiblioteca)
        {
            try
            {
                //Chama o método de cadastrar
                _bibliotecasRepository.Cadastrar(novaBiblioteca);

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
        /// Atualiza uma biblioteca passando seu ID na url da requisição
        /// </summary>
        /// <param name="id">ID a</param>
        /// <param name="bibliotecaAtualizada"></param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, bibliotecas bibliotecaAtualizada)
        {
            try
            {
                //Chama o método de atualizar 
                _bibliotecasRepository.Atualizar(id, bibliotecaAtualizada);

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
        /// Deleta uma biblioteca
        /// </summary>
        /// <param name="id">ID da bilioteca que será deletada</param>
        /// <returns>Um status code 204 - NoContent </returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar
                _bibliotecasRepository.Deletar(id);

                //retorna o status code
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
