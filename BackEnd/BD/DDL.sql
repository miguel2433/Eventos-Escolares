-- Crear la base de datos
CREATE DATABASE OrganizacionEventosEscolares;

-- Usar la base de datos
USE OrganizacionEventosEscolares;

-- Crear la tabla de eventos
CREATE TABLE Eventos (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Fecha DATE,
    Ubicación VARCHAR(100),
    Descripción VARCHAR(250)
);

-- Crear la tabla de estudiantes
CREATE TABLE Estudiantes (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Apellido VARCHAR(100),
    Division TINYINT UNSIGNED,
    Año TINYINT UNSIGNED,
    Correo VARCHAR(100),
    ImageUrl VARCHAR(255)
);

-- Crear la tabla de participaciones
CREATE TABLE Participaciones (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Evento_ID INT,
    Estudiante_ID INT,
    FOREIGN KEY (Evento_ID) REFERENCES Eventos(ID),
    FOREIGN KEY (Estudiante_ID) REFERENCES Estudiantes(ID)
);

-- Crear la tabla de organizadores
-- Crear la tabla de organizadores con los nuevos campos
CREATE TABLE Organizadores (
    IDorganizadores INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100),
    Correo VARCHAR(100),
    Password VARCHAR(100),
    ImageUrl VARCHAR(255)
);

