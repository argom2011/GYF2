//Este modelo está dentro del **namespace `GYF.Models.Domain`** y representa **cada transacción realizada con una tarjeta** en el
//sistema de tarjetas de crédito. En el examen técnico, este modelo vino como parte de la lógica de **resumen de cuentas y
//movimientos**.
//Las propiedades son:
//1. **`Id`** (`int`): identificador único del movimiento. Cada transacción tiene un `Id` distinto para poder diferenciarla en la
//base de datos.
//2. **`TarjetaId`** (`int`): indica a qué **tarjeta** pertenece este movimiento. Es la **clave foránea** que lo relaciona con la
//entidad `Tarjeta`.
//3. **`Fecha`** (`DateTime`): la fecha en la que se realizó la transacción. Esto permite ordenar los movimientos y mostrar los
//últimos cinco en el home banking.
//4. **`Monto`** (`decimal`): la cantidad de dinero involucrada en el movimiento. Puede ser positiva (depósitos) o negativa
//(pagos o compras).
//5. **`Descripcion`** (`string`): un texto explicativo del movimiento, como "Pago de tarjeta", "Depósito", "Compra supermercado",
//etc.
//En resumen: **`Movimiento` es la unidad más fina de información financiera en este sistema**, vinculada a una tarjeta, que a su vez
//pertenece a una cuenta. Esto permite construir el **resumen del cliente** mostrando saldo y los últimos movimientos de manera
//precisa.

namespace GYF.Models.Domain
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int TarjetaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
    }
}
