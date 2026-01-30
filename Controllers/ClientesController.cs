using Microsoft.AspNetCore.Mvc;
using GYF.Repository;
using GYF.Models.Responses;
//El `ClientesController` es un controlador de API asincrónico que expone un endpoint para obtener el resumen de un cliente dado su
//`clienteId`. La asincronía se logra usando `async/await` en el método `GetResumenCliente`, que retorna un `Task<IActionResult>`.
//Dentro del método, se llama al repository (`ClienteRepository`) mediante `await _repository.GetResumenCliente(clienteId)`, lo que
//permite que la operación de consulta a la base de datos se ejecute de forma **no bloqueante**, liberando el hilo para atender
//otras solicitudes mientras se espera la respuesta. De esta manera, el controlador combina la arquitectura de MVC con llamadas
//asincrónicas a la capa de datos, mejorando el rendimiento y la escalabilidad de la API al manejar múltiples solicitudes
//concurrentes sin bloquear recursos del servidor.


namespace GYF.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClientesController : ControllerBase
{
    private readonly ClienteRepository _repository;

    public ClientesController(ClienteRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{clienteId}/resumen")]
    public async Task<IActionResult> GetResumenCliente(int clienteId)
    {
        var result = await _repository.GetResumenCliente(clienteId);
        return Ok(result);
    }
}
