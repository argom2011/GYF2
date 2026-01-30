
//El archivo `ClienteRepository` es parte de la **capa de acceso a datos** del backend y fue desarrollado específicamente en el
//proyecto para centralizar la lógica de consulta de clientes. Su propósito es conectarse a la base de datos SQL Server y devolver
//un **resumen del cliente**, que incluye el saldo de su cuenta principal y los últimos movimientos de su tarjeta principal. Esta
//clase sigue el patrón **Repository**, lo que permite separar la lógica de acceso a datos de los controladores y de la API,
//facilitando el mantenimiento y la reutilización.
//Dentro del repository, se establece la **conexión a la base de datos** utilizando la cadena de conexión definida en
//`appsettings.json`. Para obtener la información, se utiliza Dapper y se ejecuta el **stored procedure `sp_GetResumenCliente`**,
//pasando como parámetro el `ClienteId`. Este procedimiento retorna múltiples resultados: primero el saldo de la cuenta principal y
//luego los últimos cinco movimientos de la tarjeta principal asociada. El repository se encarga de mapear estos resultados a un
//objeto `ResumenCliente`, combinando el saldo y la lista de movimientos en un solo objeto listo para la API.
//Finalmente, el repository maneja posibles errores de SQL Server mediante un bloque `try-catch`, lanzando una excepción de
//aplicación en caso de fallo. Esto permite que el controlador que invoca el repository pueda capturar errores y devolver un
//mensaje adecuado al frontend. De esta manera, todo el acceso a la base de datos y la transformación de datos se concentra en el
//**repository**, cumpliendo con buenas prácticas de arquitectura y manteniendo la lógica del backend organizada y desacoplada de
//la capa de presentación.

using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using GYF.Models.Responses;
namespace GYF.Repository;
public class ClienteRepository
{
    private readonly string _connectionString;

    public ClienteRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<ResumenCliente> GetResumenCliente(int clienteId)
    {
        using var connection = new SqlConnection(_connectionString);

        try
        {
            using var multi = await connection.QueryMultipleAsync(
                "sp_GetResumenCliente",
                new { ClienteId = clienteId },
                commandType: CommandType.StoredProcedure
            );

            var resumen = new ResumenCliente();

            resumen.SaldoCuentaPrincipal =
                await multi.ReadFirstOrDefaultAsync<decimal?>();

            var movimientos =
                (await multi.ReadAsync<MovimientoResumen>()).ToList();

            resumen.Movimientos = movimientos;

            return resumen;
        }
        catch (SqlException ex)
        {
            // log técnico
            throw new ApplicationException(
                "Error al consultar el resumen del cliente.", ex);
        }
    }
}

