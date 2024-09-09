-- Crear la base de datos
DROP DATABASE IF EXISTS OrganizacionEventosEscolares;
CREATE DATABASE OrganizacionEventosEscolares;

-- Usar la base de datos
USE OrganizacionEventosEscolares;

-- Crear la tabla de eventos
CREATE TABLE Evento (
    idEvento INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Fecha DATE,
    Ubicación VARCHAR(100),
    Descripción VARCHAR(250)
);

-- Crear la tabla de estudiantes
CREATE TABLE Estudiante (
    idEstudiante INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Division TINYINT UNSIGNED,
    Año TINYINT UNSIGNED,
    Correo VARCHAR(100),
    Username VARCHAR(100),
    ImageUrl VARCHAR(255)
);

-- Crear la tabla de participaciones
CREATE TABLE Participaciones (
    idParticipacion INT AUTO_INCREMENT PRIMARY KEY,
    idEvento INT,
    idEstudiante INT,
    FOREIGN KEY (idEvento) REFERENCES Evento(idEvento),
    FOREIGN KEY (idEstudiante) REFERENCES Estudiante(idEstudiante)
);

-- Crear la tabla de organizadores
-- Crear la tabla de organizadores con los nuevos campos
CREATE TABLE Organizadores (
    idOrganizadores INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Correo VARCHAR(100),
    Contraseña VARCHAR(100),
    ImageUrl VARCHAR(255)
);

