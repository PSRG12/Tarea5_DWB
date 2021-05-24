using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Tarea5_DWB.DataAccess
{
    public partial class UsuariosContext : DbContext
    {
        public UsuariosContext()
        {
        }

        public UsuariosContext(DbContextOptions<UsuariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dato> Datos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SEBASTIAN;Database=Usuarios;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Dato>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
