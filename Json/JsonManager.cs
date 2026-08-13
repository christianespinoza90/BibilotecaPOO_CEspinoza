using System;
using System.IO;
using System.Text.Json;
using BibliotecaPOO_CEspinoza.Models;

namespace BibliotecaPOO_CEspinoza.Generales
{
    public class JsonManager
    {
        // Rutas de los archivos JSON para nuestras copias de seguridad
        private string rutaLibros = "Libros_Backup.json";
        private string rutaAutores = "Autores_Backup.json";
        private string rutaPrestamos = "Prestamos_Backup.json";

        // Creamos las opciones una sola vez para reutilizarlas en todos los métodos
        private JsonSerializerOptions opcionesJson = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        // ===================== LIBROS =====================
        public void GuardarLibrosJson()
        {
            // Tomamos la lista de la memoria (que previamente se llenó desde SQL Server)
            string json = JsonSerializer.Serialize(Database.Libros, opcionesJson);
            File.WriteAllText(rutaLibros, json);
            Console.WriteLine("Libros exportados a JSON correctamente.");
        }

        public void LeerLibrosJson()
        {
            if (!File.Exists(rutaLibros))
            {
                Console.WriteLine("No existe el archivo JSON de libros.");
                return;
            }
            string json = File.ReadAllText(rutaLibros);
            Console.WriteLine("===== BACKUP LIBROS JSON =====");
            Console.WriteLine(json);
        }

        // ===================== AUTORES =====================
        public void GuardarAutoresJson()
        {
            string json = JsonSerializer.Serialize(Database.Autores, opcionesJson);
            File.WriteAllText(rutaAutores, json);
            Console.WriteLine("Autores exportados a JSON correctamente.");
        }

        public void LeerAutoresJson()
        {
            if (!File.Exists(rutaAutores))
            {
                Console.WriteLine("No existe el archivo JSON de autores.");
                return;
            }
            string json = File.ReadAllText(rutaAutores);
            Console.WriteLine("===== BACKUP AUTORES JSON =====");
            Console.WriteLine(json);
        }

        // ===================== PRÉSTAMOS =====================
        public void GuardarPrestamosJson()
        {
            string json = JsonSerializer.Serialize(Database.Prestamos, opcionesJson);
            File.WriteAllText(rutaPrestamos, json);
            Console.WriteLine("Préstamos exportados a JSON correctamente.");
        }

        public void LeerPrestamosJson()
        {
            if (!File.Exists(rutaPrestamos))
            {
                Console.WriteLine("No existe el archivo JSON de préstamos.");
                return;
            }
            string json = File.ReadAllText(rutaPrestamos);
            Console.WriteLine("===== BACKUP PRÉSTAMOS JSON =====");
            Console.WriteLine(json);
        }

        // ===================== MÉTODO GENERAL =====================
        public void GenerarBackupCompleto()
        {
            Console.WriteLine("Iniciando exportación total desde SQL Server a JSON...");
            GuardarLibrosJson();
            GuardarAutoresJson();
            GuardarPrestamosJson();
            Console.WriteLine("¡Copia de seguridad completa finalizada!");
        }
    }
}