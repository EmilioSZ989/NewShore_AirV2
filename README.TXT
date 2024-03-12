***ACLARACIÓN: SE REALIZO ASÍ EL PROYECTO PORQUE LA API A CONSUMIR NO FUNCIONABA, POR TANTO SE ME DIO LA OPCION DE CONSUMIR MI PROPIA API***.

# Documentación del Proyecto: Solución de Conexión de Viajes para NEWSHORE AIR

## Descripción del Proyecto
  La solución de conexión de viajes para NEWSHORE AIR es una aplicación web que facilita a los usuarios encontrar rutas de vuelo entre un origen y un destino específicos. Esta aplicación consta de un backend desarrollado en .NET con Spring Boot, que proporciona una API REST para la consulta de vuelos, y un frontend desarrollado en Angular que permite a los usuarios realizar búsquedas de rutas de vuelo de manera intuitiva y eficiente.

## Tecnologías Utilizadas
  -Backend:
    .NET Framework
    Entity Framework Core
    C#
    SQLite para la base de datos
  -Frontend:
    Angular CLI v17.2.2
    Node.js v20.11.1
    npm v10.4.0

## Instrucciones de Instalación y Uso
  Clona el repositorio desde [GitHub] (https://github.com/EmilioSZ989/NewShore_AirV2.git).
  Abre el proyecto Backend en Visual Studio.
  Abre el proyecto Frontend en Visual Studio Code.
  Instalar las dependencias necesarias.
  Ejecuta el backend. El servicio estará disponible en https://localhost:7068.
  Ejecuta el frontend. La interfaz estará disponible en http://localhost:4200.

## Ejemplos de Uso
-Búsqueda de Ruta Directa
  Para buscar una ruta de vuelo directa, ingresa el origen y el destino en los campos correspondientes y haz clic en el botón de búsqueda. Por ejemplo:

  Origen: "BCN"
  Destino: "LAX"

-Búsqueda de Ruta Indirecta
  Para buscar una ruta de vuelo indirecta, ingresa el origen y el destino en los campos correspondientes y haz clic en el botón de búsqueda. Por ejemplo:

  Origen: "MZL"
  Destino: "SYD"

Estos ejemplos muestran cómo puedes buscar rutas de vuelo directas e indirectas utilizando la aplicación, si deseas hacer tus propios ejemplos, te recomiendo consultar en la API los Flights almacenados en la DB.

## Autor
  Julián Emilio Suaza Pérez