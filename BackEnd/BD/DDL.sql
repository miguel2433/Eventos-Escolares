-- Crear la base de datos
DROP DATABASE IF EXISTS 5to_OrganizacionEventosEscolares;
CREATE DATABASE 5to_OrganizacionEventosEscolares;

-- Usar la base de datos
USE 5to_OrganizacionEventosEscolares;

-- Crear la tabla de estudiantes
CREATE TABLE Estudiante (
    idEstudiante INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Division INT,
    Anio INT,
    Correo VARCHAR(100),
    Username VARCHAR(100),
    ImagenUrl VARCHAR(255),
    Contrasena VARCHAR(255),
    IsAdmin BOOLEAN
);

-- Crear la tabla de organizadores
CREATE TABLE Organizadores (
    idOrganizadores INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Correo VARCHAR(100),
    Contrasena VARCHAR(100),
    ImageUrl VARCHAR(255)
);

-- Crear la tabla de eventos
CREATE TABLE Evento (
    idEstudiante INT,
    idEvento INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Fecha DATE,
    Ubicacion VARCHAR(100),
    Descripcion VARCHAR(250),
    ImagenUrl VARCHAR(255),
    FOREIGN KEY (idEstudiante) REFERENCES Estudiante(idEstudiante)
);

ALTER TABLE `5to_OrganizacionEventosEscolares`.`Evento`
ADD FULLTEXT INDEX ft_index_titulo (Nombre);

-- Crear la tabla de participaciones
CREATE TABLE Participaciones (
    idParticipacion INT AUTO_INCREMENT PRIMARY KEY,
    idEvento INT,
    idEstudiante INT,
    FOREIGN KEY (idEvento) REFERENCES Evento(idEvento),
    FOREIGN KEY (idEstudiante) REFERENCES Estudiante(idEstudiante)
);
