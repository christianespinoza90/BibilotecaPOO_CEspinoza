
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient; // Necesario para ejecutar UPDATE y DELETE
using BibliotecaPOO_CEspinoza.Generales;
using BibliotecaPOO_CEspinoza.Models;


string connectionString = "Server=Christian2025\\SQLEXPRESS;Database=BIBLIOTECA_Cespinoza;Integrated Security=True;";

// Instancias generales
Archivo archivo = new Archivo();
JsonManager json = new JsonManager();

// 1. CARGAMOS LOS DATOS DESDE SQL SERVER AL INICIAR EL PROGRAMA
Database.CargarDesdeSQLServer();

int opcion;

do
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("====================================================");
    Console.WriteLine("        SISTEMA DE GESTIÓN DE BIBLIOTECA");
    Console.WriteLine("====================================================");
    Console.WriteLine("1. Gestión de Libros");
    Console.WriteLine("2. Gestión de Autores");
    Console.WriteLine("3. Gestión de Préstamos");
    Console.WriteLine("4. Copias de Seguridad (Archivos JSON)");
    Console.WriteLine("5. Salir");
    Console.WriteLine("====================================================");
    Console.ResetColor();

    try
    {
        Console.Write("Seleccione una opción: ");
        opcion = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nDebe ingresar un número.");
        Console.ResetColor();
        Console.ReadKey();
        opcion = 0;
        continue;
    }

    switch (opcion)
    {
        case 1: MenuLibros(); break;
        case 2: MenuAutores(); break;
        case 3: MenuPrestamos(); break;
        case 4: MenuArchivos(); break;
        case 5: Console.WriteLine("\nGracias por utilizar el sistema."); break;
        default:
            Console.WriteLine("\nOpción no válida.");
            Console.ReadKey();
            break;
    }

} while (opcion != 5);

// =========================================================================================
// MENÚS SECUNDARIOS
// =========================================================================================

void MenuLibros()
{
    Console.Clear();
    Console.WriteLine("========== GESTIÓN DE LIBROS ==========");
    Console.WriteLine("1. Crear Libro");
    Console.WriteLine("2. Listar Libros");
    Console.WriteLine("3. Buscar Libro");
    Console.WriteLine("4. Actualizar Libro");
    Console.WriteLine("5. Eliminar Libro");
    Console.WriteLine("6. Regresar");
    Console.Write("\nSeleccione una opción: ");
    int op = Convert.ToInt32(Console.ReadLine());

    switch (op)
    {
        case 1: CrearLibro(); break;
        case 2: ListarLibros(); break;
        case 3: BuscarLibro(); break;
        case 4: ActualizarLibro(); break;
        case 5: EliminarLibro(); break;
    }
}

void MenuAutores()
{
    Console.Clear();
    Console.WriteLine("========== GESTIÓN DE AUTORES ==========");
    Console.WriteLine("1. Crear Autor");
    Console.WriteLine("2. Listar Autores");
    Console.WriteLine("3. Buscar Autor");
    Console.WriteLine("4. Actualizar Autor");
    Console.WriteLine("5. Eliminar Autor");
    Console.WriteLine("6. Regresar");
    Console.Write("\nSeleccione una opción: ");
    int op = Convert.ToInt32(Console.ReadLine());

    switch (op)
    {
        case 1: CrearAutor(); break;
        case 2: ListarAutores(); break;
        case 3: BuscarAutor(); break;
        case 4: ActualizarAutor(); break;
        case 5: EliminarAutor(); break;
    }
}

void MenuPrestamos()
{
    Console.Clear();
    Console.WriteLine("========== GESTIÓN DE PRÉSTAMOS ==========");
    Console.WriteLine("1. Crear Préstamo");
    Console.WriteLine("2. Listar Préstamos");
    Console.WriteLine("3. Buscar Préstamo");
    Console.WriteLine("4. Actualizar Préstamo");
    Console.WriteLine("5. Eliminar Préstamo");
    Console.WriteLine("6. Regresar");
    Console.Write("\nSeleccione una opción: ");
    int op = Convert.ToInt32(Console.ReadLine());

    switch (op)
    {
        case 1: CrearPrestamo(); break;
        case 2: ListarPrestamos(); break;
        case 3: BuscarPrestamo(); break;
        case 4: ActualizarPrestamo(); break;
        case 5: EliminarPrestamo(); break;
    }
}

void MenuArchivos()
{
    Console.Clear();
    Console.WriteLine("========== COPIAS DE SEGURIDAD (JSON) ==========");
    Console.WriteLine("1. Generar Backup Completo (Libros, Autores y Préstamos)");
    Console.WriteLine("2. Leer Backup de Libros");
    Console.WriteLine("3. Leer Backup de Autores");
    Console.WriteLine("4. Leer Backup de Préstamos");
    Console.WriteLine("5. Regresar");
    Console.Write("\nSeleccione una opción: ");
    int op = Convert.ToInt32(Console.ReadLine());

    switch (op)
    {
        case 1: json.GenerarBackupCompleto(); break;
        case 2: json.LeerLibrosJson(); break;
        case 3: json.LeerAutoresJson(); break;
        case 4: json.LeerPrestamosJson(); break;
        case 5: return;
    }
    Console.ReadKey();
}

// =========================================================================================
// MÉTODOS CRUD - LIBROS
// =========================================================================================

void CrearLibro()
{
    Console.Clear();
    Console.WriteLine("===== CREAR LIBRO =====");
    Console.Write("Código: ");
    string codigo = Console.ReadLine();

    Libro existe = Database.Libros.Find(l => l.Codigo == codigo);
    if (existe != null)
    {
        Console.WriteLine("Ya existe un libro con ese código.");
        Console.ReadKey(); return;
    }

    Console.Write("Título: "); string titulo = Console.ReadLine();
    Console.Write("Categoría: "); string categoria = Console.ReadLine();
    Console.Write("Año: "); int anio = Convert.ToInt32(Console.ReadLine());
    Console.Write("Editorial: "); string editorial = Console.ReadLine();

    Libro libro = new Libro(codigo, titulo, categoria, anio, editorial);
    Database.Libros.Add(libro); // Agrega a la lista

    libro.GuardarEnSQLServer(connectionString); // Guarda en la BD SQL
    Console.ReadKey();
}

void ListarLibros()
{
    Console.Clear();
    Console.WriteLine("===== LISTA DE LIBROS =====");
    if (Database.Libros.Count == 0) Console.WriteLine("No existen libros registrados.");
    else
    {
        foreach (Libro libro in Database.Libros)
        {
            libro.Imprimir();
            Console.WriteLine("----------------------------");
        }
    }
    Console.ReadKey();
}

void BuscarLibro()
{
    Console.Clear();
    Console.WriteLine("===== BUSCAR LIBRO =====");
    Console.Write("Ingrese el código del libro: ");
    string codigo = Console.ReadLine();

    Libro libro = Database.Libros.Find(l => l.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
    if (libro != null) libro.Imprimir();
    else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Libro no encontrado."); Console.ResetColor(); }
    Console.ReadKey();
}

void ActualizarLibro()
{
    Console.Clear();
    Console.WriteLine("===== ACTUALIZAR LIBRO =====");
    Console.Write("Ingrese el código del libro: ");
    string codigo = Console.ReadLine();

    Libro libro = Database.Libros.Find(l => l.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
    if (libro != null)
    {
        Console.Write("Nuevo título: "); string nuevoTitulo = Console.ReadLine();
        Console.Write("Nueva categoría: "); string nuevaCat = Console.ReadLine();
        Console.Write("Nuevo año: "); int nuevoAnio = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nueva editorial: "); string nuevaEdi = Console.ReadLine();

        // 1. Actualizamos la memoria
        libro.Titulo = nuevoTitulo; libro.Categoria = nuevaCat; libro.Anio = nuevoAnio; libro.Editorial = nuevaEdi;

        // 2. Actualizamos la BD
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "UPDATE Libros SET Titulo=@t, Categoria=@c, Anio=@a, Editorial=@e WHERE Codigo=@cod";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@t", nuevoTitulo);
                cmd.Parameters.AddWithValue("@c", nuevaCat);
                cmd.Parameters.AddWithValue("@a", nuevoAnio);
                cmd.Parameters.AddWithValue("@e", nuevaEdi);
                cmd.Parameters.AddWithValue("@cod", codigo);
                conn.Open(); cmd.ExecuteNonQuery();
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nLibro actualizado en SQL Server correctamente."); Console.ResetColor();
    }
    else { Console.WriteLine("Libro no encontrado."); }
    Console.ReadKey();
}

void EliminarLibro()
{
    Console.Clear();
    Console.WriteLine("===== ELIMINAR LIBRO =====");
    Console.Write("Ingrese el código del libro: ");
    string codigo = Console.ReadLine();

    Libro libro = Database.Libros.Find(l => l.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
    if (libro != null)
    {
        libro.Imprimir();
        Console.Write("\n¿Desea eliminar este libro? (S/N): ");
        if (Console.ReadLine().ToUpper() == "S")
        {
            Database.Libros.Remove(libro); // Borrar de memoria

            // Borrar de SQL Server
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Libros WHERE Codigo=@cod";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cod", codigo);
                    conn.Open(); cmd.ExecuteNonQuery();
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Libro eliminado de SQL Server."); Console.ResetColor();
        }
    }
    else { Console.WriteLine("Libro no encontrado."); }
    Console.ReadKey();
}


void CrearAutor()
{
    Console.Clear();
    Console.WriteLine("===== CREAR AUTOR =====");
    Console.Write("Cédula: "); string cedula = Console.ReadLine();

    Autor existe = Database.Autores.Find(a => a.Cedula == cedula);
    if (existe != null) { Console.WriteLine("Ya existe un autor con esa cédula."); Console.ReadKey(); return; }

    Console.Write("Nombre: "); string nombre = Console.ReadLine();
    Console.Write("Nacionalidad: "); string nacionalidad = Console.ReadLine();
    Console.Write("Edad: "); int edad = Convert.ToInt32(Console.ReadLine());
    Console.Write("Género: "); string genero = Console.ReadLine();

    Autor autor = new Autor(cedula, nombre, nacionalidad, edad, genero);
    Database.Autores.Add(autor);

    autor.GuardarEnSQLServer(connectionString);
    Console.ReadKey();
}

void ListarAutores()
{
    Console.Clear();
    Console.WriteLine("===== LISTA DE AUTORES =====");
    if (Database.Autores.Count == 0) Console.WriteLine("No existen autores registrados.");
    else { foreach (Autor autor in Database.Autores) { autor.Imprimir(); Console.WriteLine("--------------------------------"); } }
    Console.ReadKey();
}

void BuscarAutor()
{
    Console.Clear();
    Console.Write("Ingrese la cédula: "); string cedula = Console.ReadLine();
    Autor autor = Database.Autores.Find(a => a.Cedula == cedula);
    if (autor != null) autor.Imprimir();
    else Console.WriteLine("Autor no encontrado.");
    Console.ReadKey();
}

void ActualizarAutor()
{
    Console.Clear();
    Console.Write("Ingrese la cédula: "); string cedula = Console.ReadLine();
    Autor autor = Database.Autores.Find(a => a.Cedula == cedula);

    if (autor != null)
    {
        Console.Write("Nuevo nombre: "); string nuevoNombre = Console.ReadLine();
        Console.Write("Nueva nacionalidad: "); string nuevaNac = Console.ReadLine();
        Console.Write("Nueva edad: "); int nuevaEdad = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nuevo género: "); string nuevoGenero = Console.ReadLine();

        autor.Nombre = nuevoNombre; autor.Nacionalidad = nuevaNac; autor.Edad = nuevaEdad; autor.Genero = nuevoGenero;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "UPDATE Autores SET Nombre=@n, Nacionalidad=@na, Edad=@e, Genero=@g WHERE Cedula=@ced";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@n", nuevoNombre);
                cmd.Parameters.AddWithValue("@na", nuevaNac);
                cmd.Parameters.AddWithValue("@e", nuevaEdad);
                cmd.Parameters.AddWithValue("@g", nuevoGenero);
                cmd.Parameters.AddWithValue("@ced", cedula);
                conn.Open(); cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Autor actualizado en SQL Server.");
    }
    else { Console.WriteLine("Autor no encontrado."); }
    Console.ReadKey();
}

void EliminarAutor()
{
    Console.Clear();
    Console.Write("Ingrese la cédula: "); string cedula = Console.ReadLine();
    Autor autor = Database.Autores.Find(a => a.Cedula == cedula);

    if (autor != null)
    {
        Database.Autores.Remove(autor);
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Autores WHERE Cedula=@ced";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ced", cedula);
                conn.Open(); cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Autor eliminado de SQL Server.");
    }
    else { Console.WriteLine("Autor no encontrado."); }
    Console.ReadKey();
}


void CrearPrestamo()
{
    Console.Clear();
    Console.WriteLine("===== CREAR PRÉSTAMO =====");
    if (Database.Libros.Count == 0 || Database.Autores.Count == 0) { Console.WriteLine("Debe haber libros y autores registrados primero."); Console.ReadKey(); return; }

    Console.Write("Código del libro: "); string codigo = Console.ReadLine();
    Libro libro = Database.Libros.Find(l => l.Codigo == codigo);
    if (libro == null) { Console.WriteLine("Libro no encontrado."); Console.ReadKey(); return; }

    Console.Write("Cédula del autor: "); string cedula = Console.ReadLine();
    Autor autor = Database.Autores.Find(a => a.Cedula == cedula);
    if (autor == null) { Console.WriteLine("Autor no encontrado."); Console.ReadKey(); return; }

    Console.Write("Fecha préstamo (dd/MM/yyyy): "); DateTime fPrestamo = Convert.ToDateTime(Console.ReadLine());
    Console.Write("Fecha devolución (dd/MM/yyyy): "); DateTime fDev = Convert.ToDateTime(Console.ReadLine());
    Console.Write("Estado: "); string estado = Console.ReadLine();

    Prestamo prestamo = new Prestamo(libro, autor, fPrestamo, fDev, estado);
    Database.Prestamos.Add(prestamo);

    prestamo.GuardarEnSQLServer(connectionString);
    Console.ReadKey();
}

void ListarPrestamos()
{
    Console.Clear();
    Console.WriteLine("===== LISTA DE PRÉSTAMOS =====");
    if (Database.Prestamos.Count == 0) Console.WriteLine("No existen préstamos registrados.");
    else { foreach (Prestamo p in Database.Prestamos) { p.Imprimir(); Console.WriteLine("--------------------------------"); } }
    Console.ReadKey();
}

void BuscarPrestamo()
{
    Console.Clear();
    Console.Write("Código del libro: "); string codigo = Console.ReadLine();
    Prestamo prestamo = Database.Prestamos.Find(p => p.Libro.Codigo == codigo);
    if (prestamo != null) prestamo.Imprimir();
    else Console.WriteLine("Préstamo no encontrado.");
    Console.ReadKey();
}

void ActualizarPrestamo()
{
    Console.Clear();
    Console.Write("Código del libro: "); string codigo = Console.ReadLine();
    Prestamo prestamo = Database.Prestamos.Find(p => p.Libro.Codigo == codigo);

    if (prestamo != null)
    {
        Console.Write("Nueva fecha devolución (dd/MM/yyyy): "); DateTime nuevaDev = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Nuevo estado: "); string nuevoEst = Console.ReadLine();

        prestamo.FechaDevolucion = nuevaDev; prestamo.Estado = nuevoEst;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "UPDATE Prestamos SET FechaDevolucion=@f, Estado=@e WHERE LibroCodigo=@cod";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@f", nuevaDev);
                cmd.Parameters.AddWithValue("@e", nuevoEst);
                cmd.Parameters.AddWithValue("@cod", codigo);
                conn.Open(); cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Préstamo actualizado correctamente.");
    }
    else { Console.WriteLine("Préstamo no encontrado."); }
    Console.ReadKey();
}

void EliminarPrestamo()
{
    Console.Clear();
    Console.Write("Código del libro: "); string codigo = Console.ReadLine();
    Prestamo prestamo = Database.Prestamos.Find(p => p.Libro.Codigo == codigo);

    if (prestamo != null)
    {
        Database.Prestamos.Remove(prestamo);
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Prestamos WHERE LibroCodigo=@cod";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@cod", codigo);
                conn.Open(); cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Préstamo eliminado correctamente.");
    }
}