//Este archivo `main.tsx` es el punto de entrada del frontend en React. Utiliza 
// `ReactDOM.createRoot` para montar la aplicación en el elemento HTML con id `root` y 
// renderiza el componente principal `App` dentro de `React.StrictMode`, lo que permite 
// detectar problemas potenciales en el desarrollo. También importa los estilos globales 
// desde `index.css`, asegurando que la aplicación tenga la apariencia definida al iniciarse.

import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import "./index.css";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
