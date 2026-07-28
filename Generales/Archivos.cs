using System;
using System.IO;
using BibliotecaPOO_CEspinoza.Models;

namespace BibliotecaPOO_CEspinoza.Generales
{
    public class Archivo
    {
        // Rutas de los archivos
        private string rutaLibros = "Libros.txt";
        private string rutaAutores = "Autores.txt";
        private string rutaPrestamos = "Prestamos.txt";

        // ===================== LIBROS =====================

        public void GuardarLibros()
        {
            StreamWriter escritor = new StreamWriter(rutaLibros);

            foreach (Libro libro in Database.Libros)
            {
                escritor.WriteLine(
                    libro.Codigo + ";" +
                    libro.Titulo + ";" +
                    libro.Categoria + ";" +
                    libro.Anio + ";" +
                    libro.Editorial);
            }

            escritor.Close();

            Console.WriteLine("Libros guardados correctamente.");
        }

        public void LeerLibros()
        {
            if (!File.Exists(rutaLibros))
            {
                Console.WriteLine("No existe el archivo de libros.");
                return;
            }

            StreamReader lector = new StreamReader(rutaLibros);

            Console.WriteLine("========== LIBROS ==========");

            while (!lector.EndOfStream)
            {
                Console.WriteLine(lector.ReadLine());
            }

            lector.Close();
        }

        // ===================== AUTORES =====================

        public void GuardarAutores()
        {
            StreamWriter escritor = new StreamWriter(rutaAutores);

            foreach (Autor autor in Database.Autores)
            {
                escritor.WriteLine(
                    autor.Cedula + ";" +
                    autor.Nombre + ";" +
                    autor.Nacionalidad + ";" +
                    autor.Edad + ";" +
                    autor.Genero);
            }

            escritor.Close();

            Console.WriteLine("Autores guardados correctamente.");
        }

        public void LeerAutores()
        {
            if (!File.Exists(rutaAutores))
            {
                Console.WriteLine("No existe el archivo de autores.");
                return;
            }

            StreamReader lector = new StreamReader(rutaAutores);

            Console.WriteLine("========== AUTORES ==========");

            while (!lector.EndOfStream)
            {
                Console.WriteLine(lector.ReadLine());
            }

            lector.Close();
        }

        // ===================== PRÉSTAMOS =====================

        public void GuardarPrestamos()
        {
            StreamWriter escritor = new StreamWriter(rutaPrestamos);

            foreach (Prestamo prestamo in Database.Prestamos)
            {
                escritor.WriteLine(
                    prestamo.Libro.Codigo + ";" +
                    prestamo.Autor.Cedula + ";" +
                    prestamo.FechaPrestamo.ToShortDateString() + ";" +
                    prestamo.FechaDevolucion.ToShortDateString() + ";" +
                    prestamo.Estado);
            }

            escritor.Close();

            Console.WriteLine("Préstamos guardados correctamente.");
        }

        public void LeerPrestamos()
        {
            if (!File.Exists(rutaPrestamos))
            {
                Console.WriteLine("No existe el archivo de préstamos.");
                return;
            }

            StreamReader lector = new StreamReader(rutaPrestamos);

            Console.WriteLine("========== PRÉSTAMOS ==========");

            while (!lector.EndOfStream)
            {
                Console.WriteLine(lector.ReadLine());
            }

            lector.Close();
        }
    }
}