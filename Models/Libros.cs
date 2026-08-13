using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; 

namespace BibliotecaPOO_CEspinoza.Models
{
    public class Libro
    {
        // ATRIBUTOS PRIVADOS
        private string codigo;
        private string titulo;
        private string categoria;
        private int anio;
        private string editorial;

        // PROPIEDADES
        public string Codigo { get => codigo; set => codigo = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int Anio { get => anio; set => anio = value; }
        public string Editorial { get => editorial; set => editorial = value; }

        // CONSTRUCTORES
       
        public Libro()
        {
        }

        // Constructor con parámetros
        public Libro(string codigo, string titulo, string categoria, int anio, string editorial)
        {
            this.Codigo = codigo;
            this.Titulo = titulo;
            this.Categoria = categoria;
            this.Anio = anio;
            this.Editorial = editorial;
        }

        // MÉTODOS
        public void Imprimir()
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Código: {this.Codigo}");
            Console.WriteLine($"Título: {this.Titulo}");
            Console.WriteLine($"Categoría: {this.Categoria}");
            Console.WriteLine($"Año: {this.Anio}");
            Console.WriteLine($"Editorial: {this.Editorial}");
        }

        public void GuardarEnSQLServer(string connectionString)
        {
          
            string query = "INSERT INTO Libros (Codigo, Titulo, Categoria, Anio, Editorial) " +
                           "VALUES (@Codigo, @Titulo, @Categoria, @Anio, @Editorial)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", this.Codigo);
                    command.Parameters.AddWithValue("@Titulo", this.Titulo);
                    command.Parameters.AddWithValue("@Categoria", this.Categoria);
                    command.Parameters.AddWithValue("@Anio", this.Anio);
                    command.Parameters.AddWithValue("@Editorial", this.Editorial);

                    try
                    {
                        connection.Open(); 
                        int filasAfectadas = command.ExecuteNonQuery(); 

                        if (filasAfectadas > 0)
                        {
                            Console.WriteLine("¡El libro se subió exitosamente a la base de datos SQL Server!");
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        Console.WriteLine($"Error de Base de Datos: {sqlEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ocurrió un error inesperado al guardar el libro: {ex.Message}");
                    }
                }
            }
        }
    }
}