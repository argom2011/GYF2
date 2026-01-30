//Este modelo está dentro del **namespace `GYF.Models.Domain`**, que indica que forma parte de los objetos centrales de dominio de
//la aplicación, es decir, representa conceptos reales del negocio.
//La clase `Cliente` define un **cliente del sistema de tarjetas de crédito**, y tiene solo dos propiedades:
//1. **`Id`** (`int`): es un identificador único de cada cliente. Sirve para diferenciar clientes en la base de datos y en la lógica
//del sistema.
//2. **`Nombre`** (`string`): almacena el nombre del cliente. Es lo que se mostraría en interfaces como el home banking.
//Este modelo es **muy simple y directo**, y vino incluido en el documento del examen técnico como parte de los modelos básicos del
//sistema. Sirve como punto de partida para relacionarlo con las **cuentas y tarjetas** del cliente, que son otros modelos que
//también se definieron en el examen.
//En pocas palabras: **`Cliente` representa a la persona que tiene cuentas y tarjetas**, y es la entidad principal a la que se
//asociarán todas las demás relaciones en la base de datos y en la API.

namespace GYF.Models.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
