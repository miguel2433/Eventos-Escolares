document.addEventListener('DOMContentLoaded', () => {
    const modal = document.getElementById('participantsModal');
    const btn = document.querySelector('.boton'); // Asumiendo que este es el primer botón, ajusta si es necesario
    const span = document.getElementsByClassName('close')[0];

    btn.onclick = function() {
        modal.style.display = 'block';
        // Obtener y mostrar participantes aquí
        fetchParticipants();
    }

    span.onclick = function() {
        modal.style.display = 'none';
    }

    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = 'none';
        }
    }

});