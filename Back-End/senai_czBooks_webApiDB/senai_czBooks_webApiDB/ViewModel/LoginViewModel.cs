using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czBooks_webApiDB.ViewModel
{
    /// <summary>
    /// Objeto responsável pelo login do usuario
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email do usuário!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string senha { get; set; }
    }
}
