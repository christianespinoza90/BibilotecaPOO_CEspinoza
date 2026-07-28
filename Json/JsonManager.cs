
    using global::BibliotecaPOO_CEspinoza.Generales;
    using System;
    using System.IO;
    using System.Text.Json;

    namespace BibliotecaPOO_CEspinoza.Generales
    {
        public class JsonManager
        {
            private string rutaLibros = "Libros.json";

            public void GuardarLibrosJson()
            {
                string json = JsonSerializer.Serialize(Database.Libros,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                File.WriteAllText(rutaLibros, json);

                Console.WriteLine("Libros guardados en formato JSON.");
            }

            public void LeerLibrosJson()
            {
                if (!File.Exists(rutaLibros))
                {
                    Console.WriteLine("No existe el archivo JSON.");
                    return;
                }

                string json = File.ReadAllText(rutaLibros);

                Console.WriteLine("===== CONTENIDO JSON =====");
                Console.WriteLine(json);
            }
        }
    }

