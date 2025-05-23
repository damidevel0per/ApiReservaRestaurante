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

## Tecnologías Utilizadas

* **Backend:** ASP.NET Core (.NET 8.0 o posterior, si no especificado).
* **Base de Datos:** MySQL.
* **ORM/Acceso a Datos:** `MySql.Data` (ADO.NET directo).
* **Envío de Correo:** `MailKit` y `MimeKit`.
* **Documentación API:** Swagger / OpenAPI.

## Estructura del Proyecto

El proyecto sigue una arquitectura modular y limpia:# ApiReservaRestaurante
