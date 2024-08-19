import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { Button } from './Button.jsx';
import { Input } from './Input.jsx';
import '../output.css';


// Crear la raíz del componente en React
const root = createRoot(document.getElementById('root'));

// Renderizar el componente Button dentro de StrictMode
root.render(
  <StrictMode>
    <Button />
    <Input />
  </StrictMode>
);
