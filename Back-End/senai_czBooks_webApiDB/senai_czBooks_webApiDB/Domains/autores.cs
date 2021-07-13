using System;
using System.Collections.Generic;

#nullable disable

namespace senai_czBooks_webApiDB.Domains
{
    public partial class autores
    {
        public autores()
        {
            livros = new HashSet<livros>();
        }

        public int idAutor { get; set; }
        public int? idUsuario { get; set; }
        public string sobrenome { get; set; }

        public virtual usuarios idUsuarioNavigation { get; set; }
        public virtual ICollection<livros> livros { get; set; }
    }
}
