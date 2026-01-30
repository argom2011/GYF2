//Este componente de React, `ResumenCliente`, implementa una **interfaz de usuario para 
// consultar el resumen financiero de un cliente**. Utiliza `useState` para manejar el ID del
//  cliente ingresado, el resumen obtenido de la API y posibles mensajes de error. Al 
// presionar el botón “Consultar”, ejecuta la función `buscar`, que llama a 
// `getResumenCliente` del servicio API, valida que existan datos y actualiza el estado. 
// Luego, el componente renderiza dinámicamente el saldo de la cuenta principal y los 
// últimos movimientos, mostrando mensajes de error cuando el cliente no existe o no tiene 
// movimientos, proporcionando así una experiencia interactiva y reactiva en el frontend.

import { useState } from "react";
import { getResumenCliente } from "../api/clienteApi";
import type { ResumenCliente as ResumenClienteType } from "../api/types"; // importamos solo el tipo
import "./ResumenCliente.css";

function ResumenCliente() {
  const [clienteId, setClienteId] = useState<string>("");
  const [resumen, setResumen] = useState<ResumenClienteType | null>(null);
  const [error, setError] = useState<string>("");

  const buscar = async () => {
    setError("");
    setResumen(null);

    if (!clienteId) {
      setError("Ingrese un número de cliente");
      return;
    }

    try {
      // convertimos el clienteId a número
      const data = await getResumenCliente(Number(clienteId));

      // Si la API devuelve null o movimientos vacíos
      if (!data || (!data.movimientos || data.movimientos.length === 0)) {
        setError("No se encontraron movimientos para este cliente.");
        return;
      }

      setResumen(data);
    } catch {
      setError("No se pudo obtener el resumen del cliente");
    }
  };

  return (
    <div className="home-container">
      <div className="card">
        <h2>Home Banking</h2>

        <input
          type="number"
          placeholder="Número de cliente"
          value={clienteId}
          onChange={(e) => setClienteId(e.target.value)}
        />

        <button onClick={buscar}>Consultar</button>

        {/* Mensajes de error */}
        {error && <p className="error">{error}</p>}

        {/* Resumen del cliente */}
        {resumen && (
          <>
            <div className="saldo">
              Saldo: ${resumen.saldoCuentaPrincipal.toLocaleString()}
            </div>

            <div className="movimientos">
              <h4>Últimos movimientos</h4>
              <ul>
                {resumen.movimientos.map((m, i) => (
                  <li key={i}>
                    <span>{m.descripcion}</span>
                    <span>${m.monto.toLocaleString()}</span>
                  </li>
                ))}
              </ul>
            </div>
          </>
        )}
      </div>
    </div>
  );
}

export default ResumenCliente;
