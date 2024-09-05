const Registrate = document.querySelector('.registrate');
const Registro = document.querySelector('.Registro');
const RegistroInner = document.querySelector('.Registro-inner');
const Login = document.querySelector('.section');


function ExpansionDeDominio(){
  // Agregar la clase para iniciar la transición
  Registro.classList.add('visible');
  
  // Cambiar el border-radius y border del elemento Login
  Login.style.borderTopRightRadius = '0px';
  Login.style.borderBottomRightRadius = '0px';
  Login.style.borderRight = '0px';
}

Registrate.addEventListener('click', function() {
  ExpansionDeDominio();
});
