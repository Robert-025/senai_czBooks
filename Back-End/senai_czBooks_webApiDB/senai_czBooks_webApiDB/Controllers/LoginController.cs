using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_czBooks_webApiDB.Domains;
using senai_czBooks_webApiDB.Interfaces;
using senai_czBooks_webApiDB.Repositories;
using senai_czBooks_webApiDB.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface IUsuariosRepository
        /// </summary>
        private IUsuariosRepository _usuariorepository { get; set; }

        public LoginController()
        {
            //Atribui o _usuarioRepository ao UsuarioRepository para ter referências aos métodos lá montados
            _usuariorepository = new UsuariosRepository();
        }

        /// <summary>
        /// Realiza o login do usuario
        /// </summary>
        /// <param name="login">Objeto com as informações de login</param>
        /// <returns>Um status code - 200 com o token</returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                //Busca o usuario pelo email e senha
                usuarios usuarioBuscado = _usuariorepository.Login(login.email, login.senha);

                //verifica se foi achado alguém com o email e senha inseridos 
                if (usuarioBuscado == null)
                {
                    //Caso não tenha sido, retorna um status code com uma mensagem personalizada
                    return NotFound("E-mail ou senha inválidos!");
                }

                //Caso seja encotrado, continua

                //Define o que vai ser mostrado no Token
                var claims = new[]
                {
                    //Armazena o email do usuario autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),

                    //Armazena o ID do usuario autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),

                    //Armazena o nome do usuario atenticado
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.nome),

                    //Armazena o tipo de usuario e define que ele vai ser o parâmetro de validação dos métodos
                    new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())
                };

                //Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("cz-books-autenticacao"));

                //Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Gera o token
                var token = new JwtSecurityToken(

                    issuer: "czBooks.webApi",           //Emissor do token
                    audience: "czBooks.webApi",         //Destinatário do token
                    claims: claims,                     //Dados definidos na variável claims, na linha 56
                    expires: DateTime.Now.AddHours(1),  //Tempo de expiração do token
                    signingCredentials: creds           //Credenciais do token
                
                );

                //Retorna o status code com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                //Retorna o status code com o erro
                return BadRequest(ex);
            }
        }
    }
}
