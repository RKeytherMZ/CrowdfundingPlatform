-- Insertar estudiantes
INSERT INTO Estudiantes (Nombre, Correo, Carrera, Institucion)
VALUES
('Juan Perez', 'juan.perez@example.com', 'Ingeniería de Sistemas', 'ITLA'),
('Ana Gómez', 'ana.gomez@example.com', 'Arquitectura', 'UASD');

-- Insertar proyectos
INSERT INTO Proyectos (Titulo, Descripcion, MetaFinanciera, MontoRecaudado, FechaCreacion, EstudianteId)
VALUES
('Robot Automatizado', 'Robot para tareas de laboratorio', 2000, 500, '2025-06-01', 1),
('App Educativa', 'Aplicación móvil para aprender idiomas', 1500, 300, '2025-06-05', 2);

-- Insertar donaciones
INSERT INTO Donaciones (Donante, Monto, Fecha, ProyectoId)
VALUES
('Carlos Rodríguez', 100, '2025-06-10', 1),
('María Fernández', 50, '2025-06-12', 2);
