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
