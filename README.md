# ProgramacionAvanzadaG2

# Descripción General

Math Puzzle es una aplicación web desarrollada en ASP.NET MVC que permite a los usuarios resolver desafíos matemáticos interactivos. El objetivo principal del sistema es poner a prueba las habilidades de razonamiento lógico y matemático mediante una serie de ejercicios y problemas diseñados para diferentes niveles de dificultad.

La aplicación implementa una arquitectura por capas para garantizar una adecuada separación de responsabilidades, facilitando el mantenimiento, escalabilidad y evolución del sistema.

---

# Objetivos del Proyecto

* Desarrollar una aplicación web interactiva basada en desafíos matemáticos.
* Aplicar los conceptos de Programación Avanzada utilizando ASP.NET MVC.
* Implementar una arquitectura por capas.
* Gestionar información de manera estructurada y mantenible.
* Utilizar GitHub para el control de versiones y trabajo colaborativo.

---

# Tecnologías Utilizadas

| Tecnología         | Descripción                                      |
| ------------------ | ------------------------------------------------ |
| C#                 | Lenguaje principal de desarrollo                 |
| ASP.NET MVC        | Framework para el desarrollo de aplicaciones web |
| Entity Framework   | ORM para acceso a datos                          |
| SQL Server         | Sistema gestor de base de datos                  |
| Visual Studio 2022 | Entorno de desarrollo                            |
| Git                | Control de versiones                             |
| GitHub             | Gestión y almacenamiento del repositorio         |

---

# Arquitectura del Sistema

El sistema está desarrollado siguiendo una arquitectura por capas que permite una clara separación de responsabilidades.

### Diagrama de Arquitectura

```text
┌──────────────────────────┐
│         AP.MVC           │
│  Presentación / UI       │
│  Controllers y Views     │
└─────────────┬────────────┘
              │
              ▼
┌──────────────────────────┐
│         AP.Core          │
│   Lógica de Negocio      │
│   Validaciones           │
│   Procesamiento          │
└─────────────┬────────────┘
              │
              ▼
┌──────────────────────────┐
│         AP.Data          │
│    Acceso a Datos        │
│    Repositorios y CRUD   │
└─────────────┬────────────┘
              │
              ▼
┌──────────────────────────┐
│        AP.Models         │
│   Entidades del Sistema  │
│   Modelos de Datos       │
└─────────────┬────────────┘
              │
              ▼
┌──────────────────────────┐
│       SQL Server         │
│      Base de Datos       │
└──────────────────────────┘
```

# Descripción de las Capas

## AP.MVC

Corresponde a la capa de presentación del sistema.

Responsabilidades:

* Gestionar la interacción con los usuarios.
* Procesar solicitudes HTTP.
* Mostrar información mediante vistas.
* Coordinar la comunicación con la capa de negocio.

Componentes principales:

* Controllers
* Views
* Content
* Scripts
* Configuración Web

---

## AP.Core

Contiene la lógica de negocio de la aplicación.

Responsabilidades:

* Aplicar reglas de negocio.
* Validar información.
* Procesar operaciones solicitadas por los usuarios.
* Coordinar la comunicación entre la presentación y el acceso a datos.

Beneficios:

* Centraliza la lógica del sistema.
* Facilita el mantenimiento y las pruebas.

---

## AP.Data

Capa responsable de la persistencia de datos.

Responsabilidades:

* Realizar operaciones CRUD.
* Ejecutar consultas a la base de datos.
* Gestionar la conexión con SQL Server.
* Implementar repositorios y acceso a datos mediante Entity Framework.

---

## AP.Models

Contiene las entidades y modelos utilizados por todo el sistema.

Responsabilidades:

* Representar la estructura de los datos.
* Compartir entidades entre las diferentes capas.
* Mantener la consistencia de la información.

---

## Estructura del Proyecto

```text
AP
│
├── AP.MVC
│   ├── Controllers
│   ├── Views
│   ├── Content
│   ├── Scripts
│   └── Configuración Web
│
├── AP.Core
│   └── Lógica de Negocio
│
├── AP.Data
│   └── Acceso a Datos
│
├── AP.Models
│   └── Entidades y Modelos
│
└── AP.sln
```


---

# Instalación y Configuración

## Requisitos Previos

Antes de ejecutar el proyecto es necesario contar con:

* Visual Studio 2022 o superior.
* SQL Server.
* .NET Framework requerido por la solución.
* Git instalado.

---

## Clonar el Repositorio


git clone https://github.com/USUARIO/ProgramacionAvanzadaG2.git


---

## Configuración

1. Abrir la solución `AP.sln` en Visual Studio.
2. Restaurar automáticamente los paquetes NuGet.
4. Crear o restaurar la base de datos en SQL Server.
5. Verificar que la base de datos esté accesible.

---

## Ejecución

1. Establecer `AP.MVC` como proyecto de inicio.
2. Compilar la solución.
3. Ejecutar la aplicación mediante IIS Express o IIS local.
4. Acceder al sistema desde el navegador.

---

# Buenas Prácticas Implementadas

* Arquitectura por capas.
* Separación de responsabilidades.
* Reutilización de código.
* Control de versiones mediante Git.


---

# Equipo de Desarrollo

Proyecto desarrollado como parte del curso de Programación Avanzada.

Integrantes:

* Alessandra Kessler Valdivia
* Sergio Mata Lopez
* Manuel Chacón Reyes
* Gabriel Tapia Calvo

