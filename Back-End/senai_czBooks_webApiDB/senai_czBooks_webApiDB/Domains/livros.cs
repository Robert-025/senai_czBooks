using System;
using System.Collections.Generic;

#nullable disable

namespace senai_czBooks_webApiDB.Domains
{
    public partial class livros
    {
        public int idLivro { get; set; }
        public int? idCategoria { get; set; }
        public int? idAutor { get; set; }
        public int? idBiblioteca { get; set; }
        public string titulo { get; set; }
        public string sinopse { get; set; }
        public DateTime? dataPublicacao { get; set; }
        public decimal? preco { get; set; }

        public virtual autores idAutorNavigation { get; set; }
        public virtual bibliotecas idBibliotecaNavigation { get; set; }
        public virtual categorias idCategoriaNavigation { get; set; }
    }
}
