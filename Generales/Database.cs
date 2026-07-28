using System;
using System.Collections.Generic;
using System.Text;

using BibliotecaPOO_CEspinoza.Models;

namespace BibliotecaPOO_CEspinoza.Generales
{
    public static class Database
    {
        // Lista de libros
        public static List<Libro> Libros = new List<Libro>();

        // Lista de autores
        public static List<Autor> Autores = new List<Autor>();

        // Lista de préstamos
        public static List<Prestamo> Prestamos = new List<Prestamo>();
    }
}