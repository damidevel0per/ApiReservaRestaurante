# APIRest C# .NET MySQL para reservas de mesas en restaurante

## Descripción

`ApiReservas` es una API RESTful desarrollada con ASP.NET Core que gestiona el sistema de reservas para un restaurante. Permite listar reservas, obtener reservas del día y crear nuevas reservas con confirmación por correo electrónico. Utiliza MySQL como base de datos para la persistencia de los datos.

## Características

* **Gestión de Reservas:**
    * Listar todas las reservas existentes.
    * Consultar reservas programadas para el día actual.
    * Crear nuevas reservas.
* **Confirmación por Correo Electrónico:** Envío automático de correos de confirmación a los clientes tras una reserva exitosa.
* **Base de Datos MySQL:** Persistencia de datos utilizando MySQL.
* **API RESTful:** Diseño basado en principios REST para una interacción clara y predecible.
* **Documentación Interactiva:** Integración con Swagger/OpenAPI para explorar y probar los endpoints fácilmente.

## Estructura del Proyecto

El proyecto sigue una arquitectura modular y limpia:# ApiReservaRestaurante
```
ApiReservas/
├── Controllers/              # Maneja las solicitudes HTTP y coordina la lógica de negocio.
│   └── ReservasController.cs
├── Data/                     # Lógica de acceso a datos (ej. MySqlDataAccess.cs).
│   └── MySqlDataAccess.cs
├── Models/                   # Clases que representan entidades de dominio y modelos de datos (Reserva.cs).
│   ├── DTOs/                 # Data Transfer Objects para entrada/salida de la API (ej. CrearReservaDTO.cs).
│   │   └── CrearReservaDTO.cs
│   └── Reserva.cs
├── Services/                 # Encapsula lógica de negocio y operaciones externas (ej. envío de emails).
│   └── ServicioEmail.cs      # (También IServicioEmail.cs como interfaz)
├── appsettings.json          # Configuración de la aplicación (cadenas de conexión, settings de email).
├── Program.cs                # Punto de entrada y configuración de la aplicación (Inyección de Dependencias).
└── ApiReservas.http          # Archivo para probar endpoints HTTP.
```
## Tecnologías Utilizadas

* **Backend:** ASP.NET Core (.NET 8.0).
* **Base de Datos:** MySQL.
* **Acceso a Datos:** `MySql.Data` (ADO.NET directo).
* **Envío de Correo:** `MailKit` y `MimeKit`.
* **Documentación API:** Swagger / OpenAPI.
