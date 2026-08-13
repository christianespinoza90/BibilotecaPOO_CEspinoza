using System;
using System.Data.SqlClient; 

namespace BibliotecaPOO_CEspinoza.Models
{
    public class Autor
    {
        // ATRIBUTOS PRIVADOS
        private string cedula;
        private string nombre;
        private string nacionalidad;
        private int edad;
        private string genero;

        // PROPIEDADES
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Genero { get => genero; set => genero = value; }

        // CONSTRUCTORES
        
        public Autor()
        {
        }

        // Constructor con parámetros
        public Autor(string cedula, string nombre, string nacionalidad, int edad, string genero)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
            this.Edad = edad;
            this.Genero = genero;
        }

        // MÉTODOS
        public void Imprimir()
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Cédula: {this.Cedula}");
            Console.WriteLine($"Nombre: {this.Nombre}");
            Console.WriteLine($"Nacionalidad: {this.Nacionalidad}");
            Console.WriteLine($"Edad: {this.Edad}");
            Console.WriteLine($"Género: {this.Genero}");
        }

        
        public void GuardarEnSQLServer(string connectionString)
        {
           
            string query = "INSERT INTO Autores (Cedula, Nombre, Nacionalidad, Edad, Genero) " +
                           "VALUES (@Cedula, @Nombre, @Nacionalidad, @Edad, @Genero)";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@Cedula", this.Cedula);
                    command.Parameters.AddWithValue("@Nombre", this.Nombre);
                    command.Parameters.AddWithValue("@Nacionalidad", this.Nacionalidad);
                    command.Parameters.AddWithValue("@Edad", this.Edad);
                    command.Parameters.AddWithValue("@Genero", this.Genero);

                    try
                    {
                        connection.Open(); 
                        int filasAfectadas = command.ExecuteNonQuery(); 

                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine("¡El autor se subió exitosamente a la base de datos SQL Server!");
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        Console.WriteLine($"Error de Base de Datos: {sqlEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                    }
                }
            }
        }
    }
}