//Este modelo está dentro del **namespace `GYF.Models.Responses`** y se utiliza **para devolver información resumida al frontend**,
//es decir, los datos que realmente se mostrarán en el home banking. Viene del documento del examen técnico como parte de la
//**respuesta de la API**.
//Las propiedades son:
//1. **`Fecha`** (`DateTime`): indica cuándo se realizó el movimiento de la tarjeta.
//2. **`Monto`** (`decimal`): representa el valor del movimiento, positivo para ingresos (depósitos, pagos recibidos) y negativo
//para egresos (pagos de tarjeta, compras).
//3. **`Descripcion`** (`string`): texto que explica de qué se trata el movimiento (por ejemplo, “Pago de tarjeta”, “Depósito”,
//etc.).
//**Notas importantes:**
//* Este modelo es más **ligero que `Movimiento`** del dominio, porque no incluye `Id` ni `TarjetaId`.
//* Se usa **solo para mostrar datos al cliente**, no para persistir en la base de datos.
//* Forma parte de la estructura **`ResumenCliente`**, que agrupa el saldo de la cuenta principal y los últimos movimientos de la
//tarjeta principal.
//En otras palabras, mientras que **`Movimiento`** refleja la estructura interna de la base de datos, **`MovimientoResumen`** es la
//versión **filtrada y lista para mostrar en el frontend**.

namespace GYF.Models.Responses
{
    public class MovimientoResumen
    {
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
    }
}
