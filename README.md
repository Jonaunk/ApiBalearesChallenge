# ApiBalearesChallenge

## Documentación de la API

### Descripción de la Solución
Esta solución es una API RESTful desarrollada con **ASP.NET Core**. La API permite gestionar contactos y usuarios, incluyendo operaciones de creación, obtención, actualización y eliminación.

## Ejecución de la API

1. Clona el repositorio a tu máquina local:
   ```bash
   https://github.com/Jonaunk/ApiBalearesChallenge.git
2. Abrir con Visual Studio

3. Obtener el nombre de la BD local
   
   ![image](https://github.com/user-attachments/assets/19d21d98-a71a-4c49-a3cf-86b0b93b2770)

4. Migracion y actualizacion de Identity
- Debemos generar las tablas de la BD a partir del modelo y de las Migrations del proyecto Identity y Persistence.
  Para esto ingresamos en la consola de administracion de Nugget

  ![image](https://github.com/user-attachments/assets/d5ff6a95-35e6-4c05-bbaa-eeef65ce3170)

- Dentro de la consola, seleccionamos el proyecto Identity y ejecutamos el siguiente comando:

  Comando para Visual Studio
  ```
  Update-database -Context IdentityContext
  ```
  Comando para Visual Studio Code (VsCode)
  ```
  dotnet ef database-update --Context IdentityContext
  ```

  ![image](https://github.com/user-attachments/assets/02d53746-1625-48bd-9bbd-75dd2d51734b)

5. Migracion y actualizacion de Persistence
- Ahora seleccionamos el proyecto de Persistence y ejecutamos el siguiente comando:

  Comando para Visual Studio
  ```
  Update-database -Context ApplicationDbContext
  ```
  Comando para Visual Studio Code (VsCode)
  ```
  dotnet ef database-update --Context ApplicationDbContext
  ```

  ![image](https://github.com/user-attachments/assets/84ecce5f-2ce7-42ab-9d16-0d22738f61e7)

  ## Ejecucion API

- Luego solo resta Configurar el proyecto WebApi como proyecto de inicio y ejecutarlo.
- El proyecto tiene configurado SEEDS, que crean datos iniciales para las clases Ciudad y Provincia en el modelo de Persistence.

### Configuración de la base de datos

- Se adjunta script de la base de datos, a modo de cumplir con el challenge, ya que con las migraciones y seeds no es sumamente necesario
  
- Ejecuta el script `BalearesDb.sql` en tu servidor de SQL Server para crear la base de datos y poblarla con los datos iniciales.


## Documentacion endpoints UsuariosController
### Endpoint: Registrar Usuario

**URL:** `/api/v1/usuarios/register`

**Método:** `POST`

**Descripción:** Registra un nuevo usuario en el sistema. Recibe los datos necesarios para crear un usuario, incluyendo nombre, apellido, email, contraseña y nombre de usuario.

#### Request Body
El endpoint recibe un objeto `RegisterRequest` en el cuerpo de la solicitud:

| Parámetro      | Tipo   | Descripción                                     | Ejemplo                        |
|----------------|--------|-------------------------------------------------|--------------------------------|
| `Nombre`       | `string` | El nombre del usuario.                          | `"Max"`                       |
| `Apellido`     | `string` | El apellido del usuario.                        | `"Verstappen"`                      |
| `Email`        | `string` | El email del usuario.                           | `"mverstappen@gmail.com"`     |
| `UserName`     | `string` | Nombre de usuario único.                        | `"maxv"`                    |
| `Password`     | `string` | La contraseña del usuario.                      | `"Max1234!"`                |
| `ConfirmPassword` | `string` | Confirmación de la contraseña.                | `"Max1234!"`                |

```json
{
  "nombre": "Max",
  "apellido": "Verstappen",
  "email": "mverstappen@gmail.com",
  "userName": "maxv",
  "password": "Max1234!",
  "confirmPassword": "Max1234!"
}
```

#### Response
**Código de estado:** `200 OK`

**Cuerpo de la respuesta:**
```json
{
  "succeded": true,
  "message": "Usuario Pepe registrado correctamente.",
  "data": "935568f5-4b66-4a8a-96cc-23f51402cb6f",
  "errors": null
}
```
### Endpoint: Autenticar Usuario

**URL:** `/api/v1/usuarios/authenticate`

**Método:** `POST`

**Descripción:** Autentica a un usuario en el sistema y genera un token JWT para la sesión. Utiliza el email y la contraseña para autenticar al usuario y devolver un token de acceso.

#### Request Body
El endpoint recibe un objeto `AuthenticationRequest` en el cuerpo de la solicitud:

| Parámetro    | Tipo   | Descripción                                    | Ejemplo                       |
|--------------|--------|------------------------------------------------|-------------------------------|
| `Email`      | `string` | El email del usuario.                          | `"mverstappen@gmail.com"`     |
| `Password`   | `string` | La contraseña del usuario.                     | `"Max1234!"`               |
```json
{
  "email": "mverstappen@gmail.com",
  "password": "Max1234!"
}
```
### Response
**Código de estado:** `200 OK`

**Cuerpo de la respuesta:**
```json
{
  "succeded": true,
  "message": "Usuario Max autenticado",
  "data": {
    "id": "72cac620-2e57-4db1-98fe-808de0bb083e",
    "userName": "maxv",
    "nombre": "Max",
    "apellido": "Verstappen",
    "email": "mverstappen@gmail.com",
    "roles": [],
    "isVerified": true,
    "jwToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJwZXBpdG8iLCJqdGkiOiJlNGU4ZmMyNy0yMTBkLTQyODEtYmNlMS00NDI0NGQxMWZlMzUiLCJlbWFpbCI6InBlcGl0b0BnbWFpbC5jb20iLCJ1aWQiOiI3MmNhYzYyMC0yZTU3LTRkYjEtOThmZS04MDhkZTBiYjA4M2UiLCJleHAiOjE3MzM3MDY3MTEsImlzcyI6IkFwaUlzc3VlciIsImF1ZCI6IkFwaUF1ZGllbmNlIn0.IWQWz11znORyQx4Ab_6YrPaM5dYXCPEmQxKl37tbbPI"
  },
  "errors": null
}
```

### Endpoint: Obtener Usuarios Ordenados

**URL:** `/api/v1/usuarios/usuarios-ordenados`

**Método:** `GET`

**Descripción:** Obtiene una lista de usuarios ordenada por correo electrónico. Este endpoint requiere que el usuario esté autenticado.

#### Response
**Código de estado:** `200 OK`

**Cuerpo de la respuesta:**
```json
{
  {
    "succeded": true,
    "message": null,
    "data": [
        {
            "id": "43b263a2-e34a-4cd4-be65-eef92c65e607",
            "userName": "maxv",
            "nombre": "Max",
            "apellido": "Verstappen",
            "email": "mverstappen@gmail.com"
        },
        {
            "id": "72cac620-2e57-4db1-98fe-808de0bb083e",
            "userName": "fcolapinto",
            "nombre": "Franco",
            "apellido": "Colapinto",
            "email": "fcolapinto@gmail.com"
        }
    ],
    "errors": null
}
}
```

## Documentacion endpoints ContactosController

### Endpoint: Crear Contacto

**URL:** `/api/v1/contactos`

**Método:** `POST`

**Descripción:** Crea un nuevo contacto en la base de datos. Este endpoint recibe los datos del contacto y devuelve una respuesta con el resultado de la operación.

#### Request Body
El cuerpo de la solicitud debe contener un objeto JSON con los siguientes campos:

```json
{
  "nombre": "Franco",
  "apellido": "Colapinto",
  "empresa": "Williams",
  "email": "fcolapinto@gmail.com",
  "fechaNacimiento": "2003-09-30",
  "telefono": "1122334455",
  "direccion": "San Martin 1123",
  "ciudadId": 4,
  "provinciaId": 1
}
```

#### Response
**Código de estado:** `200 OK`

**Cuerpo de la respuesta:**
```json
{
  "succeded": true,
  "message": "Se ha creado el contacto con Id: 7",
  "data": null,
  "errors": null
}
```



### Endpoint Obtener Contactos

**URL:** `/api/v1/contactos`

**Método:** `GET`

**Descripción:** Devuelve una lista de contactos que cumplen con los filtros de búsqueda y paginación especificados. Permite filtrar por los campos de `Id`, `Nombre`, `Email`, `Telefono`, `CiudadId`, y `ProvinciaId`. También se puede ordenar la lista de contactos por correo electrónico. Los parámetros son pasados por query.

#### Parámetros por query
El endpoint recibe los siguientes parámetros:

| Parámetro          | Tipo     | Descripción                                     | Ejemplo             |
|--------------------|----------|-------------------------------------------------|---------------------|
| `PageNumber`       | `int?`    | Número de la página para paginación (opcional). | `1`                 |
| `PageSize`         | `int?`    | Número de elementos por página (opcional).      | `10`                |
| `Id`               | `int?`   | ID del contacto (opcional).                     | `5`                 |
| `Nombre`           | `string` | Nombre del contacto (opcional).                 | `"Franco"`          |
| `Email`            | `string` | Email del contacto (opcional).                  | `"email@example.com"`|
| `Telefono`         | `string` | Teléfono del contacto (opcional).               | `"1122334455"`      |
| `CiudadId`         | `int?`   | ID de la ciudad (opcional).                     | `4`                 |
| `ProvinciaId`      | `int?`   | ID de la provincia (opcional).                  | `1`                 |
| `OrdenarPorMail`   | `bool?`   | Indica si se debe ordenar la lista por email (opcional).  | `true`              |

#### Response
**Código de estado:** `200 OK`

**Cuerpo de la respuesta:**
```json
{
  "pageNumber": 1,
  "pageSize": 10,
  "totalRecords": 5,
  "succeded": true,
  "message": null,
  "data": [
    {
      "nombre": "Franco",
      "apellido": "Colapinto",
      "empresa": "Williams",
      "email": "fcolapinto@gmail.com",
      "fechaNacimiento": "2003-09-30T00:00:00",
      "telefono": "1122334455",
      "direccion": "Baleares 123",
      "ciudad": {
        "id": 3,
        "nombre": "Mar del Plata"
      },
      "provincia": {
        "id": 1,
        "nombre": "Buenos Aires"
      },
      "imagenPerfil": null
    },
    {
      "nombre": "Franco",
      "apellido": "Colapinto",
      "empresa": "Williams",
      "email": "fcolapinto@gmail.com",
      "fechaNacimiento": "2003-09-30T00:00:00",
      "telefono": "1122334455",
      "direccion": "San Martin 1123",
      "ciudad": {
        "id": 4,
        "nombre": "San Fernando"
      },
      "provincia": {
        "id": 1,
        "nombre": "Buenos Aires"
      },
      "imagenPerfil": null
    }
  ],
  "errors": null
}
```


### Endpoint: Eliminar Contacto

**URL:** `/api/v1/contactos`

**Método:** `DELETE`

**Descripción:** Elimina un contacto de forma lógica usando su `Id`. 

#### Request Body
El cuerpo de la solicitud debe contener un objeto JSON con los siguientes campos:

| Parámetro | Tipo   | Descripción                        | Ejemplo |
|-----------|--------|------------------------------------|---------|
| `Id`      | `int`  | ID del contacto a eliminar.        | `5`     |

```json
{
  "id": 5
}
```

#### Response
**Código de estado:** `200 OK`

**Cuerpo de la respuesta:**
```json
{
  "succeded": true,
  "message": "Eliminado exitosamente",
  "data": null,
  "errors": null
}
```

### Endpoint: Actualizar Contacto

**URL:** `/api/v1/contactos`

**Método:** `PUT`

**Descripción:** Permite actualizar la información de un contacto existente. El contacto se identifica por su `Id`, y se reciben los nuevos valores para sus atributos.

#### Request Body
El cuerpo de la solicitud debe contener un objeto JSON con los siguientes campos:

| Parámetro         | Tipo    | Descripción                              | Ejemplo                  |
|-------------------|---------|------------------------------------------|--------------------------|
| `Id`              | `int`   | ID del contacto a actualizar.            | `1`                      |
| `Nombre`          | `string`| Nombre del contacto.                     | `"Franco"`               |
| `Apellido`        | `string`| Apellido del contacto.                   | `"Colapinto"`            |
| `Empresa`         | `string`| Empresa del contacto.                    | `"Williams"`             |
| `Email`           | `string`| Email del contacto.                      | `"fcolapinto@gmail.com"` |
| `FechaNacimiento` | `DateTime`| Fecha de nacimiento del contacto.     | `"2003-09-30"`           |
| `Telefono`        | `string`| Teléfono del contacto.                   | `"1122334455"`           |
| `Direccion`       | `string`| Dirección del contacto.                  | `"San Martin 1123"`      |
| `CiudadId`        | `int`   | ID de la ciudad del contacto.            | `4`                      |
| `ProvinciaId`     | `int`   | ID de la provincia del contacto.         | `1`                      |
```json
{
  "id": 1,
  "nombre": "Max",
  "apellido": "Verstappen",
  "empresa": "Red Bull",
  "email": "mverstappen@gmail.com",
  "fechaNacimiento": "1997-09-30",
  "telefono": "1122334455",
  "direccion": "San Martin 432",
  "ciudadId": 4,
  "provinciaId": 1
}
```
#### Response
**Código de estado:** `200 OK`

**Cuerpo de la respuesta:**
```json
{
  "succeded": true,
  "message": "Contacto con Id = 1 actualizado correctamente.",
  "data": null,
  "errors": null
}
```

### Endpoint: Agregar Imagen a Contacto

**URL:** `/api/v1/contactos/Imagen`

**Método:** `PUT`

**Descripción:** Permite agregar una imagen a un contacto específico identificado por su `Id`. Se recibe un comando que incluye el `Id` del contacto y la imagen a agregar.

#### Parámetros por query
El endpoint recibe el Id del Contact y una imagen:

| Parámetro | Tipo        | Descripción                              | Ejemplo                        |
|-----------|-------------|------------------------------------------|--------------------------------|
| `Id`      | `int`       | ID del contacto al que se le va a agregar la imagen. | `1`                          |
| `Imagen`  | `byte[]`    | Imagen en formato de array de bytes.     | `imagen.jpg`  |

#### Response
**Código de estado:** `200 OK`

**Cuerpo de la respuesta:**
```json
{
  "succeded": true,
  "message": "Imagen agregada correctamente.",
  "data": null,
  "errors": null
}
```
## Tecnologías y Patrones Utilizados (entre otros).
1. ASP.NET Core
- Framework: Se utiliza ASP.NET Core 8.0 para construir la API RESTful.
2. Clean Architecture
- Patrón de Diseño: La solución sigue el patrón de Clean Architecture, que promueve la separación de preocupaciones y la organización del código en capas independientes para facilitar el mantenimiento y escalabilidad de la aplicación.
  Capas Principales:

  API (Presentación): Contiene los controladores que gestionan las solicitudes HTTP.

  Application (Aplicación): Maneja la lógica de negocio y las interacciones entre las distintas capas.

  Domain (Dominio): Define los modelos y las entidades de negocio.

  Infrastructure (Infraestructura): Implementa la interacción con servicios externos, como la base de datos y los servicios de almacenamiento.

3. MediatR
- Librería de Mediator: Se utiliza MediatR para implementar el patrón Mediator, lo que permite una comunicación desacoplada entre los controladores y la lógica de negocio. Esto mejora la organización y escalabilidad del código.
4. Swagger/OpenAPI
- Documentación de la API: Se utiliza Swagger para generar la documentación de los endpoints de la API.
5. AutoMapper
- Mapeo de Objetos: Se usa AutoMapper para mapear de manera automática entre objetos de modelo y DTOs, lo que simplifica la conversión de datos entre capas.
6. JWT 
- Autenticación y Autorización: Se implementa la autenticación y autorización basada en JWT para proteger los endpoints y garantizar que solo los usuarios autenticados puedan acceder a ciertos recursos.
7. Entity Framework Core (EF Core)
- ORM (Mapeo Objeto-Relacional): EF Core se utiliza como el ORM para interactuar con la base de datos de manera eficiente y manejar operaciones CRUD.
8. FluentValidation
- Validación de Datos: Se utiliza FluentValidation para la validación de datos de entrada, lo que mejora la legibilidad y gestión de las reglas de validación.
9. Middleware Personalizado
- Manejo de Excepciones y Errores: Se incluye middleware personalizado para capturar y manejar errores.
- Middleware de Autenticación y Autorización: Se incluye middleware middleware de autenticación para validar y gestionar tokens JWT.

  ## Desafíos encontrados durante el desarrollo

   Durante el desarrollo de este challenge creo que uno de los desafios mas importantes fue el tiempo para desarrollarlo, no tuve tanta disponibilidad como hubiese querido, aunque eso no impidió completar lo que creo que en lineas generales fue una buena tarea. Aunque hubo algunas cuestiones que tal vez podría haber manejado de una manera distinta. 
  
  Además, otro desafio importante fue el tener que completar la documentación para que se entienda de la forma mas clara y consisa posible, abarcando desde el como crear la base de datos a partir de las migraciones, pasando por la forma de ejecutarla y completando con el request y response de cada endpoint.
  
   En definitiva, más allá de lo comentado creo que es un challenge mas que interesante, la elección de hacerlo con Clean Architecture fue porque considero que asegura la separación clara entre capas y la escalabilidad, aunque también tengo que mencionar que es una  arquitectura que me gusta y se me hace mas divertido el desarrollo.
  

