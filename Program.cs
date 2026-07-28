using BibliotecaPOO_CEspinoza.Generales;
using BibliotecaPOO_CEspinoza.Models;
using System.Security.Cryptography;

Console.WriteLine("Hello Bienvenido a la Biblioteca mas ");
Archivo archivo = new Archivo();
CargarDatosPrueba();
JsonManager json = new JsonManager();
int opcion;

do
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue;

    Console.WriteLine("====================================================");
    Console.WriteLine("        SISTEMA DE GESTIÓN DE BIBLIOTECA");
    Console.WriteLine("====================================================");
    Console.WriteLine("1. Crear de Libros");
    Console.WriteLine("2. Crear de Autores");
    Console.WriteLine("3. Gestión de Préstamos");
    Console.WriteLine("4. Archivos");
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
        case 1:
            MenuLibros();
            break;

        case 2:
            MenuAutores();
            break;

        case 3:
            MenuPrestamos();
            break;

        case 4:
            MenuArchivos();
            break;

        case 5:
            Console.WriteLine("\nGracias por utilizar el sistema.");
            break;

        default:
            Console.WriteLine("\nOpción no válida.");
            Console.ReadKey();
            break;
    }

} while (opcion != 5);
void MenuLibros()
{
    Console.Clear();

    Console.WriteLine("========== CREAR DE LIBROS ==========");

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
        case 1:
            CrearLibro();
            break;

        case 2:
            ListarLibros();
            break;

        case 3:
            BuscarLibro();
            break;

        case 4:
            ActualizarLibro();
            break;

        case 5:
            EliminarLibro();
            break;
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
        case 1:
            CrearAutor();
            break;

        case 2:
            ListarAutores();
            break;

        case 3:
            BuscarAutor();
            break;

        case 4:
            ActualizarAutor();
            break;

        case 5:
            EliminarAutor();
            break;
    }
}
void CrearAutor()
{
    Console.Clear();

    Console.WriteLine("===== CREAR AUTOR =====");

    Console.Write("Cédula: ");
    string cedula = Console.ReadLine();

    Autor existe = Database.Autores.Find(a => a.Cedula == cedula);

    if (existe != null)
    {
        Console.WriteLine("Ya existe un autor con esa cédula.");
        Console.ReadKey();
        return;
    }

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Nacionalidad: ");
    string nacionalidad = Console.ReadLine();

    Console.Write("Edad: ");
    int edad = Convert.ToInt32(Console.ReadLine());

    Console.Write("Género: ");
    string genero = Console.ReadLine();

    Autor autor = new Autor(cedula, nombre, nacionalidad, edad, genero);

    Database.Autores.Add(autor);

    Console.WriteLine("\nAutor registrado correctamente.");
    Console.ReadKey();
}
void ListarAutores()
{
    Console.Clear();

    Console.WriteLine("===== LISTA DE AUTORES =====");

    if (Database.Autores.Count == 0)
    {
        Console.WriteLine("No existen autores registrados.");
    }
    else
    {
        foreach (Autor autor in Database.Autores)
        {
            autor.Imprimir();
            Console.WriteLine("--------------------------------");
        }
    }

    Console.ReadKey();
}
void BuscarAutor()
{
    Console.Clear();

    Console.Write("Ingrese la cédula: ");

    string cedula = Console.ReadLine();

    Autor autor = Database.Autores.Find(a => a.Cedula == cedula);

    if (autor != null)
    {
        autor.Imprimir();
    }
    else
    {
        Console.WriteLine("Autor no encontrado.");
    }

    Console.ReadKey();
}
void ActualizarAutor()
{
    Console.Clear();

    Console.Write("Ingrese la cédula: ");

    string cedula = Console.ReadLine();

    Autor autor = Database.Autores.Find(a => a.Cedula == cedula);

    if (autor != null)
    {
        Console.Write("Nuevo nombre: ");
        autor.Nombre = Console.ReadLine();

        Console.Write("Nueva nacionalidad: ");
        autor.Nacionalidad = Console.ReadLine();

        Console.Write("Nueva edad: ");
        autor.Edad = Convert.ToInt32(Console.ReadLine());

        Console.Write("Nuevo género: ");
        autor.Genero = Console.ReadLine();

        Console.WriteLine("Autor actualizado.");
    }
    else
    {
        Console.WriteLine("Autor no encontrado.");
    }

    Console.ReadKey();
}
void EliminarAutor()
{
    Console.Clear();

    Console.Write("Ingrese la cédula: ");

    string cedula = Console.ReadLine();

    Autor autor = Database.Autores.Find(a => a.Cedula == cedula);

    if (autor != null)
    {
        Database.Autores.Remove(autor);

        Console.WriteLine("Autor eliminado.");
    }
    else
    {
        Console.WriteLine("Autor no encontrado.");
    }

    Console.ReadKey();
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
        case 1:
            CrearPrestamo();
            break;

        case 2:
            ListarPrestamos();
            break;

        case 3:
            BuscarPrestamo();
            break;

        case 4:
            ActualizarPrestamo();
            break;

        case 5:
            EliminarPrestamo();
            break;
    }
}
void CrearPrestamo()
{
    Console.Clear();
    Console.WriteLine("===== CREAR PRÉSTAMO =====");

    if (Database.Libros.Count == 0)
    {
        Console.WriteLine("No existen libros registrados.");
        Console.ReadKey();
        return;
    }

    if (Database.Autores.Count == 0)
    {
        Console.WriteLine("No existen autores registrados.");
        Console.ReadKey();
        return;
    }

    Console.Write("Código del libro: ");
    string codigo = Console.ReadLine();

    Libro libro = Database.Libros.Find(l => l.Codigo == codigo);

    if (libro == null)
    {
        Console.WriteLine("Libro no encontrado.");
        Console.ReadKey();
        return;
    }

    Console.Write("Cédula del autor: ");
    string cedula = Console.ReadLine();

    Autor autor = Database.Autores.Find(a => a.Cedula == cedula);

    if (autor == null)
    {
        Console.WriteLine("Autor no encontrado.");
        Console.ReadKey();
        return;
    }

    Console.Write("Fecha préstamo (dd/MM/yyyy): ");
    DateTime fechaPrestamo = Convert.ToDateTime(Console.ReadLine());

    Console.Write("Fecha devolución (dd/MM/yyyy): ");
    DateTime fechaDevolucion = Convert.ToDateTime(Console.ReadLine());

    Console.Write("Estado: ");
    string estado = Console.ReadLine();

    Prestamo prestamo = new Prestamo(libro, autor, fechaPrestamo, fechaDevolucion, estado);

    Database.Prestamos.Add(prestamo);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nPréstamo registrado correctamente.");
    Console.ResetColor();

    Console.ReadKey();
}
void ListarPrestamos()
{
    Console.Clear();
    Console.WriteLine("===== LISTA DE PRÉSTAMOS =====");

    if (Database.Prestamos.Count == 0)
    {
        Console.WriteLine("No existen préstamos registrados.");
    }
    else
    {
        foreach (Prestamo prestamo in Database.Prestamos)
        {
            prestamo.Imprimir();
            Console.WriteLine("--------------------------------");
        }
    }

    Console.ReadKey();
}
void BuscarPrestamo()
{
    Console.Clear();

    Console.Write("Código del libro: ");

    string codigo = Console.ReadLine();

    Prestamo prestamo = Database.Prestamos.Find(p => p.Libro.Codigo == codigo);

    if (prestamo != null)
    {
        prestamo.Imprimir();
    }
    else
    {
        Console.WriteLine("Préstamo no encontrado.");
    }

    Console.ReadKey();
}

void ActualizarPrestamo()
{
    Console.Clear();

    Console.Write("Código del libro: ");

    string codigo = Console.ReadLine();

    Prestamo prestamo = Database.Prestamos.Find(p => p.Libro.Codigo == codigo);

    if (prestamo != null)
    {
        Console.Write("Nueva fecha devolución (dd/MM/yyyy): ");
        prestamo.FechaDevolucion = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Nuevo estado: ");
        prestamo.Estado = Console.ReadLine();

        Console.WriteLine("Préstamo actualizado correctamente.");
    }
    else
    {
        Console.WriteLine("Préstamo no encontrado.");
    }

    Console.ReadKey();
}
void EliminarPrestamo()
{
    Console.Clear();

    Console.Write("Código del libro: ");

    string codigo = Console.ReadLine();

    Prestamo prestamo = Database.Prestamos.Find(p => p.Libro.Codigo == codigo);

    if (prestamo != null)
    {
        Database.Prestamos.Remove(prestamo);

        Console.WriteLine("Préstamo eliminado correctamente.");
    }
    else
    {
        Console.WriteLine("Préstamo no encontrado.");
    }

    Console.ReadKey();
}
void MenuArchivos()
{
    Console.Clear();

    Console.WriteLine("========== ARCHIVOS ==========");

    Console.WriteLine("1. Guardar Libros ");
    Console.WriteLine("2. Leer Libros ");
    Console.WriteLine("3. Guardar Autores ");
    Console.WriteLine("4. Leer Autores ");
    Console.WriteLine("5. Guardar Préstamos ");
    Console.WriteLine("6. Leer Préstamos ");
    Console.WriteLine("7. Regresar");

    Console.Write("\nSeleccione una opción: ");

    int op = Convert.ToInt32(Console.ReadLine());

    switch (op)
    {
        case 1:
            archivo.GuardarLibros();
            break;

        case 2:
            archivo.LeerLibros();
            break;

        case 3:
            archivo.GuardarAutores();
            break;

        case 4:
            archivo.LeerAutores();
            break;

        case 5:
            archivo.GuardarPrestamos();
            break;

        case 6:
            archivo.LeerPrestamos();
            break;

        case 7:
            return;
    }

    Console.ReadKey();
}
void CrearLibro()
{
    Console.Clear();
    Console.WriteLine("===== CREAR LIBRO =====");

    Console.Write("Código: ");
    string codigo = Console.ReadLine();

    // Validar que no exista el código
    Libro existe = Database.Libros.Find(l => l.Codigo == codigo);

    if (existe != null)
    {
        Console.WriteLine("Ya existe un libro con ese código.");
        Console.ReadKey();
        return;
    }

    Console.Write("Título: ");
    string titulo = Console.ReadLine();

    Console.Write("Categoría: ");
    string categoria = Console.ReadLine();

    Console.Write("Año: ");
    int anio = Convert.ToInt32(Console.ReadLine());

    Console.Write("Editorial: ");
    string editorial = Console.ReadLine();

    Libro libro = new Libro(codigo, titulo, categoria, anio, editorial);

    Database.Libros.Add(libro);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nLibro registrado correctamente.");
    Console.ResetColor();

    Console.ReadKey();
}
void ListarLibros()
{
    Console.Clear();
    Console.WriteLine("===== LISTA DE LIBROS =====");

    if (Database.Libros.Count == 0)
    {
        Console.WriteLine("No existen libros registrados.");
    }
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

    if (libro != null)
    {
        libro.Imprimir();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Libro no encontrado.");
        Console.ResetColor();
    }

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
        Console.Write("Nuevo título: ");
        libro.Titulo = Console.ReadLine();

        Console.Write("Nueva categoría: ");
        libro.Categoria = Console.ReadLine();

        Console.Write("Nuevo año: ");
        libro.Anio = Convert.ToInt32(Console.ReadLine());

        Console.Write("Nueva editorial: ");
        libro.Editorial = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nLibro actualizado correctamente.");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Libro no encontrado.");
        Console.ResetColor();
    }

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
        string respuesta = Console.ReadLine();

        if (respuesta.ToUpper() == "S")
        {
            Database.Libros.Remove(libro);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Libro eliminado correctamente.");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Libro no encontrado.");
        Console.ResetColor();
    }

    Console.ReadKey();
}
void CargarDatosPrueba()
{
    if (Database.Libros.Count == 0)
    {
        Database.Libros.Add(new Libro("L001", "Cien años de soledad", "Novela", 1967, "Sudamericana"));
        Database.Libros.Add(new Libro("L002", "El Principito", "Infantil", 1943, "Reynal & Hitchcock"));
    }

    if (Database.Autores.Count == 0)
    {
        Database.Autores.Add(new Autor("0102030405", "Gabriel García Márquez", "Colombiano", 87, "Masculino"));
        Database.Autores.Add(new Autor("0911223344", "Antoine de Saint-Exupéry", "Francés", 44, "Masculino"));
    }
}