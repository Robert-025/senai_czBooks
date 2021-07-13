using System;
using System.Collections.Generic;

#nullable disable

namespace senai_czBooks_webApiDB.Domains
{
    public partial class usuarios
    {
        public usuarios()
        {
            autors = new HashSet<autores>();
        }

        public int idUsuario { get; set; }
        public int? idTipoUsuario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public virtual tiposUsuarios idTipoUsuarioNavigation { get; set; }
        public virtual ICollection<autores> autors { get; set; }
    }
}
