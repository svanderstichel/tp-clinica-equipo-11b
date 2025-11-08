CREATE DATABASE ClinicaMedica;
GO
USE ClinicaMedica;
GO

-- ObraSocial
CREATE TABLE ObraSocial (
    IdObraSocial INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Descripcion VARCHAR(200)
);

-- Paciente
CREATE TABLE Paciente (
    IdPaciente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    DNI VARCHAR(20) NOT NULL UNIQUE,
    Telefono VARCHAR(20),
    FechaNacimiento DATE,
    IdObraSocial INT NOT NULL
);

-- TurnoTrabajo
CREATE TABLE TurnoTrabajo (
    IdTurnoTrabajo INT PRIMARY KEY IDENTITY(1,1),
    DiasLaborales VARCHAR(100) NOT NULL, -- En la capa de dominio los dias de la semana se representan como un array de int. Ejemplo: lunes a viernes [1,2,3,4,5];
    HoraEntrada TIME NOT NULL,
    HoraSalida TIME NOT NULL,
    CONSTRAINT CK_TurnoTrabajo_Horario CHECK (HoraSalida > HoraEntrada)
);

-- Especialidad
CREATE TABLE Especialidad (
    IdEspecialidad INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200)
);

-- Medico
CREATE TABLE Medico (
    IdMedico INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Matricula VARCHAR(50) NOT NULL UNIQUE,
    Email VARCHAR(100) UNIQUE,
    Telefono VARCHAR(20),
    IdTurnoTrabajo INT NOT NULL
);

-- MedicoEspecialidad (relación muchos a muchos)
CREATE TABLE MedicoEspecialidad (
    IdMedicoEspecialidad INT PRIMARY KEY IDENTITY(1,1),
    IdMedico INT NOT NULL,
    IdEspecialidad INT NOT NULL,
    CONSTRAINT FK_MedEsp_Medico FOREIGN KEY (IdMedico) REFERENCES Medico(IdMedico),
    CONSTRAINT FK_MedEsp_Especialidad FOREIGN KEY (IdEspecialidad) REFERENCES Especialidad(IdEspecialidad),
    CONSTRAINT UQ_MedicoEspecialidad UNIQUE (IdMedico, IdEspecialidad)
);

-- Turno
CREATE TABLE Turno (
    IdTurno INT PRIMARY KEY IDENTITY(1,1),
    IdPaciente INT NOT NULL,
    IdMedico INT NOT NULL,
    IdEspecialidad INT NOT NULL,
    Fecha DATE NOT NULL,
    Hora TIME NOT NULL,
    Estado INT NOT NULL, -- Nuevo, Reprogramado, Cancelado, NoAsistió, Cerrado
    Observaciones VARCHAR(500),
    CONSTRAINT FK_Turno_Paciente FOREIGN KEY (IdPaciente) REFERENCES Paciente(IdPaciente),
    CONSTRAINT FK_Turno_Medico FOREIGN KEY (IdMedico) REFERENCES Medico(IdMedico),
    CONSTRAINT FK_Turno_Especialidad FOREIGN KEY (IdEspecialidad) REFERENCES Especialidad(IdEspecialidad),
);

-- Foreign Keys
ALTER TABLE Paciente ADD CONSTRAINT FK_Paciente_ObraSocial
FOREIGN KEY (IdObraSocial) REFERENCES ObraSocial(IdObraSocial);

ALTER TABLE Medico ADD CONSTRAINT FK_Medico_TurnoTrabajo
FOREIGN KEY (IdTurnoTrabajo) REFERENCES TurnoTrabajo(IdTurnoTrabajo);

-- Usuarios del sistema
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Email VARCHAR(50) NOT NULL UNIQUE,
    Nombre VARCHAR(20) NOT NULL,
    Apellido VARCHAR(20) NOT NULL,
    Pass VARCHAR(20) NOT NULL,
    Tipo INT NOT NULL
);


Alter Table ObraSocial ADD Activo BIT NULL;

