const BotonGuardar = document.querySelector('.guardar-boton');
const EditarBoton = document.querySelector('.editar-boton');

function EnfocadoGuardar(){
    EditarBoton.style.backgroundColor = 'rgb(100, 100, 196)';
    EditarBoton.style.color = 'white';
    EditarBoton.style.border = 'none';
}


BotonGuardar.addEventListener('mouseover', function()
{
    EnfocadoGuardar();
});

