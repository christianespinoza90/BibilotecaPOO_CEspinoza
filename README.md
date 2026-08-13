 # BibliotecaPOO_CEspinoza

Se Creo una bibliteca digital para gestionar libros, autores y préstamos de libros y permite almacenar y recuperar datos mediante archivos JSON.

---

#  Objetivos

- Aplicar los conceptos de Programación Orientada a Objetos.
- Gestionar libros y autores.
- Registrar préstamos de libros.
- Validar la información ingresada por el usuario.
- Almacenar y recuperar datos mediante archivos JSON.

---

#  Estructura del proyecto

##  Clase Libros
Representa la información de cada libro de la biblioteca.

*Funciones principales*
- Crear libros.
- Consultar libros.
- Modificar libros.
- Eliminar libros.
- Validar la información.

---

##  Clase Autor
Administra la información de los autores.

*Funciones principales*
- Registrar autores.
- Editar autores.
- Eliminar autores.
- Consultar autores.

---

##  Clase Prestamo
Controla el préstamo de libros a los usuarios.

*Funciones principales*
- Registrar préstamos.
- Controlar disponibilidad.
- Registrar devoluciones.
- Validar préstamos.

---

## Clase Database
Administra las listas principales del sistema y el almacenamiento de la información.

---

##  Clase Archivo
Permite trabajar con archivos utilizados por el sistema.

---

##  Clase JsonManager
Realiza la serialización y deserialización de los datos utilizando formato JSON.

Se conecto a la base de datos correctamente y se implementaron las funciones necesarias para guardar y recuperar la información de los libros, autores y préstamos.
