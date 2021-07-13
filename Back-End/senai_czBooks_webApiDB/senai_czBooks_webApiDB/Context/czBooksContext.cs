using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_czBooks_webApiDB.Domains;

#nullable disable

namespace senai_czBooks_webApiDB.Context
{
    public partial class czBooksContext : DbContext
    {
        public czBooksContext()
        {
        }

        public czBooksContext(DbContextOptions<czBooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<autores> autors { get; set; }
        public virtual DbSet<bibliotecas> bibliotecas { get; set; }
        public virtual DbSet<categorias> categoria { get; set; }
        public virtual DbSet<livros> livros { get; set; }
        public virtual DbSet<tiposUsuarios> tiposUsuarios { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=ROBERT-025; Initial Catalog=senai_czBooks; user id=sa; pwd=senai@132;");
                optionsBuilder.UseSqlServer("Data Source=LAB08DESK1001\\SQLEXPRESS; Initial Catalog=senai_czBooks; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<autores>(entity =>
            {
                entity.HasKey(e => e.idAutor)
                    .HasName("PK__autor__9AE8206A879F5087");

                entity.ToTable("autor");

                entity.Property(e => e.sobrenome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.idUsuarioNavigation)
                    .WithMany(p => p.autors)
                    .HasForeignKey(d => d.idUsuario)
                    .HasConstraintName("FK__autor__idUsuario__4316F928");
            });

            modelBuilder.Entity<bibliotecas>(entity =>
            {
                entity.HasKey(e => e.idBiblioteca)
                    .HasName("PK__bibliote__E7C768B6F8BA0B57");

                entity.ToTable("biblioteca");

                entity.HasIndex(e => e.cnpj, "UQ__bibliote__35BD3E48DCEAC50C")
                    .IsUnique();

                entity.HasIndex(e => e.endereco, "UQ__bibliote__9456D406DE96152C")
                    .IsUnique();

                entity.Property(e => e.cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.endereco)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.razaoSocial)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<categorias>(entity =>
            {
                entity.HasKey(e => e.idCategoria)
                    .HasName("PK__categori__8A3D240C122579B8");

                entity.HasIndex(e => e.categoria, "UQ__categori__1179412F98E82435")
                    .IsUnique();

                entity.Property(e => e.categoria)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<livros>(entity =>
            {
                entity.HasKey(e => e.idLivro)
                    .HasName("PK__livro__63C546D7FB6EEF57");

                entity.ToTable("livro");

                entity.Property(e => e.dataPublicacao).HasColumnType("date");

                entity.Property(e => e.preco).HasColumnType("money");

                entity.Property(e => e.sinopse)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.idAutorNavigation)
                    .WithMany(p => p.livros)
                    .HasForeignKey(d => d.idAutor)
                    .HasConstraintName("FK__livro__idAutor__46E78A0C");

                entity.HasOne(d => d.idBibliotecaNavigation)
                    .WithMany(p => p.livros)
                    .HasForeignKey(d => d.idBiblioteca)
                    .HasConstraintName("FK__livro__idBibliot__47DBAE45");

                entity.HasOne(d => d.idCategoriaNavigation)
                    .WithMany(p => p.livros)
                    .HasForeignKey(d => d.idCategoria)
                    .HasConstraintName("FK__livro__idCategor__45F365D3");
            });

            modelBuilder.Entity<tiposUsuarios>(entity =>
            {
                entity.HasKey(e => e.idTipoUsuario)
                    .HasName("PK__tiposUsu__03006BFF1815E4AB");

                entity.ToTable("tiposUsuario");

                entity.Property(e => e.tipo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<usuarios>(entity =>
            {
                entity.HasKey(e => e.idUsuario)
                    .HasName("PK__usuario__645723A6E6A27CED");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.email, "UQ__usuario__AB6E6164B66CEFCA")
                    .IsUnique();

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.senha)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.idTipoUsuarioNavigation)
                    .WithMany(p => p.usuarios)
                    .HasForeignKey(d => d.idTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
