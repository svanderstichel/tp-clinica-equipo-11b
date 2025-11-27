USE ClinicaMedica;
GO

---------------------------------------------------------
-- OBRAS SOCIALES
---------------------------------------------------------
INSERT INTO ObraSocial (Nombre, Descripcion, Cobertura, Estado)
VALUES
('Swiss Medical', 'Cobertura médica privada', 'Plan SMG20', 1),
('Swiss Medical', 'Cobertura médica privada', 'Plan SMG30', 1),
('Medifé', 'Medicina prepaga nacional', 'Plan Plata', 1),
('Medifé', 'Medicina prepaga nacional', 'Plan Oro', 1),
('Galeno', 'Cobertura médica integral', 'Plan 220', 1),
('Galeno', 'Cobertura médica integral', 'Plan 330', 1),
('OSPJN', 'Obra social del Poder Judicial', 'Plan Básico', 1),
('IOMA', 'Instituto Obra Médico Asistencial', 'Plan A', 1),
('IOMA', 'Instituto Obra Médico Asistencial', 'Plan B', 1),
('PAMI', 'Programa de Atención Médica Integral', 'Afiliados mayores', 1);

---------------------------------------------------------
-- ESPECIALIDADES
---------------------------------------------------------
INSERT INTO Especialidad (Nombre, Descripcion, Estado)
VALUES
('Cardiología', 'Corazón', 1),
('Clínica Médica', 'General', 1),
('Dermatología', 'Piel', 1),
('Traumatología', 'Huesos y articulaciones', 1),
('Pediatría', 'Niños', 1),
('Neurología', 'Sistema nervioso', 1),
('Ginecología', 'Salud femenina', 1),
('Endocrinología', 'Hormonas', 1),
('Gastroenterología', 'Sistema digestivo', 1),
('Otorrinolaringología', 'Oídos y garganta', 1);

---------------------------------------------------------
-- MÉDICOS
---------------------------------------------------------
INSERT INTO Medico
(Nombre, Apellido, Matricula, Email, Telefono, DiasLaborales, HoraEntrada, HoraSalida, Estado)
VALUES
('AdminMedico', 'Test', 'MAT-999', 'admin@gmail.com', '2236001888', '[1,2,3,4,5]', '08:00', '14:00', 1),
('Juan', 'Pérez', 'MAT-001', 'jperez@clinica.com', '2235123456', '[1,2,3,4,5]', '08:00', '14:00', 1),
('María', 'García', 'MAT-002', 'mgarcia@clinica.com', '2235987654', '[1,3,5]', '10:00', '16:00', 1),
('Carlos', 'López', 'MAT-003', 'clopez@clinica.com', '2235543210', '[2,4]', '09:00', '13:00', 1),
('Ana', 'Torres', 'MAT-004', 'atorres@clinica.com', '2234321122', '[1,2,3]', '08:30', '14:30', 1),
('Javier', 'Mena', 'MAT-005', 'jmena@clinica.com', '2235009988', '[1,2,4,5]', '10:00', '17:00', 1),
('Lucía', 'Rojas', 'MAT-006', 'lrojas@clinica.com', '2235447766', '[3,4,5]', '09:00', '15:00', 1),
('Roberto', 'Sosa', 'MAT-007', 'rsosa@clinica.com', '2235223344', '[2,3,4]', '08:00', '14:00', 1),
('Laura', 'Vega', 'MAT-008', 'lvega@clinica.com', '2235448833', '[1,4,5]', '11:00', '18:00', 1),
('Sofía', 'Martínez', 'MAT-009', 'smartinez@clinica.com', '2235772233', '[1,2]', '07:00', '13:00', 1),
('Hernán', 'Gutiérrez', 'MAT-010', 'hgutiérrez@clinica.com', '2235667788', '[3,5]', '12:00', '18:00', 1),
('Pedro', 'Salas', 'MAT-011', 'psalas@clinica.com', '2236112211', '[1,2,3,4,5]', '08:00', '14:00', 1),
('Claudia', 'Nuñez', 'MAT-012', 'cnunez@clinica.com', '2236998877', '[2,4]', '10:00', '16:00', 1);

---------------------------------------------------------
-- MÉDICO - ESPECIALIDAD (many-to-many)
---------------------------------------------------------
INSERT INTO MedicoEspecialidad (IdMedico, IdEspecialidad)
VALUES
(1,1),(1,2),(2,2),(2,5),(3,3),(4,4),(4,2),(5,1),
(5,6),(6,7),(7,8),(7,2),(8,9),(9,10),(9,2),(10,6),
(11,4),(11,1),(12,7),(12,9),(6,3),(3,10),(5,3),(8,4);

---------------------------------------------------------
-- PACIENTES (20 registros)
---------------------------------------------------------
INSERT INTO Paciente (Nombre, Apellido, Email, DNI, Telefono, FechaNacimiento, IdObraSocial, Estado)
VALUES
('AdminPaciente', 'Test', 'admin@gmail.com', '50000111', '2236001999', '1990-01-01', 1, 1),
('Santiago','Vander','sv1@mail.com','40111221','2236001001','1995-03-10',1,1),
('Lucía','Martínez','lm1@mail.com','38999441','2236001002','1988-07-21',2,1),
('Pablo','Ramírez','pr@mail.com','35555112','2236001003','1990-11-02',3,1),
('Marina','Díaz','md@mail.com','32000999','2236001004','1992-12-12',4,1),
('Jorge','Santos','js@mail.com','33000888','2236001005','1985-01-14',5,1),
('Rocío','Fernández','rf@mail.com','30077111','2236001006','1999-02-20',6,1),
('Emilia','Quiroga','eq@mail.com','40988777','2236001007','2000-06-04',7,1),
('Bruno','López','bl@mail.com','28888111','2236001008','1983-09-19',8,1),
('Lucas','Paz','lp@mail.com','37123456','2236001009','1989-05-30',1,1),
('Carla','Soto','cs@mail.com','36111222','2236001010','1997-10-10',2,1),
('Esteban','Mansilla','em@mail.com','34222111','2236001011','1984-04-13',3,1),
('Mauro','Duarte','md2@mail.com','30011222','2236001012','1991-02-02',4,1),
('Sofía','Rivas','sr@mail.com','32233111','2236001013','1998-11-25',5,1),
('Camila','Giménez','cg@mail.com','33322111','2236001014','1994-03-03',6,1),
('Tobías','Mena','tm@mail.com','31111999','2236001015','2001-01-09',7,1),
('Nadia','Vega','nv@mail.com','35022022','2236001016','1986-07-08',8,1),
('Franco','Alvarez','fa@mail.com','37011222','2236001017','1993-12-31',1,1),
('Josefina','Roldán','jr@mail.com','41112222','2236001018','2002-05-15',2,1),
('Milena','Suarez','ms@mail.com','39999111','2236001019','1990-09-09',3,1),
('Agustín','Bravo','ab@mail.com','35111222','2236001020','1996-08-18',4,1),
('Valeria','Dominguez','vd@mail.com','33222444','2236001021','1987-04-22',5,1),
('Martín','Cano','mcano@mail.com','36555111','2236001022','1992-08-09',6,1),
('Belén','Soria','bsoria@mail.com','40111333','2236001023','1999-01-19',7,1),
('Gonzalo','Montes','gmontes@mail.com','38911222','2236001024','1985-03-14',8,1),
('Nicolás','Bustos','nbustos@mail.com','37777888','2236001025','1994-06-27',1,1),
('Carolina','De Luca','cdl@mail.com','31111444','2236001026','2001-02-02',2,1),
('Ramiro','Ferreyra','rferreyra@mail.com','35555666','2236001027','1990-09-20',3,1),
('Ailén','Sosa','asosa@mail.com','32222555','2236001028','1996-11-11',4,1),
('Emanuel','Vera','evera@mail.com','34444333','2236001029','1983-10-30',5,1),
('Julieta','Funes','jfunes@mail.com','40222111','2236001030','1998-08-01',6,1);

---------------------------------------------------------
-- TURNOS (40 registros)
-- Estado ENUM: 1 Nuevo – 2 Reprogramado – 3 Cancelado – 4 Ausente – 5 Cerrado
---------------------------------------------------------
INSERT INTO Turno (IdPaciente, IdMedico, IdEspecialidad, Fecha, Hora, Estado, Observaciones)
VALUES
(1,1,1,'2025-03-10','09:00',1,'Control inicial'),
(2,2,2,'2025-03-10','10:00',1,NULL),
(3,3,3,'2025-03-11','11:30',5,'Consulta cerrada'),
(4,4,4,'2025-03-11','09:15',1,NULL),
(5,5,1,'2025-03-12','13:00',2,'Reprogramado por médico'),
(6,6,7,'2025-03-12','14:00',1,NULL),
(7,7,8,'2025-03-12','08:30',3,'Cancelado por paciente'),
(8,8,9,'2025-03-13','10:00',1,NULL),
(9,9,10,'2025-03-13','11:00',4,'Ausente'),
(10,10,6,'2025-03-13','12:00',1,NULL),
(11,11,4,'2025-03-14','09:00',1,NULL),
(12,12,7,'2025-03-14','10:00',5,'Cerrado'),
(13,1,2,'2025-03-14','11:00',1,NULL),
(14,2,5,'2025-03-14','12:00',2,'Reprogramado'),
(15,3,3,'2025-03-15','09:15',3,'Cancelado'),
(16,4,4,'2025-03-15','10:45',1,NULL),
(17,5,1,'2025-03-15','11:30',1,NULL),
(18,6,7,'2025-03-15','12:15',5,'Finalizado'),
(19,7,8,'2025-03-16','08:00',1,NULL),
(20,8,9,'2025-03-16','08:45',4,'No asistió'),
(1,10,6,'2025-03-17','10:00',1,NULL),
(2,11,4,'2025-03-17','11:00',1,NULL),
(3,12,7,'2025-03-17','12:00',5,'Finalizado'),
(4,9,10,'2025-03-17','13:30',2,'Reprogramado'),
(5,8,9,'2025-03-18','09:00',1,NULL),
(6,7,2,'2025-03-18','10:00',3,'Cancelado'),
(7,6,3,'2025-03-18','11:30',1,NULL),
(8,5,6,'2025-03-18','12:30',1,NULL),
(9,4,4,'2025-03-19','09:00',4,'Ausente'),
(10,3,3,'2025-03-19','09:45',1,NULL),
(11,2,2,'2025-03-19','10:30',5,'Cerrado'),
(12,1,1,'2025-03-19','11:15',1,NULL),
(13,10,6,'2025-03-20','08:00',1,NULL),
(14,11,4,'2025-03-20','09:15',3,'Cancelado'),
(15,12,7,'2025-03-20','10:30',1,NULL),
(16,9,10,'2025-03-20','11:45',1,NULL),
(17,8,9,'2025-03-21','12:00',1,NULL),
(18,7,8,'2025-03-21','13:00',1,NULL),
(19,6,7,'2025-03-21','14:00',5,'Finalizado'),
(20,5,1,'2025-03-21','15:00',1,NULL),
(21,3,3,'2025-03-22','09:00',1,NULL),
(22,4,4,'2025-03-22','10:15',5,'Cerrado'),
(23,5,1,'2025-03-22','11:30',3,'Cancelado'),
(24,6,7,'2025-03-22','12:45',1,NULL),
(25,7,8,'2025-03-23','08:00',1,NULL),
(26,8,9,'2025-03-23','08:45',4,'Ausente'),
(27,9,10,'2025-03-23','09:30',1,NULL),
(28,10,6,'2025-03-23','10:15',2,'Reprogramado por paciente'),
(29,11,4,'2025-03-24','09:00',1,NULL),
(30,12,7,'2025-03-24','10:00',5,'Finalizado'),
(21,1,1,'2025-03-24','11:00',1,NULL),
(22,2,2,'2025-03-24','12:00',1,NULL),
(23,3,3,'2025-03-25','09:00',3,'Cancelado'),
(24,4,4,'2025-03-25','10:30',1,NULL),
(25,5,1,'2025-03-25','11:15',1,NULL),
(26,6,7,'2025-03-25','12:00',4,'Ausente'),
(27,7,8,'2025-03-26','08:30',1,NULL),
(28,8,9,'2025-03-26','09:45',2,'Reprogramado'),
(29,9,10,'2025-03-26','11:00',1,NULL),
(30,10,6,'2025-03-26','12:15',1,NULL);

---------------------------------------------------------
-- USUARIOS (15 registros)
-- TipoUsuario: 1 Admin, 2 Recepcionista, 3 Medico, 4 Paciente
---------------------------------------------------------
INSERT INTO Usuario (Email, Nombre, Apellido, Pass, Tipo)
VALUES
('admin@clinica.com','Admin','Root','admin123',1),
('recepcion1@clinica.com','Laura','Ríos','r1',2),
('recepcion2@clinica.com','Marcos','Bello','r2',2),
('jperez@clinica.com','Juan','Pérez','m1',3),
('mgarcia@clinica.com','María','García','m2',3),
('clopez@clinica.com','Carlos','López','m3',3),
('atorres@clinica.com','Ana','Torres','m4',3),
('jmena@clinica.com','Javier','Mena','m5',3),
('admin@gmail.com','Santiago','Vanderstichel','admin',1),
('lm1@mail.com','Lucía','Martínez','p2',4),
('pr@mail.com','Pablo','Ramírez','p3',4),
('md@mail.com','Marina','Díaz','p4',4),
('js@mail.com','Jorge','Santos','p5',4),
('rf@mail.com','Rocío','Fernández','p6',4),
('eq@mail.com','Emilia','Quiroga','p7',4);
