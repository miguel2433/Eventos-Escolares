const Registrate = document.querySelector('.registrate');
const Registro = document.querySelector('.Registro');
const RegistroInner = document.querySelector('.Registro-inner');
const Login = document.querySelector('.section');
const Salir = document.querySelector('.salir');

let Estado = false;

function ExpansionDeDominio() {
    // Agregar la clase para iniciar la transición
    Registro.classList.add('visible');
    
    // Cambiar el border-radius y border del elemento Login
    Login.style.borderTopRightRadius = '0px';
    Login.style.borderBottomRightRadius = '0px';
    Login.style.borderRight = 'none';
}

function DominioIncompleto() {
    Registro.classList.remove('visible');
    Login.style.borderTopRightRadius = '20px';
    Login.style.borderBottomRightRadius = '20px';
    Login.style.borderRight = '2px solid #d7d7d7';
}

Registrate.addEventListener('click', function() {
    if (Estado === false) {
        ExpansionDeDominio();
        Registrate.innerHTML = 'Salir Registro';
        Estado = true;
    } else {
        DominioIncompleto();
        Registrate.innerHTML = 'Registrate';
        Estado = false;
    }
});

Salir.addEventListener('click', function() {
    if (Estado === true) {
        DominioIncompleto();
        Estado = false;
        Registrate.innerHTML = 'Registrate';
    }
});

document.addEventListener('DOMContentLoaded', function () {
    // Selecciona el elemento con el nombre "__Invariant"
    var invariantInput = document.querySelectorAll('input[name="__Invariant"]');
    console.log('Invariant Input:', invariantInput); // Verifica si el elemento es encontrado
    if (invariantInput) {
        invariantInput.remove();
    }
});

// Crea un observador para detectar cambios en el tamaño del 'section'
const resizeObserverLogin = new ResizeObserver(() => {
    // Obtén el nuevo height de la sección
    const sectionHeight = Login.offsetHeight;
    
    // Asigna el mismo height al elemento con la clase 'registro'
    Registro.style.height = `${sectionHeight}px`;
});

// Inicia la observación de cambios en el tamaño del 'section'
resizeObserverLogin.observe(Login);
