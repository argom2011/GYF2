IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'GYF') --Crear base solo si no existe
BEGIN
    CREATE DATABASE GYF;
    PRINT 'Base de datos GYF creada';
END
ELSE
BEGIN
    PRINT 'La base de datos GYF ya existe';
END
GO

USE GYF;
GO

--Crear tablas solo si no existen

IF NOT EXISTS (
    SELECT 1 FROM sys.tables WHERE name = 'Clientes'
)
BEGIN
    CREATE TABLE Clientes (
        Id INT NOT NULL PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL
    );

    PRINT 'Tabla Clientes creada';
END
ELSE
    PRINT 'Tabla Clientes ya existe';
GO



IF NOT EXISTS (
    SELECT 1 FROM sys.tables WHERE name = 'Cuentas'
)
BEGIN
    CREATE TABLE Cuentas (
        Id INT NOT NULL PRIMARY KEY,
        ClienteId INT NOT NULL,
        Saldo DECIMAL(18,2) NOT NULL,
        EsCuentaPrincipal BIT NOT NULL,

        CONSTRAINT FK_Cuentas_Clientes
            FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
    );

    PRINT 'Tabla Cuentas creada';
END
ELSE
    PRINT 'Tabla Cuentas ya existe';
GO



IF NOT EXISTS (
    SELECT 1 FROM sys.tables WHERE name = 'Tarjetas'
)
BEGIN
    CREATE TABLE Tarjetas (
        Id INT NOT NULL PRIMARY KEY,
        CuentaId INT NOT NULL,
        Numero NVARCHAR(30) NOT NULL,
        EsPrincipal BIT NOT NULL,

        CONSTRAINT FK_Tarjetas_Cuentas
            FOREIGN KEY (CuentaId) REFERENCES Cuentas(Id)
    );

    PRINT 'Tabla Tarjetas creada';
END
ELSE
    PRINT 'Tabla Tarjetas ya existe';
GO


IF NOT EXISTS (
    SELECT 1 FROM sys.tables WHERE name = 'Movimientos'
)
BEGIN
    CREATE TABLE Movimientos (
        Id INT NOT NULL PRIMARY KEY,
        TarjetaId INT NOT NULL,
        Fecha DATETIME NOT NULL,
        Monto DECIMAL(18,2) NOT NULL,
        Descripcion NVARCHAR(200) NOT NULL,

        CONSTRAINT FK_Movimientos_Tarjetas
            FOREIGN KEY (TarjetaId) REFERENCES Tarjetas(Id)
    );

    PRINT 'Tabla Movimientos creada';
END
ELSE
    PRINT 'Tabla Movimientos ya existe';
GO
