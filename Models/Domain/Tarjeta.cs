//Este modelo está dentro del **namespace `GYF.Models.Domain`** y representa **cada tarjeta asociada a una cuenta de un cliente**.
//Fue parte de los modelos que venían con el examen técnico para construir el **resumen de cuentas y movimientos**.
//Las propiedades son:
//1. **`Id`** (`int`): identificador único de la tarjeta en la base de datos.
//2. **`CuentaId`** (`int`): clave foránea que indica a qué **cuenta bancaria** pertenece la tarjeta. Permite relacionar tarjetas
//con cuentas.
//3. **`Numero`** (`string`): número de la tarjeta, que identifica la tarjeta para transacciones y movimientos.
//4. **`EsPrincipal`** (`bool`): indica si esta tarjeta es la **principal** de la cuenta. Esto es importante porque, al mostrar el
//resumen en el home banking, generalmente solo se muestran los movimientos de la tarjeta principal.
//En resumen:
//* Una **cuenta** puede tener **varias tarjetas**.
//* Cada **tarjeta** puede tener **varios movimientos**.
//* El modelo **`Tarjeta`** sirve como el vínculo entre la **cuenta** y los **movimientos** que se muestran al cliente en su resumen
//financiero.


namespace GYF.Models.Domain
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public int CuentaId { get; set; }
        public string Numero { get; set; }
        public bool EsPrincipal { get; set; }
    }
}
