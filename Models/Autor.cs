using System;
using System.Collections.Generic;
using System.Text;
namespace BibliotecaPOO_CEspinoza.Models
{
    public class Autor
    {
        // Atributos
        private string cedula;
        private string nombre;
        private string nacionalidad;
        private int edad;
        private string genero;

        // Propiedades
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Genero { get => genero; set => genero = value; }

        // Constructor
        public Autor(string cedula, string nombre, string nacionalidad, int edad, string genero)
        {
            Cedula = cedula;
            Nombre = nombre;
            Nacionalidad = nacionalidad;
            Edad = edad;
            Genero = genero;
        }

        // Método para mostrar información
        public void Imprimir()
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Cédula: {Cedula}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Nacionalidad: {Nacionalidad}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Género: {Genero}");
        }
    }
}