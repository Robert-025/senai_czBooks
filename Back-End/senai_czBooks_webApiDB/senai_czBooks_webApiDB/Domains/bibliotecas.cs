using System;
using System.Collections.Generic;

#nullable disable

namespace senai_czBooks_webApiDB.Domains
{
    public partial class bibliotecas
    {
        public bibliotecas()
        {
            livros = new HashSet<livros>();
        }

        public int idBiblioteca { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public string razaoSocial { get; set; }

        public virtual ICollection<livros> livros { get; set; }
    }
}
