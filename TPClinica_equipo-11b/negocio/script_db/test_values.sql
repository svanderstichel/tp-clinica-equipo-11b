USE ClinicaMedica;
GO

------------------------------------------------------------
-- 1️⃣ OBRAS SOCIALES
------------------------------------------------------------
INSERT INTO ObraSocial (Nombre, Descripcion, Activo)
VALUES
('OSDE', 'Obra social de directivos de empresas', 1),
('Swiss Medical', 'Cobertura médica privada', 1),
('IOMA', 'Instituto de Obra Médico Asistencial', 1),
('PAMI', 'Obra social de jubilados y pensionados', 1),
('Galeno', 'Cobertura integral de salud', 1),
('Sancor Salud', 'Obra social con cobertura nacional', 1);

------------------------------------------------------------
-- 2️⃣ PACIENTES
------------------------------------------------------------
INSERT INTO Paciente (Nombre, Apellido, Email, DNI, Telefono, FechaNacimiento, IdObraSocial, Activo)
VALUES
('Juan', 'Pérez', 'juan.perez@gmail.com', '30123456', '2235123456', '1988-05-12', 1, 1),
('María', 'López', 'maria.lopez@yahoo.com', '29456789', '2235987456', '1992-09-03', 2, 1),
('Carlos', 'Gómez', 'carlos.gomez@hotmail.com', '31222333', '2235445566', '1979-02-21', 3, 1),
('Lucía', 'Fernández', 'lucia.fernandez@gmail.com', '28456712', '2235123489', '2000-12-30', 4, 1),
('Javier', 'Martínez', 'javier.martinez@live.com', '29987123', '2235667788', '1985-03-14', 1, 1),
('Sofía', 'Torres', 'sofia.torres@gmail.com', '30111987', '2235778899', '1990-10-09', 2, 1),
('Diego', 'Ruiz', 'diego.ruiz@yahoo.com', '31002211', '2235889900', '1982-06-22', 3, 1),
('Camila', 'Santos', 'camila.santos@hotmail.com', '32233444', '2235990011', '1999-08-01', 4, 1),
('Nicolás', 'Herrera', 'nicolas.herrera@gmail.com', '28776655', '2235110022', '1995-04-16', 5, 1),
('Valentina', 'Suárez', 'valentina.suarez@gmail.com', '30188900', '2235221133', '1987-12-28', 6, 1),
('Martín', 'Alonso', 'martin.alonso@gmail.com', '29550122', '2235332244', '1993-09-15', 1, 1),
('Paula', 'Vega', 'paula.vega@gmail.com', '30011223', '2235443355', '1984-11-07', 2, 1),
('Andrés', 'Mendoza', 'andres.mendoza@yahoo.com', '30889977', '2235554466', '1996-07-19', 3, 1),
('Julieta', 'Cáceres', 'julieta.caceres@gmail.com', '31221144', '2235665577', '1991-05-23', 4, 1),
('Federico', 'Paz', 'federico.paz@gmail.com', '29987766', '2235776688', '1989-09-11', 5, 1),
('Elena', 'Bravo', 'elena.bravo@gmail.com', '30199888', '2235887799', '1994-10-02', 6, 1),
('Laura', 'Castro', 'laura.castro@gmail.com', '32011009', '2235998800', '1997-01-25', 1, 1),
('Ezequiel', 'Moreno', 'ezequiel.moreno@gmail.com', '28991222', '2235009911', '1981-03-05', 2, 1),
('Agustina', 'Leiva', 'agustina.leiva@gmail.com', '29887700', '2235111022', '2001-02-14', 3, 1),
('Santiago', 'Campos', 'santiago.campos@gmail.com', '29221133', '2235222133', '1998-06-20', 4, 1);

------------------------------------------------------------
-- 3️⃣ TURNOS DE TRABAJO
------------------------------------------------------------
INSERT INTO TurnoTrabajo (DiasLaborales, HoraEntrada, HoraSalida)
VALUES
('[1,2,3,4,5]', '08:00', '14:00'),
('[1,2,3,4,5]', '10:00', '16:00'),
('[2,3,4,5,6]', '09:00', '15:00'),
('[1,3,5]', '08:00', '12:00'),
('[1,2,4,5]', '13:00', '19:00'),
('[1,2,3,4,5]', '07:00', '13:00'),
('[1,2,3,4,5,6]', '09:00', '17:00'),
('[2,3,5]', '14:00', '20:00'),
('[1,2,3,4]', '08:30', '14:30'),
('[1,2,3,4,5]', '12:00', '18:00');

------------------------------------------------------------
-- 4️⃣ ESPECIALIDADES
------------------------------------------------------------
INSERT INTO Especialidad (Nombre, Descripcion, Estado)
VALUES
('Clínica Médica', 'Atención médica general', 1),
('Pediatría', 'Atención de niños y adolescentes', 1),
('Cardiología', 'Estudios y control del corazón', 1),
('Dermatología', 'Tratamiento de enfermedades de la piel', 1),
('Traumatología', 'Lesiones óseas y musculares', 1),
('Oftalmología', 'Estudios de la vista', 1),
('Ginecología', 'Salud reproductiva femenina', 1),
('Neurología', 'Sistema nervioso y cerebro', 1);

------------------------------------------------------------
-- 5️⃣ MÉDICOS
------------------------------------------------------------
INSERT INTO Medico (Nombre, Apellido, Matricula, Email, Telefono, IdTurnoTrabajo, Estado)
VALUES
('Ana', 'Martínez', 'M-1234', 'ana.martinez@clinica.com', '2235441122', 1, 1),
('Roberto', 'Suárez', 'M-2345', 'roberto.suarez@clinica.com', '2235442233', 2, 1),
('Carolina', 'Vega', 'M-3456', 'carolina.vega@clinica.com', '2235443344', 3, 1),
('Sergio', 'Morales', 'M-4567', 'sergio.morales@clinica.com', '2235444455', 4, 1),
('Lucía', 'Navarro', 'M-5678', 'lucia.navarro@clinica.com', '2235445566', 5, 1),
('Pablo', 'Cano', 'M-6789', 'pablo.cano@clinica.com', '2235446677', 6, 1),
('Graciela', 'Pardo', 'M-7890', 'graciela.pardo@clinica.com', '2235447788', 7, 1),
('Tomás', 'Herrera', 'M-8901', 'tomas.herrera@clinica.com', '2235448899', 8, 1),
('Elena', 'Ríos', 'M-9012', 'elena.rios@clinica.com', '2235449900', 9, 1),
('Marcos', 'Luna', 'M-0123', 'marcos.luna@clinica.com', '2235450011', 10, 1);

------------------------------------------------------------
-- 6️⃣ MÉDICO - ESPECIALIDAD
------------------------------------------------------------
INSERT INTO MedicoEspecialidad (IdMedico, IdEspecialidad)
VALUES
(1, 1), (1, 3),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 1),
(9, 8),
(10, 1), (10, 5);

------------------------------------------------------------
-- 7️⃣ TURNOS (30 turnos aleatorios)
------------------------------------------------------------
INSERT INTO Turno (IdPaciente, IdMedico, IdEspecialidad, Fecha, Hora, Estado, Observaciones)
VALUES
(1, 1, 1, '2025-11-13', '09:00', 1, 'Consulta general'),
(2, 2, 2, '2025-11-13', '10:00', 2, 'Control pediátrico'),
(3, 3, 3, '2025-11-14', '11:30', 5, 'Chequeo cardiológico completado'),
(4, 4, 4, '2025-11-15', '08:30', 3, 'Turno cancelado por el paciente'),
(5, 1, 3, '2025-11-16', '09:30', 4, 'Paciente no asistió'),
(6, 5, 5, '2025-11-16', '14:00', 1, 'Lesión de rodilla'),
(7, 6, 6, '2025-11-17', '15:00', 5, 'Control oftalmológico'),
(8, 7, 7, '2025-11-18', '10:00', 1, 'Chequeo ginecológico'),
(9, 8, 1, '2025-11-18', '09:00', 1, 'Consulta clínica'),
(10, 9, 8, '2025-11-19', '11:30', 1, 'Control neurológico'),
(11, 10, 5, '2025-11-19', '16:00', 2, 'Reprogramado por médico'),
(12, 1, 3, '2025-11-20', '09:00', 1, 'Chequeo cardiovascular'),
(13, 2, 2, '2025-11-20', '11:00', 1, 'Revisión pediátrica'),
(14, 3, 3, '2025-11-21', '10:30', 3, 'Cancelado por paciente'),
(15, 4, 4, '2025-11-22', '09:00', 5, 'Tratamiento dermatológico finalizado'),
(16, 5, 5, '2025-11-22', '13:30', 1, 'Control postoperatorio'),
(17, 6, 6, '2025-11-23', '08:00', 4, 'No asistió'),
(18, 7, 7, '2025-11-23', '14:30', 5, 'Chequeo completado'),
(19, 8, 1, '2025-11-24', '09:15', 1, 'Consulta general'),
(20, 9, 8, '2025-11-24', '10:00', 2, 'Reprogramado por médico'),
(1, 2, 2, '2025-11-25', '09:45', 1, 'Chequeo pediátrico'),
(2, 3, 3, '2025-11-25', '10:30', 1, 'Estudio de rutina'),
(3, 4, 4, '2025-11-26', '11:15', 3, 'Turno cancelado'),
(4, 5, 5, '2025-11-27', '08:45', 1, 'Dolor muscular'),
(5, 6, 6, '2025-11-27', '10:00', 1, 'Control visual'),
(6, 7, 7, '2025-11-28', '12:00', 5, 'Chequeo ginecológico completado'),
(7, 8, 1, '2025-11-28', '09:00', 4, 'No asistió'),
(8, 9, 8, '2025-11-29', '15:00', 1, 'Evaluación neurológica'),
(9, 10, 1, '2025-11-29', '10:30', 5, 'Turno cerrado con éxito'),
(10, 1, 3, '2025-11-30', '09:30', 1, 'Control cardiológico'),
(11, 2, 2, '2025-12-01', '10:15', 1, 'Chequeo general');

------------------------------------------------------------
-- 8️⃣ USUARIOS DEL SISTEMA
------------------------------------------------------------
INSERT INTO Usuario (Email, Nombre, Apellido, Pass, Tipo)
VALUES
('admin@clinica.com', 'Admin', 'General', 'admin123', 1),
('recepcion@clinica.com', 'Laura', 'Méndez', 'recep123', 2),
('ana.martinez@clinica.com', 'Ana', 'Martínez', 'medico123', 3),
('roberto.suarez@clinica.com', 'Roberto', 'Suárez', 'medico234', 3),
('soporte@clinica.com', 'Soporte', 'IT', 'soporte123', 4),
('pablo.cano@clinica.com', 'Pablo', 'Cano', 'medico456', 3),
('graciela.pardo@clinica.com', 'Graciela', 'Pardo', 'medico567', 3),
('lucia.navarro@clinica.com', 'Lucía', 'Navarro', 'medico678', 3),
('marcos.luna@clinica.com', 'Marcos', 'Luna', 'medico789', 3),
('elena.rios@clinica.com', 'Elena', 'Ríos', 'medico890', 3);
