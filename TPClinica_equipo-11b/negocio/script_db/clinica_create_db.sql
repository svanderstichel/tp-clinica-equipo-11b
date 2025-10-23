CREATE DATABASE ClinicaMedica;
GO
USE ClinicaMedica;
GO

-- Paciente
CREATE TABLE Paciente (
    IdPaciente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    DNI VARCHAR(20) NOT NULL,
    Telefono VARCHAR(20),
    FechaNacimiento DATE,
    IdObraSocial INT
);

-- Medico
CREATE TABLE Medico (
    IdMedico INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Matricula VARCHAR(50) NOT NULL,
    Email VARCHAR(100),
    Telefono VARCHAR(20),
    IdTurnoTrabajo INT
);

-- Especialidad
CREATE TABLE Especialidad (
    IdEspecialidad INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200)
);

-- ObraSocial
CREATE TABLE ObraSocial (
    IdObraSocial INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200)
);

-- MedicoEspecialidad (relación muchos a muchos)
CREATE TABLE MedicoEspecialidad (
    IdMedicoEspecialidad INT PRIMARY KEY IDENTITY(1,1),
    IdMedico INT NOT NULL,
    IdEspecialidad INT NOT NULL,
    FOREIGN KEY (IdMedico) REFERENCES Medico(IdMedico),
    FOREIGN KEY (IdEspecialidad) REFERENCES Especialidad(IdEspecialidad)
);

-- TurnoTrabajo
CREATE TABLE TurnoTrabajo (
    IdTurnoTrabajo INT PRIMARY KEY IDENTITY(1,1),
    DiasLaborales VARCHAR(100) NOT NULL,
    HoraEntrada TIME NOT NULL,
    HoraSalida TIME NOT NULL,
);

-- Turno
CREATE TABLE Turno (
    IdTurno INT PRIMARY KEY IDENTITY(1,1),
    IdPaciente INT NOT NULL,
    IdMedico INT NOT NULL,
    IdEspecialidad INT NOT NULL,
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    Estado VARCHAR(20) NOT NULL, -- Nuevo, Reprogramado, Cancelado, NoAsistió, Cerrado
    Observaciones VARCHAR(500),
    FOREIGN KEY (IdPaciente) REFERENCES Paciente(IdPaciente),
    FOREIGN KEY (IdMedico) REFERENCES Medico(IdMedico),
    FOREIGN KEY (IdEspecialidad) REFERENCES Especialidad(IdEspecialidad)
);

-- Foreign Keys
ALTER TABLE Paciente ADD CONSTRAINT FK_Paciente_ObraSocial
FOREIGN KEY (IdObraSocial) REFERENCES ObraSocial(IdObraSocial);

ALTER TABLE Medico ADD CONSTRAINT FK_Medico_TurnoTrabajo
FOREIGN KEY (IdTurnoTrabajo) REFERENCES TurnoTrabajo(IdTurnoTrabajo);

-- Usuarios del sistema
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL,
    Pass VARCHAR(20) NOT NULL,
    Tipo INT NOT NULL,
);