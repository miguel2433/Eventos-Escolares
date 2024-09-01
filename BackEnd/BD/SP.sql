use OrganizacionEventosEscolares;

-- Stored Procedure para dar de alta un Evento
DELIMITER //
CREATE PROCEDURE altaEvento (
    IN unNombreEvento VARCHAR(100),
    IN unaFecha DATE,
    IN unaUbicacion VARCHAR(100),
    IN unaDescripcion VARCHAR(250)
)
BEGIN
    INSERT INTO Eventos (Nombre, Fecha, Ubicación, Descripción)
    VALUES (unNombreEvento,unaFecha, unaUbicacion, unaDescripcion);
END //
DELIMITER ;

-- Stored Procedure para dar de alta un Estudiante
DELIMITER //
CREATE PROCEDURE altaEstudiante (
    IN unNombreEstudiante VARCHAR(100),
    IN unApellidoEstudiante VARCHAR(100),
    IN unaDivision TINYINT UNSIGNED,
    IN unAño TINYINT UNSIGNED,
    IN unCorreo VARCHAR(100),
    IN unaImageUrl VARCHAR(255)
)
BEGIN
    INSERT INTO Estudiantes (Nombre, Apellido,Division, Año, Correo, ImageUrl)
    VALUES (unNombreEstudiante, unApellidoEstudiante,unaDivision, unAño, unCorreo, unaImageUrl);
END //
DELIMITER ;


-- Stored Procedure para dar de alta una Participación
DELIMITER //
CREATE PROCEDURE altaParticipacion (
    IN unEventoId INT,
    IN unEstudianteId INT
)
BEGIN
    INSERT INTO Participaciones (idEvento, idEstudiante)
    VALUES (unEventoId, unEstudianteId);
END //
DELIMITER ;

-- Stored Procedure para dar de alta un Organizador
DELIMITER //
CREATE PROCEDURE altaOrganizador (
    IN unNombreOrganizador VARCHAR(100),
    IN unCorreoOrganizador VARCHAR(100),
    IN unPasswordOrganizador VARCHAR(100),
    IN unaImageUrl VARCHAR(255)
)
BEGIN
    INSERT INTO Organizadores (Nombre, Correo, Contraseña, ImageUrl)
    VALUES (unNombreOrganizador, unCorreoOrganizador, unPasswordOrganizador, unaImageUrl);
END //
DELIMITER ;

