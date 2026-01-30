//Esta función `getResumenCliente` en TypeScript/React es un **servicio asincrónico** que se 
// encarga de consumir la API del backend para obtener el resumen de un cliente. Recibe como 
// parámetro el `clienteId` y primero valida que sea un número positivo, lanzando un error 
// si no lo es. Luego realiza un `fetch` a la URL de la API 
// (`http://localhost:5079/api/clientes/{clienteId}/resumen`) y espera la respuesta. Si la 
// respuesta no es satisfactoria (`response.ok` es falso), lanza un error indicando que no 
// se pudo obtener la información. Finalmente, convierte el JSON recibido en un objeto del 
// tipo `ResumenCliente` (importado desde los tipos de la aplicación) y lo retorna, 
// proporcionando así al frontend los datos necesarios de manera tipada y segura.


import type { ResumenCliente } from "./types"; // importamos los tipos

export async function getResumenCliente(clienteId: number): Promise<ResumenCliente> {
  if (clienteId <= 0) {
    throw new Error("Cliente no encontrado");
  }

  const response = await fetch(`http://localhost:5106/api/clientes/${clienteId}/resumen`);
  
  if (!response.ok) {
    throw new Error("Error al obtener el resumen del cliente");
  }

  const data = await response.json();
  return data as ResumenCliente;
}
