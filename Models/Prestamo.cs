using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPOO_CEspinoza.Models
{
    public class Prestamo
    {
        // Atributos
        private Libro libro;
        private Autor autor;
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucion;
        private string estado;

        // Propiedades
        public Libro Libro { get => libro; set => libro = value; }
        public Autor Autor { get => autor; set => autor = value; }
        public DateTime FechaPrestamo { get => fechaPrestamo; set => fechaPrestamo = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public string Estado { get => estado; set => estado = value; }

        // Constructor
        public Prestamo(Libro libro, Autor autor, DateTime fechaPrestamo,
                        DateTime fechaDevolucion, string estado)
        {
            Libro = libro;
            Autor = autor;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            Estado = estado;
        }

        // Método para mostrar la información del préstamo
        public void Imprimir()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("        INFORMACIÓN DEL PRÉSTAMO");
            Console.WriteLine("======================================");
            Console.WriteLine($"Libro: {Libro.Titulo}");
            Console.WriteLine($"Autor: {Autor.Nombre}");
            Console.WriteLine($"Fecha de préstamo: {FechaPrestamo:dd/MM/yyyy}");
            Console.WriteLine($"Fecha de devolución: {FechaDevolucion:dd/MM/yyyy}");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine("======================================");
        }
    }
}