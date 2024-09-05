const Registrate = document.querySelector('.registrate');
const Registro = document.querySelector('.Registro');
const RegistroInner = document.querySelector('.Registro-inner');
const Login = document.querySelector('.section');
const Salir = document.querySelector('.salir-register')
let Estado = false;


function ExpansionDeDominio(){
  // Agregar la clase para iniciar la transición
  Registro.classList.add('visible');
  
  // Cambiar el border-radius y border del elemento Login
  Login.style.borderTopRightRadius = '0px';
  Login.style.borderBottomRightRadius = '0px';
  Login.style.borderRight = 'none';
}

function DominioIncompleto()
{
  Registro.classList.remove('visible');

  Login.style.borderTopRightRadius = '20px';
  Login.style.borderBottomRightRadius = '20px';
  Login.style.borderRight = '2px solid #d7d7d7';
}

Registrate.addEventListener('click', function() {
  if(Estado === false)
  {
    ExpansionDeDominio();
    Estado = true;
  }
});

Salir.addEventListener('click', function()
{
    if(Estado === true)
    {
        DominioIncompleto();
        Estado = false;
    }
});

