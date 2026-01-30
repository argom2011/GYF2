//Estas interfaces en TypeScript definen la estructura de los datos que maneja el frontend: 
// `Movimiento` representa cada operación financiera con su fecha, monto y descripción, 
// mientras que `ResumenCliente` agrupa el saldo de la cuenta principal del cliente y un 
// arreglo de sus movimientos recientes, proporcionando un modelo tipado y consistente para 
// interactuar con la API y mostrar la información en la aplicación.

export interface Movimiento {
  fecha: string;
  monto: number;
  descripcion: string;
}

export interface ResumenCliente {
  saldoCuentaPrincipal: number;
  movimientos: Movimiento[];
}
