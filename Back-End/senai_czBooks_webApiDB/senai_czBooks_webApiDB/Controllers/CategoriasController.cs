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
    public class CategoriasController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface ICategoriasRepository
        /// </summary>
        private ICategoriasRepository _categoriasRepository { get; set; }

        public CategoriasController()
        {
            //Atribui o _categoriasRepository ao CategoriasRepository para ter referências aos métodos lá montados
            _categoriasRepository = new CategoriasRepository();
        }

        /// <summary>
        /// Lista todas as categorias 
        /// </summary>
        /// <returns>Um status code 200 - Ok com a lista de categorias</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Retorna um status code com a lista
                return Ok(_categoriasRepository.ListarTodas());
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca uma categoria pelo seu ID
        /// </summary>
        /// <param name="id">ID da categoria que será buscada</param>
        /// <returns>Um status code 200 - OK com a categoria buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna um status code com a categoria buscada
                return Ok(_categoriasRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra uma nova categoria
        /// </summary>
        /// <param name="novaCategoria">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(categorias novaCategoria)
        {
            try
            {
                //Chama o método de cadastrar passando o parâmetro recebido
                _categoriasRepository.Cadastrar(novaCategoria);

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
        /// Atualiza uma categoria
        /// </summary>
        /// <param name="id">ID da categoria que será atualizada</param>
        /// <param name="categoriaAtualizada">Objeto com as novas informações que serão cadastradas</param>
        /// <returns>Um status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, categorias categoriaAtualizada)
        {
            try
            {
                //Chama o método de atualizar
                _categoriasRepository.Atualizar(id, categoriaAtualizada);

                //Retorna o status code
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                //Retorna um status code com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma categoria
        /// </summary>
        /// <param name="id">ID da categoria que será deletada</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar
                _categoriasRepository.Deletar(id);

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
