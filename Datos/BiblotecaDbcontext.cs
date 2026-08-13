using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaPOO_CEspinoza.Models;

namespace BibliotecaPOO_CEspinoza.Datos
{
    public class BibliotecaDbContext : DbContext
    {
        // 1er paso: DbSet para cada clase que se quiera mapear a la base de datos
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        // 2do paso: Configurar la cadena de conexión
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // CADENA DE CONEXIÓN SQL SERVER (Cambié el nombre de la base de datos a BIBLIOTECA_Cespinoza)
            optionsBuilder.UseSqlServer("Server=Christian2025\\SQLEXPRESS;Database=BIBLIOTECA_Cespinoza;User Id=sa;Password=12345;TrustServerCertificate=True;");
        }

        // 3er paso: Configurar las relaciones entre las tablas y claves
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ==========================================
            // CONFIGURACIÓN DE CLAVES PRIMARIAS (PK)
            // ==========================================
            modelBuilder.Entity<Autor>()
                .HasKey(a => a.Cedula);

            modelBuilder.Entity<Libro>()
                .HasKey(l => l.Codigo);

            // Nota: Si Prestamo no tiene una propiedad "Id", Entity Framework puede requerir que se la agregues
            // public int Id { get; set; } en tu clase Prestamo.

            // ==========================================
            // CONFIGURACIÓN DE RELACIONES
            // ==========================================

            // Relación: 1 Libro tiene Muchos Préstamos
            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Libro)
                .WithMany()
                // Define cómo se llamará la columna de la clave foránea en la tabla Prestamos
                .HasForeignKey("LibroCodigo")
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: 1 Autor tiene Muchos Préstamos
            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Autor)
                .WithMany()
                // Define cómo se llamará la columna de la clave foránea en la tabla Prestamos
                .HasForeignKey("AutorCedula")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}