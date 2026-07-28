using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPOO_CEspinoza.Models
{
    public class Libro
    {
        // Atributos
        private string codigo;
        private string titulo;
        private string categoria;
        private int anio;
        private string editorial;

        // Propiedades
        public string Codigo { get => codigo; set => codigo = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int Anio { get => anio; set => anio = value; }
        public string Editorial { get => editorial; set => editorial = value; }

        // Constructor
        public Libro(string codigo, string titulo, string categoria, int anio, string editorial)
        {
            Codigo = codigo;
            Titulo = titulo;
            Categoria = categoria;
            Anio = anio;
            Editorial = editorial;
        }

        // Método
        public void Imprimir()
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Categoría: {Categoria}");
            Console.WriteLine($"Año: {Anio}");
            Console.WriteLine($"Editorial: {Editorial}");
        }
    }
}
