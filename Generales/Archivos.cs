using System;
using System.Data.SqlClient; 
using BibliotecaPOO_CEspinoza.Models;

namespace BibliotecaPOO_CEspinoza.Generales
{
    public class Archivo
    {
        // ⚠️ IMPORTANTE: Cambia "TU_SERVIDOR" y "TU_BASE_DE_DATOS" por los datos reales de tu SQL Server
        // Si usas autenticación de Windows (LocalDB), puedes usar: "Server=(localdb)\\MSSQLLocalDB;Database=Biblioteca_CEspinoza;Integrated Security=True;"
        private string connectionString = "Server=Christian2025\\SQLEXPRESS;Database=Biblioteca_CEspinoza;Integrated Security=True;";

        // ===================== LIBROS =====================

        public void GuardarLibros()
        {
            Console.WriteLine("Guardando libros en SQL Server...");

           
            foreach (Libro libro in Database.Libros)
            {
                libro.GuardarEnSQLServer(connectionString);
            }

            Console.WriteLine("Proceso de guardado de libros finalizado.");
        }

        public void LeerLibros()
        {
            Console.WriteLine("========== LIBROS (DESDE SQL SERVER) ==========");
            string query = "SELECT Codigo, Titulo, Categoria, Anio, Editorial FROM Libros";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No hay libros registrados en la base de datos.");
                        }

                        while (reader.Read())
                        {
                            
                            Console.WriteLine($"{reader["Codigo"]} | {reader["Titulo"]} | {reader["Categoria"]} | {reader["Anio"]} | {reader["Editorial"]}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al leer libros de la BD: {ex.Message}");
                    }
                }
            }
        }

        // ===================== AUTORES =====================

        public void GuardarAutores()
        {
            Console.WriteLine("Guardando autores en SQL Server...");

            foreach (Autor autor in Database.Autores)
            {
                autor.GuardarEnSQLServer(connectionString);
            }

            Console.WriteLine("Proceso de guardado de autores finalizado.");
        }

        public void LeerAutores()
        {
            Console.WriteLine("========== AUTORES (DESDE SQL SERVER) ==========");
            string query = "SELECT Cedula, Nombre, Nacionalidad, Edad, Genero FROM Autores";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No hay autores registrados en la base de datos.");
                        }

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Cedula"]} | {reader["Nombre"]} | {reader["Nacionalidad"]} | {reader["Edad"]} | {reader["Genero"]}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al leer autores de la BD: {ex.Message}");
                    }
                }
            }
        }

        // ===================== PRÉSTAMOS =====================

        public void GuardarPrestamos()
        {
            Console.WriteLine("Guardando préstamos en SQL Server...");

            foreach (Prestamo prestamo in Database.Prestamos)
            {
                prestamo.GuardarEnSQLServer(connectionString);
            }

            Console.WriteLine("Proceso de guardado de préstamos finalizado.");
        }

        public void LeerPrestamos()
        {
            Console.WriteLine("========== PRÉSTAMOS (DESDE SQL SERVER) ==========");
            string query = "SELECT LibroCodigo, AutorCedula, FechaPrestamo, FechaDevolucion, Estado FROM Prestamos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No hay préstamos registrados en la base de datos.");
                        }

                        while (reader.Read())
                        {
                            // Formateamos las fechas al leerlas
                            DateTime fechaPres = Convert.ToDateTime(reader["FechaPrestamo"]);
                            DateTime fechaDev = Convert.ToDateTime(reader["FechaDevolucion"]);

                            Console.WriteLine($"{reader["LibroCodigo"]} | {reader["AutorCedula"]} | {fechaPres.ToShortDateString()} | {fechaDev.ToShortDateString()} | {reader["Estado"]}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al leer préstamos de la BD: {ex.Message}");
                    }
                }
            }
        }
    }
}