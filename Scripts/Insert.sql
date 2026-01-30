INSERT INTO  
Clientes ( 
Id, Nombre)  
VALUES  
(1, 'María González'), 
(2, 'Juan Pérez'); 

INSERT INTO  
Cuentas ( 
Id, ClienteId, Saldo, EsCuentaPrincipal)  
VALUES  
(101, 1, 157500.25, 1), -- cuenta principal de María 
(102, 1, 25300.75, 0), -- cuenta secundaria de María 
(201, 2, 80200.00, 1); -- cuenta principal de Juan 

INSERT INTO  
Tarjetas ( 
Id, CuentaId, Numero, EsPrincipal)  
VALUES  
(1001, 101, '4509-8701-2345-6789', 1), -- principal de María 
(1002, 101, '4509-8701-2345-6790', 0), -- secundaria de María 
(2001, 201, '4510-2301-3345-1244', 1); -- principal de Juan 


INSERT INTO  
Movimientos ( 
Id, TarjetaId, Fecha, Monto, Descripcion)  
VALUES  
(1, 1001, '2024-04-20', -9500.00, 'Compra supermercado'), 
(2, 1001, '2024-04-18', -12000.00, 'Pago seguro auto'), 
(3, 1001, '2024-04-15', -6500.00, 'Farmacia'), 
(4, 1001, '2024-04-12', -43000.00, 'Electrodoméstico'), 
(5, 1001, '2024-04-10', -1999.00, 'Spotify Premium'), 
(6, 1001, '2024-03-28', -1500.00, 'Carga SUBE'), 
(7, 1002, '2024-04-05', -3000.00, 'Compra secundaria'), 
(8, 2001, '2024-04-19', -7500.00, 'Cena en restaurante'), 
(9, 2001, '2024-04-17', -3000.00, 'Pago Netflix'), 
(10, 2001, '2024-04-14', -18000.00, 'Compra electro'), 
(11, 2001, '2024-04-11', -15000.00, 'Ropa'), 
(12, 2001, '2024-04-09', -2500.00, 'Heladería'); 