--El stored procedure `sp_GetResumenCliente` en SQL Server 2019 está diseñado para devolver, dado un `ClienteId`, el **saldo de la cuenta principal** del cliente y los **últimos 5 movimientos de su 
--tarjeta principal**. Primero declara variables para almacenar internamente el ID de la cuenta y de la tarjeta principal. Luego busca la cuenta principal del cliente y obtiene su saldo; a continuación 
--identifica la tarjeta principal asociada a esa cuenta y devuelve sus cinco movimientos más recientes ordenados por fecha descendente. Si no existe tarjeta principal, retorna un conjunto vacío. Todo 
--el procedimiento está envuelto en un bloque `TRY/CATCH` que captura cualquier error de ejecución y lo lanza como excepción técnica, asegurando que la lógica de negocio quede centralizada en la base 
--de datos y que los casos de error o ausencia de datos se manejen correctamente.


CREATE OR ALTER PROCEDURE sp_GetResumenCliente
(
    @ClienteId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        DECLARE @CuentaId INT;
        DECLARE @TarjetaId INT;

        -- ==========================
        -- Cuenta principal
        -- ==========================
        SELECT 
            @CuentaId = c.Id
        FROM Cuentas c
        WHERE 
            c.ClienteId = @ClienteId
            AND c.EsCuentaPrincipal = 1;

        -- ==========================
        -- Saldo
        -- ==========================
        SELECT 
            c.Saldo AS SaldoCuentaPrincipal
        FROM Cuentas c
        WHERE c.Id = @CuentaId;

        -- ==========================
        -- Tarjeta principal
        -- ==========================
        SELECT 
            @TarjetaId = t.Id
        FROM Tarjetas t
        WHERE 
            t.CuentaId = @CuentaId
            AND t.EsPrincipal = 1;

        -- ==========================
        -- Movimientos
        -- ==========================
        IF @TarjetaId IS NOT NULL
        BEGIN
            SELECT TOP 5
                m.Fecha,
                m.Monto,
                m.Descripcion
            FROM Movimientos m
            WHERE m.TarjetaId = @TarjetaId
            ORDER BY m.Fecha DESC;
        END
        ELSE
        BEGIN
            SELECT 
                CAST(NULL AS DATETIME) AS Fecha,
                CAST(NULL AS DECIMAL(18,2)) AS Monto,
                CAST(NULL AS NVARCHAR(200)) AS Descripcion
            WHERE 1 = 0;
        END

    END TRY
    BEGIN CATCH

        -- error técnico
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (
            @ErrorMessage,
            @ErrorSeverity,
            @ErrorState
        );

    END CATCH
END;
GO
