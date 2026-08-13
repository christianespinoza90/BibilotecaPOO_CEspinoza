using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; // Requiere instalar el paquete desde NuGet

namespace BibliotecaPOO_CEspinoza.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        // ATRIBUTOS PRIVADOS
        private Libro libro;
        private Autor autor;
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucion;
        private string estado;

        // PROPIEDADES
        public Libro Libro { get => libro; set => libro = value; }
        public Autor Autor { get => autor; set => autor = value; }
        public DateTime FechaPrestamo { get => fechaPrestamo; set => fechaPrestamo = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public string Estado { get => estado; set => estado = value; }

        // CONSTRUCTORES
        // Constructor vacío
        public Prestamo()
        {
        }

        // Constructor con parámetros
        public Prestamo(Libro libro, Autor autor, DateTime fechaPrestamo, DateTime fechaDevolucion, string estado)
        {
            this.Libro = libro;
            this.Autor = autor;
            this.FechaPrestamo = fechaPrestamo;
            this.FechaDevolucion = fechaDevolucion;
            this.Estado = estado;
        }

        // MÉTODOS
        public void Imprimir()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("        INFORMACIÓN DEL PRÉSTAMO");
            Console.WriteLine("======================================");
            // Validamos que el libro y el autor no sean nulos antes de imprimir
            Console.WriteLine($"Libro: {this.Libro?.Titulo ?? "Sin asignar"}");
            Console.WriteLine($"Autor: {this.Autor?.Nombre ?? "Sin asignar"}");
            Console.WriteLine($"Fecha de préstamo: {this.FechaPrestamo:dd/MM/yyyy}");
            Console.WriteLine($"Fecha de devolución: {this.FechaDevolucion:dd/MM/yyyy}");
            Console.WriteLine($"Estado: {this.Estado}");
            Console.WriteLine("======================================");
        }

        // Método para insertar el préstamo en la base de datos SQL Server
        public void GuardarEnSQLServer(string connectionString)
        {
            // Validación de seguridad para evitar errores si falta el libro o el autor
            if (this.Libro == null || this.Autor == null)
            {
                Console.WriteLine("Error: No se puede guardar el préstamo. Debe tener un Libro y un Autor asignados.");
                return;
            }

            // Consulta SQL parametrizada. 
            // Omitimos el 'Id' porque SQL Server lo genera automáticamente con IDENTITY
            string query = "INSERT INTO Prestamos (LibroCodigo, AutorCedula, FechaPrestamo, FechaDevolucion, Estado) " +
                           "VALUES (@LibroCodigo, @AutorCedula, @FechaPrestamo, @FechaDevolucion, @Estado)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Extraemos las claves foráneas (Codigo y Cedula) de los objetos relacionados
                    command.Parameters.AddWithValue("@LibroCodigo", this.Libro.Codigo);
                    command.Parameters.AddWithValue("@AutorCedula", this.Autor.Cedula);
                    command.Parameters.AddWithValue("@FechaPrestamo", this.FechaPrestamo);
                    command.Parameters.AddWithValue("@FechaDevolucion", this.FechaDevolucion);
                    command.Parameters.AddWithValue("@Estado", this.Estado);

                    try
                    {
                        connection.Open();
                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine("¡El préstamo se subió exitosamente a la base de datos SQL Server!");
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        Console.WriteLine($"Error de Base de Datos: {sqlEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ocurrió un error inesperado al guardar el préstamo: {ex.Message}");
                    }
                }
            }
        }
    }
}