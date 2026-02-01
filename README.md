### 📘 Documentación del Proyecto

El presente proyecto corresponde a la resolución de un examen técnico, cuyo objetivo fue desarrollar una solución completa que integre backend y frontend para la visualización del resumen de un cliente dentro de un sistema de tarjetas de crédito.

La solución incluye documentación técnica y funcional, la cual se encuentra organizada dentro de la carpeta **Documentación** del proyecto, junto con los scripts SQL necesarios para la creación de la base de datos, tablas y stored procedures en **SQL Server Express 2019**.

El backend fue desarrollado en **.NET 8**, exponiendo una **API REST** que permite obtener el saldo de la cuenta principal del cliente y los últimos movimientos de la tarjeta principal, respetando la lógica de negocio definida en el enunciado.

El frontend fue desarrollado en **React + TypeScript** y se encuentra ubicado dentro de la carpeta **ClientApp**, desde donde se consume la API para mostrar al usuario la información del resumen de cuenta en una interfaz simple de Home Banking.

Asimismo, el proyecto incluye el **diagrama UML**, el cual representa las entidades del dominio, sus relaciones y los objetos de transferencia utilizados entre capas, permitiendo una comprensión clara de la arquitectura general de la solución.

---

### **Nota importante sobre configuración y ejecución**

* Al compilar y ejecutar el frontend en **React** desde un IDE o desde la consola, es necesario **verificar la URL generada localmente** (por ejemplo `http://localhost:5173`) y **adaptarla en la configuración de CORS del backend**, específicamente en el archivo `Program.cs`:

```csharp
options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("http://localhost:5173")
          .AllowAnyHeader()
          .AllowAnyMethod();
});
```

* De igual manera, en el frontend, dentro del archivo `clienteApi.ts`, se debe **ajustar la URL de consumo de la API** según el puerto generado en la ejecución del backend desde **Visual Studio 2022 (.NET)**.
  Ejemplo actual:

```ts
const response = await fetch(`http://localhost:5106/api/clientes/${clienteId}/resumen`);
```

Este valor debe ser reemplazado por el correspondiente al entorno local de ejecución del backend.

* Finalmente, se debe **actualizar la cadena de conexión** definida en el archivo `appsettings.json`, reemplazando el valor de ejemplo por el correspondiente al servidor de **SQL Server** local del evaluador:

```json
"DefaultConnection": "Server=ARGOM\\SQLEXPRESS;Database=GYF;Trusted_Connection=True;TrustServerCertificate=True;"


