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
    INSERT INTO Eventos (Nombre, Fecha, Ubicacion, Descripcion)
    VALUES (unNombreEvento,unaFecha, unaUbicacion, unaDescripcion);
END //
DELIMITER ;

-- Stored Procedure para dar de alta un Estudiante
DELIMITER //
CREATE PROCEDURE altaEstudiante (
    IN unNombreEstudiante VARCHAR(100),
    IN unApellidoEstudiante VARCHAR(100),
    IN unUsername VARCHAR(100),
    IN unaDivision TINYINT UNSIGNED,
    IN unAño TINYINT UNSIGNED,
    IN unCorreo VARCHAR(100),
    IN unaImageUrl VARCHAR(255),
    IN unaContrasena VARCHAR(255),
)
BEGIN
    INSERT INTO Estudiantes (Nombre, Apellido,Username,Division, Anio, Correo, ImageUrl,Contrasena)
    VALUES (unNombreEstudiante, unApellidoEstudiante,unUsername,unaDivision, unAño, unCorreo, unaImageUrl,unaContrasena);
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
    INSERT INTO Organizadores (Nombre, Correo, Contrasena, ImageUrl)
    VALUES (unNombreOrganizador, unCorreoOrganizador, unPasswordOrganizador, unaImageUrl);
END //
DELIMITER ;

