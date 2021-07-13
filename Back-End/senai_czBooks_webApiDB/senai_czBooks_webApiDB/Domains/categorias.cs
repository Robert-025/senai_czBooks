using System;
using System.Collections.Generic;

#nullable disable

namespace senai_czBooks_webApiDB.Domains
{
    public partial class categorias
    {
        public categorias()
        {
            livros = new HashSet<livros>();
        }

        public int idCategoria { get; set; }
        public string categoria { get; set; }

        public virtual ICollection<livros> livros { get; set; }
    }
}
