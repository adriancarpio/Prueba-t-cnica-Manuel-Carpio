CREATE DATABASE M-CARPIO-BD;

CREATE TABLE Evento (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaEvento DATETIME NOT NULL,
    LugarEvento NVARCHAR(255) NOT NULL,
    DescripcionEvento NVARCHAR(MAX) NOT NULL,
    Precio DECIMAL(18, 2) NOT NULL
);

ALTER TABLE Evento ADD Eliminado BIT DEFAULT 0;

INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-01', 'Lugar A', 'Descripción del Evento A', 100.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-02', 'Lugar B', 'Descripción del Evento B', 150.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-03', 'Lugar C', 'Descripción del Evento C', 200.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-04', 'Lugar D', 'Descripción del Evento D', 250.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-05', 'Lugar E', 'Descripción del Evento E', 300.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-06', 'Lugar F', 'Descripción del Evento F', 350.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-07', 'Lugar G', 'Descripción del Evento G', 400.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-08', 'Lugar H', 'Descripción del Evento H', 450.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-09', 'Lugar I', 'Descripción del Evento I', 500.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-10', 'Lugar J', 'Descripción del Evento J', 550.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-11', 'Lugar K', 'Descripción del Evento K', 600.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-12', 'Lugar L', 'Descripción del Evento L', 650.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-13', 'Lugar M', 'Descripción del Evento M', 700.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-14', 'Lugar N', 'Descripción del Evento N', 750.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-15', 'Lugar O', 'Descripción del Evento O', 800.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-16', 'Lugar P', 'Descripción del Evento P', 850.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-17', 'Lugar Q', 'Descripción del Evento Q', 900.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-18', 'Lugar R', 'Descripción del Evento R', 950.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-19', 'Lugar S', 'Descripción del Evento S', 1000.00, 0);
INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado) VALUES ('2024-08-20', 'Lugar T', 'Descripción del Evento T', 1050.00, 0);




CREATE PROCEDURE GestionarEvento
    @Operacion NVARCHAR(50),
    @Id INT = NULL,
    @FechaEvento DATETIME = NULL,
    @LugarEvento NVARCHAR(255) = NULL,
    @DescripcionEvento NVARCHAR(MAX) = NULL,
    @Precio DECIMAL(18, 2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Operacion = 'Registrar'
    BEGIN
        INSERT INTO Evento (FechaEvento, LugarEvento, DescripcionEvento, Precio, Eliminado)
        VALUES (@FechaEvento, @LugarEvento, @DescripcionEvento, @Precio, 0);
    END
    ELSE IF @Operacion = 'Eliminar'
    BEGIN
        UPDATE Evento
        SET Eliminado = 1
        WHERE Id = @Id;
    END
    ELSE IF @Operacion = 'Modificar'
    BEGIN
        UPDATE Evento
        SET FechaEvento = @FechaEvento,
            LugarEvento = @LugarEvento,
            DescripcionEvento = @DescripcionEvento,
            Precio = @Precio
        WHERE Id = @Id AND Eliminado = 0;
    END
    ELSE IF @Operacion = 'Consultar'
    BEGIN
        SELECT Id, FechaEvento, LugarEvento, DescripcionEvento, Precio
        FROM Evento
        WHERE Id = @Id AND Eliminado = 0;
    END
    ELSE IF @Operacion = 'ConsultarTodos'
    BEGIN
        SELECT Id, FechaEvento, LugarEvento, DescripcionEvento, Precio
        FROM Evento
        WHERE Eliminado = 0;
    END
    ELSE
    BEGIN
        RAISERROR('Operación no válida', 16, 1);
    END
END;

EXEC GestionarEvento 'Registrar', NULL, '2024-08-01', 'Lugar A', 'Descripción del Evento A', 100.00;

EXEC GestionarEvento 'Modificar', 21, '2024-08-02', 'Lugar B', 'Descripción del Evento B', 150.00;

EXEC GestionarEvento 'Consultar', 21;

EXEC GestionarEvento 'ConsultarTodos';

EXEC GestionarEvento 'Eliminar', 21;

