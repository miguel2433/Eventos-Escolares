const guardarBoton = document.querySelector('.guardar-boton');
const editarBoton = document.querySelector('.editar-boton');

guardarBoton.addEventListener('mouseover', () => {
  editarBoton.classList.add('hover-editar');
  guardarBoton.classList.add('hover-guardar');
})
guardarBoton.addEventListener('mouseout', () => {
  editarBoton.classList.remove('hover-editar');
  guardarBoton.classList.remove('hover-guardar');
})
editarBoton.addEventListener('mouseover', () => {
  guardarBoton.classList.add('hover-guardar');
  editarBoton.classList.add('hover-editar');
})
editarBoton.addEventListener('mouseout', () => {
  guardarBoton.classList.remove('hover-guardar');
  editarBoton.classList.remove('hover-editar');
})