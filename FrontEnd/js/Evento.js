const Input = document.querySelector('.buscar-input');
const Aside = document.querySelector('.border-aside');
let Estado = false;

// Cuando el input recibe el foco
Input.addEventListener('focus', function() {
    Aside.style.height = '100%';
    Estado = true;
});

// Cuando se hace clic en cualquier lugar del documento
document.addEventListener('click', function(event) {
    if (!Input.contains(event.target)) {
        // Si el clic es fuera del input
        if (Estado) {
            Aside.style.height = '80%';
            Estado = false;
        }
    }
});

document.addEventListener('DOMContentLoaded', () => {
    const elementos = document.querySelectorAll('.event-content');
  
    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          // Añadir la clase 'animar' solo si no tiene la clase
          if (!entry.target.classList.contains('animar')) {
            entry.target.classList.add('animar');
          }
        } else {
          // Aquí podrías optar por no quitar la clase, o hacerlo solo cuando quieras reiniciar la animación
          entry.target.classList.remove('animar');
        }
      });
    }, {
      threshold: 0.2, // Umbral de visibilidad (20%)
      rootMargin: "0px 0px 20% 0px" // Esto añade un margen al fondo, lo que asegura mejor detección
    });
  
    elementos.forEach(elemento => {
      observer.observe(elemento);
    });
  });