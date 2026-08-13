using System;
using System.Collections.Generic;
using System.Data.SqlClient; // Necesario para conectarse a SQL Server
using BibliotecaPOO_CEspinoza.Models;

namespace BibliotecaPOO_CEspinoza.Generales
{
    public static class Database
    {
        // ⚠️ IMPORTANTE: Pon aquí tu cadena de conexión real
        private static string connectionString = "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;Integrated Security=True;";

        // Listas en memoria (Tu código original)
        public static List<Libro> Libros = new List<Libro>();
        public static List<Autor> Autores = new List<Autor>();
        public static List<Prestamo> Prestamos = new List<Prestamo>();

        // NUEVO: Método para descargar todo de SQL Server y meterlo a las listas
        public static void CargarDesdeSQLServer()
        {
            // Limpiamos las listas por si acaso se llama al método dos veces
            Libros.Clear();
            Autores.Clear();
            Prestamos.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // ==========================================
                    // 1. CARGAR AUTORES
                    // ==========================================
                    string queryAutores = "SELECT Cedula, Nombre, Nacionalidad, Edad, Genero FROM Autores";
                    using (SqlCommand cmd = new SqlCommand(queryAutores, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Autor objAutor = new Autor(
                                reader["Cedula"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Nacionalidad"].ToString(),
                                Convert.ToInt32(reader["Edad"]),
                                reader["Genero"].ToString()
                            );
                            Autores.Add(objAutor);
                        }
                    }

                    // ==========================================
                    // 2. CARGAR LIBROS
                    // ==========================================
                    string queryLibros = "SELECT Codigo, Titulo, Categoria, Anio, Editorial FROM Libros";
                    using (SqlCommand cmd = new SqlCommand(queryLibros, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Libro objLibro = new Libro(
                                reader["Codigo"].ToString(),
                                reader["Titulo"].ToString(),
                                reader["Categoria"].ToString(),
                                Convert.ToInt32(reader["Anio"]),
                                reader["Editorial"].ToString()
                            );
                            Libros.Add(objLibro);
                        }
                    }

                    // ==========================================
                    // 3. CARGAR PRÉSTAMOS
                    // ==========================================
                    string queryPrestamos = "SELECT LibroCodigo, AutorCedula, FechaPrestamo, FechaDevolucion, Estado FROM Prestamos";
                    using (SqlCommand cmd = new SqlCommand(queryPrestamos, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string codigoLibro = reader["LibroCodigo"].ToString();
                            string cedulaAutor = reader["AutorCedula"].ToString();

                            // Buscamos el libro y autor exactos en las listas que acabamos de llenar arriba
                            Libro libroDelPrestamo = Libros.Find(l => l.Codigo == codigoLibro);
                            Autor autorDelPrestamo = Autores.Find(a => a.Cedula == cedulaAutor);

                            Prestamo objPrestamo = new Prestamo(
                                libroDelPrestamo,
                                autorDelPrestamo,
                                Convert.ToDateTime(reader["FechaPrestamo"]),
                                Convert.ToDateTime(reader["FechaDevolucion"]),
                                reader["Estado"].ToString()
                            );
                            Prestamos.Add(objPrestamo);
                        }
                    }

                    Console.WriteLine("Las listas de la memoria se sincronizaron con SQL Server exitosamente.");
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine($"Error de Base de Datos al sincronizar listas: {sqlEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error inesperado al cargar listas: {ex.Message}");
                }
            }
        }
    }
}