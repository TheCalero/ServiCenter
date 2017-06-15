***UNIVERSIDAD CAPITÁN GENERAL GERARDO BARRIOS ***
***FACULTAD DE CIENCIA Y TECNOLOGÍA ***
***INGENIERÍA EN SISTEMAS Y REDES COMPUTACIONALES ***
INTEGRANTES: 	
MARVIN JOSUÉ CALERO REQUENO; SMIS022216 
ERICK ANTONIO FLORES CHÁVEZ; SMIS037916
REINA ISABEL ACOSTA DÍAZ; SMIS000716

***Sistema de Ventas***
Nombre: 
ServiCenter
 
Detalles del producto: 
Sistema web de gestión de ventas y facturación, admite la gestión de productos y servicios con periodicidad de pagos. Que es consumido por una aplicación de escritorio que funcione también de forma offline con una base de datos embebida que sincronice con el web service cuando haya Internet. Basado en cuatro usuarios: Maestro, Administrador, Gestor de Inventarios y POS (Point of Sale), puede haber más de un usuario por tipo, menos del tipo “Maestro”, que sólo será uno por empresa. Que admita la gestión de más de un almacén y sucursales, y presente información de las ventas categorizada para su análisis por el usuario Administrador.
 
Análisis de Requerimientos:
Usuarios: 
Maestro (nivel 0):
Añade usuarios.
Modifica usuarios.
Elimina Usuarios.
Único para cada empresa.


Administrador (nivel 1): 
Puede ver las acciones de cada usuario por debajo de él. 
Puede obtener cualquier tipo de reportes.
Registra los productos.
Establece los precios de los productos (Costo y Venta).
Gestiona promociones por compras y descuentos.
Gestiona proveedores (Edita, elimina, registra)
Facturas de compras (Canceladas, pendientes, parcial)
Debe poder ver el inventario de todos los almacenes y sucursales
Puede ver el registro de todas las ventas
Puede ver el registro de todos los clientes.
Gestiona correlativos de comprobantes para todas las sucursales
Diseña formatos de factura para las sucursales.
 
 
Gestor de Inventarios (nivel 2): 
Hace ingreso de productos al almacén 
Recibe pedidos de las sucursales (De los usuarios POS)
Controla el estado de esos pedidos (En proceso, despachado)
Genera documentos impresos:
Ordenes de pedido (Corresponde al estado: en proceso)
Notas de Envío (Corresponde al estado: despachado).
Puede ver los inventarios de todas las sucursales 


POS (nivel 2): 
Representa una sucursal, un vendedor móvil o cualquier unidad que genere ventas a la empresa.
Gestión de estado de pedidos (Enviado, Recibido).
Registra contratos de servicios (Se genera una venta según la periodicidad que se establezca) 
Registra las ventas.
Imprime comprobantes:
Factura de Crédito Fiscal
Factura de Consumidor Final
Factura simplificada o Ticket 
Gestiona el estado de las ventas (Contado, crédito)
Registra clientes.
Modifica los clientes (No elimina).
Ingresa “Gastos de Venta”
Genera reporte diario

Justificación:
Pensando en las necesidades que las empresas tienen y, para sopesar la carga laboral, con perspectivas a largo plazo, el software en cuestión debe solventar las necesidad que una pequeña/mediana empresa enfrenta en su productividad, agilidad, seguridad y fiabilidad en el manejo de información de ventas. Se pretende tomar en consideración los detalles más importantes a la hora de realizar análisis de mercado, generando reportes que ayuden a conocer la información relevante de una forma resumida. Además, se tomará en cuenta un control riguroso en el manejo de los usuarios (no todos los empleados serán usuarios, por lo tanto, se excluirá el manejo de salarios en éste sistema), ayudando a mantener un control en el nivel de acceso en la información y el “poder” que éste tendrá dentro del sistema; incluso se tomará en cuenta la comunicación entre estos para garantizar la cooperación entre pares.
