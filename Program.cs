//Primero, `using GYF.Repository;` importa la clase `ClienteRepository`, que es la que contiene la lógica para acceder a la base de
//datos y traer el saldo y los movimientos de las cuentas y tarjetas. 
//Esto permite inyectarla directamente en los controladores sin tener que crear instancias manualmente.
//Luego, `var builder = WebApplication.CreateBuilder(args);` crea el “constructor” de la aplicación. Este objeto es como el tablero
//de control del backend: permite registrar servicios, 
//configurar middleware y definir cómo la aplicación manejará las solicitudes.
//`builder.Services.AddControllers();` le indica a ASP.NET Core que vamos a usar controladores para manejar peticiones HTTP tipo
//`/api/clientes/...`. Sin esto, las rutas de la API no funcionarían. 
//Por su parte, `builder.Services.AddScoped<ClienteRepository>();` registra el repositorio en el sistema de **inyección de
//dependencias**, de manera que cada solicitud HTTP reciba su propia instancia de 
//`ClienteRepository`. Esto simplifica mucho el manejo de datos en los controladores.
//La sección de CORS (`builder.Services.AddCors(...)`) permite que tu frontend, que corre en otro puerto (`localhost:5173`), pueda
//comunicarse con el backend sin que el navegador bloquee las solicitudes. 
//Se indica explícitamente que cualquier cabecera y método HTTP está permitido desde ese origen.
//Después de construir la aplicación con `var app = builder.Build();`, se configura el **pipeline de middleware**. Esto incluye
//manejar errores (`UseExceptionHandler`), servir archivos estáticos 
//(`UseStaticFiles`), habilitar rutas (`UseRouting`), activar CORS (`UseCors`) y autorización (`UseAuthorization`). Cada middleware
//es un paso que la solicitud recorre antes de llegar a un controlador.
//`app.MapControllers();` indica que todas las rutas definidas en los controladores deben mapearse y estar listas para responder a
//solicitudes HTTP. Finalmente, el bloque que redirige errores 404 a 
//`https://gyf.com.ar/` captura cualquier solicitud que no coincida con un endpoint de la API y la envía al sitio público, evitando
//que el usuario vea un mensaje de “página no encontrada” feo.
//En conjunto, todo esto configura el backend para que reciba peticiones de tu frontend React, consulte la base de datos mediante el
//repositorio, maneje errores y permita la comunicación segura entre //dominios.


using GYF.Repository;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllers();

// Inyección del repositorio
builder.Services.AddScoped<ClienteRepository>();

// 🔹 Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173") // URL de tu frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors(); // 🔹 Activar CORS
app.UseAuthorization();

app.MapControllers();

// 🔹 Middleware para redirigir 404 al sitio público
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
       context.Response.Redirect("https://gyf.com.ar/");
    }
});

app.Run();
