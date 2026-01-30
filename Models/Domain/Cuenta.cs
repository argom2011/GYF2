//Este modelo **`Cuenta`** también está en el **namespace `GYF.Models.Domain`**, lo que indica que es un objeto central del negocio.
//Representa una **cuenta bancaria de un cliente** dentro del sistema de tarjetas de crédito.
//La clase `Cuenta` tiene estas propiedades:
//1. **`Id`** (`int`): identificador único de la cuenta. Cada cuenta tiene un `Id` distinto en la base de datos.
//2. **`ClienteId`** (`int`): indica a qué cliente pertenece esta cuenta. Es la **clave foránea** que la relaciona con la entidad
//`Cliente`.
//3. **`Saldo`** (`decimal`): representa el saldo actual de la cuenta. Es lo que se muestra en el home banking como el dinero
//disponible del cliente.
//4. **`EsCuentaPrincipal`** (`bool`): indica si esta cuenta es la principal del cliente. La lógica del sistema asume que cada
//cliente puede tener **una sola cuenta principal**, que se usará como referencia para mostrar el saldo inicial y los movimientos principales.
//En resumen: **`Cuenta` es la extensión de `Cliente`**, que permite almacenar varias cuentas por cliente, pero destaca una como la
//principal. Este modelo vino incluido en el documento del examen técnico y es **clave para filtrar saldo y movimientos** en el resumen del home banking.

namespace GYF.Models.Domain
{
    public class Cuenta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public decimal Saldo { get; set; }
        public bool EsCuentaPrincipal { get; set; }
    }
}
