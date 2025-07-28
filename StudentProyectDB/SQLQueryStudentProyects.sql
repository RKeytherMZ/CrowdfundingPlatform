-- Insertar estudiantes
INSERT INTO Estudiantes (Nombre, Correo, Carrera, Institucion)
VALUES
('Juan Perez', 'juan.perez@example.com', 'Ingenier�a de Sistemas', 'ITLA'),
('Ana G�mez', 'ana.gomez@example.com', 'Arquitectura', 'UASD');

-- Insertar proyectos
INSERT INTO Proyectos (Titulo, Descripcion, MetaFinanciera, MontoRecaudado, FechaCreacion, EstudianteId)
VALUES
('Robot Automatizado', 'Robot para tareas de laboratorio', 2000, 500, '2025-06-01', 1),
('App Educativa', 'Aplicaci�n m�vil para aprender idiomas', 1500, 300, '2025-06-05', 2);

-- Insertar donaciones
INSERT INTO Donaciones (Donante, Monto, Fecha, ProyectoId)
VALUES
('Carlos Rodr�guez', 100, '2025-06-10', 1),
('Mar�a Fern�ndez', 50, '2025-06-12', 2);
