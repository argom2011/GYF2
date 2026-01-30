//Este modelo se encuentra dentro del **namespace `GYF.Models.Responses`** y su propósito es **agrupar la información que se
//devuelve al frontend** para la vista de Home Banking. Es parte del documento del examen técnico y refleja lo que el cliente verá
//al consultar su resumen.
//**Propiedades:**
//1. **`SaldoCuentaPrincipal`** (`decimal?`):
//   * Representa el saldo de la cuenta principal del cliente.
//   * Es `nullable` (`decimal?`) porque puede no existir una cuenta principal asociada, en cuyo caso quedará `null`.
//2. **`Movimientos`** (`List<MovimientoResumen>`):
//   * Es la lista de los **últimos movimientos** de la tarjeta principal asociada a la cuenta principal.
//   * Se inicializa como lista vacía (`= new()`) para evitar `null` y simplificar el manejo en el frontend.
//   * Cada elemento es un **`MovimientoResumen`**, que contiene la fecha, monto y descripción de un movimiento.
//**Notas importantes:**
//* Este modelo **no representa la base de datos**, sino la respuesta que se envía al cliente a través de la API.
//* Combina información de varias entidades del dominio:
//  * `Cuenta` → para obtener el saldo principal
//  * `Tarjeta` → para identificar la tarjeta principal
//  * `Movimiento` → para llenar la lista de `MovimientosResumen`
//* Se utiliza como **tipo de retorno del método `GetResumenCliente(int clienteId)`** en el repositorio y en el controlador.
//En resumen, **`ResumenCliente` es la vista simplificada y lista para mostrar del cliente**, que abstrae la complejidad de la base
//de datos y los modelos del dominio.

namespace GYF.Models.Responses
{
    public class ResumenCliente
    {
        public decimal? SaldoCuentaPrincipal { get; set; }
        public List<MovimientoResumen> Movimientos { get; set; } = new();
    }
}
