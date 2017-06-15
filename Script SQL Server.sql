--########################################DDL
use master;
CREATE DATABASE DBVentas;
GO

use DBVentas;
GO
--Crear tablas
create table cargo 
(
    id_cargo int not null identity(1,1),
    id_empresa int, --fk??
    nombre varchar(50) not null,
    gid bit not null default(0),
    pos bit not null default(0),
    descripcion TEXT,
    constraint pk_cargo primary key(id_cargo)
);

create table clientes
(
	id_cliente int not null identity(1,1),
	id_empresa int not null, --fk*
	nombre varchar(25) not null,
	apellido varchar(25),
	direccion varchar(50),
	correo varchar(60),
	num_telefono varchar(9),
	num_dui varchar(10),
	num_nit varchar(20),
	estado int not null,
	constraint pk_cliente primary key(id_cliente)
);

create table compras
(
	id_compra int not null identity(1,1),
	correlativo int,
	id_proveedor int not null, --fk*
	fecha datetime not null,
	id_usuario varchar(10) not null, --fk*
	total decimal(10,2) not null,
	saldo decimal(10,2),
	constraint pk_compra primary key(id_compra)
); 
create table descuentos
(
	id_descuento int NOT NULL identity(1,1),
	valor decimal(10,2) NOT NULL default(1),
	descripcion text,
	id_empresa int not null, --fk
    constraint pk_descuento primary key(id_descuento)
);
create table detalle_pedidos
(
	id_detalle_pedido int NOT NULL identity(1,1),
	id_pedido int NOT NULL, --fk*
	cantidad int,
	id_producto int, --fk*
	fechaVen date,
);

create table detalle_ventas
(
    id_detalle_venta INT NOT NULL IDENTITY(1,1),
    id_venta INT NOT NULL, --fk*
    cantidad DECIMAL(10,5) NOT NULL DEFAULT(1),
    id_producto int NOT NULL, --fk*
	id_descuento int NOT NULL, --fk*
	id_tipoCliente int not null, --fk*
	precio_producto decimal(10,2) not null,
    constraint pk_detalleVenta primary key(id_detalle_venta)
);
create table documentos 
(
    id_documento int not null identity(1,1),
	id_empresa int not null, --fk*
    nombre varchar(50) not null,
    descripcion text,
    constraint pk_documento primary key(id_documento)
);
create table empleados
(
    id_empleado int NOT NULL identity(1,1),
    contrasennia varchar(50),
    nombre varchar(25) NOT NULL,
    apellidos varchar(25),
    direccion varchar(50),
    DUI varchar(9),
    id_cargo int not null, --fk*
    id_usuario varchar(10) NOT NULL, --fk*
    estado int NOT NULL,
    constraint pk_empleado primary key(id_empleado)
);
create table empresas
(
	id_empresa int not null identity(1,1),
	nombre varchar(30) not null,
	giro varchar(50) not null,
	nit varchar(30) not null,
	propietario text not null,
	nrc varchar(30) not null,
	pais varchar(30) not null,
	constraint pk_empresa primary key(id_empresa)
);
create table eventos
(
	id_eventos int not null identity(1,1),
	tipo int not null, --fk*
	fecha datetime not null,
	id_usuario varchar(10) not null, --fk*
	id_empleado int not null, --fk*
	constraint pk_eventos primary key(id_eventos)
);
create table inventarios
(
	id_inventarios int NOT NULL identity(1,1),
	id_usuario varchar(10) NOT NULL, --fk*
	cantidad int NOT NULL, 
	id_producto int NOT NULL, --fk*
	fechaVen datetime,
	constraint pk_inventarios primary key(id_inventarios)
);
create table mensajeria 
(
    id_mensaje int not null identity(1,1),
    id_emisor varchar(10) NOT NULL, --fk*
    id_receptor varchar(10) NOT NULL, --fk*
	fecha datetime not null,
    prioridad int default(2),
    mensaje text not null,
    constraint pk_mensaje primary key(id_mensaje)
);
create table pedidos
(
	id_pedido int NOT NULL identity(1,1),
	id_usuarioEmisor varchar(10), --fk*
	id_usuarioReceptor varchar(10), --fk*
	fecha varchar(30), 
	estado int NOT NULL default(0),
	id_empleado int, --fk*
	descripcion TEXT,
    constraint pk_pedido primary key(id_pedido)
);
create table precios 
(
	id_precio int not null identity(1,1),
	id_producto int not null, --fk*
	id_tipo int not null, --fk*
	id_empresa int not null, --fk*	
	precio_venta decimal(10,2) not null,
	constraint pk_precio primary key(id_precio)
);
create table productos
(
	id_producto int NOT NULL identity(1,1),
	nombre varchar(50) NOT NULL,
	descripcion text,
	id_proveedor int, --fk*
	precio_costo decimal(10,2) NOT NULL,
	estado int NOT NULL default(1),
	fraccion varchar(15),
	contenido int default(1),
    constraint pk_producto primary key(id_producto)
);
create table proveedores
(
	id_proveedor int not null identity(1,1),
	id_empresa int not null, --fk*
	nombre varchar(50) not null,
	direccion varchar(50),
	num_telefono varchar(9),
	correo varchar(60),
	nrc varchar(15),
	nit varchar(16), 
	estado int not null,
	constraint pk_proveedor primary key(id_proveedor)
);
create table tipo_eventos
(
	id_tipo int not null,
    nombre varchar(40),
    descripcion text,
    constraint pk_tipoE primary key(id_tipo)
);
create table tipos_clientes
(
	id_tipo int not null identity(1,1),
	id_empresa int not null, --fk*	
	nombre_tipo varchar(25) not null,	
	descripcion text,
	estado int not null,
	constraint pk_tipoC primary key(id_tipo)
);
CREATE TABLE tipos_usuarios
(
    id_tipo int not null,
    nombre varchar(40),
    descripcion text,
    constraint pk_tipoU primary key(id_tipo)
);
create table tiraje_documentos
(
    id_tiraje int NOT NULL identity(1,1),
    id_documento int not null, --fk*
    num_tiraje varchar(50) not null,
    fecha datetime NOT NULL,
    inicio int NOT NULL,
    fin int NOT NULL,
    id_usuario varchar(10) NOT NULL, --fk*
    corrActual int NOT NULL,
    descripcion text,
    constraint pk_tiraje primary key(id_tiraje)  
);
create table usuarios
(
	id_usuario varchar(10) not null,
	id_empresa int not null, --fk*
	id_tipo int not null, --fk*
	contrasennia varchar(30) not null,
	nombre varchar(50) not null,
	constraint pk_usuario primary key(id_usuario)
);
create table ventas
(
	id_venta int not null identity(1,1),
	id_usuario varchar(10) not null, --fk*
	id_cliente int not null, --fk*
	id_tiraje int not null, --fk*
	id_empleado int not null, --fk*
	corrActual int not null,
    estado int not null default(0),
    id_Documento int not null, --fk*
    constraint pk_venta primary key(id_venta)
);
GO
--Crear relaciones
alter table mensajeria add CONSTRAINT fk_mensajeria_usuarioA FOREIGN key(id_emisor) REFERENCES usuarios(id_usuario);
ALTER TABLE mensajeria add CONSTRAINT fk_mensajeria_usuarioB FOREIGN key(id_receptor) REFERENCES usuarios(id_usuario);
alter table eventos add constraint fk_evento_usuario foreign key(id_usuario) references usuarios(id_usuario);
alter table eventos add CONSTRAINT fk_evento_empleado FOREIGN key(id_empleado) REFERENCES empleados(id_empleado);
alter TABLE usuarios add CONSTRAINT fk_usuarios_empresas foreign key(id_empresa) REFERENCES empresas(id_empresa);
alter table usuarios add CONSTRAINT fk_usuarios_tiposU FOREIGN key(id_tipo) REFERENCES tipos_usuarios(id_tipo);
alter TABLE descuentos add CONSTRAINT fk_descuentos_empresas foreign key(id_empresa) REFERENCES empresas(id_empresa);
alter table compras add constraint fk_compra_proveedor foreign key(id_proveedor) references proveedores(id_proveedor);
alter table proveedores add constraint fk_proveedores_empresas FOREIGN key(id_empresa) references empresas(id_empresa);
alter table compras add constraint fk_compra_usuario foreign key(id_usuario) references usuarios(id_usuario);
alter table tipos_clientes add constraint fk_tiposC_empresa foreign key(id_empresa) references empresas(id_empresa);
alter table ventas add constraint fk_venta_usuario foreign key(id_usuario) references usuarios(id_usuario);
alter table ventas add constraint fk_venta_cliente foreign key(id_cliente) references clientes(id_cliente);
alter table ventas add constraint fk_venta_tiraje foreign key(id_tiraje) references tiraje_documentos(id_tiraje);
alter table detalle_ventas add constraint fk_detalleVenta_descuento foreign key(id_descuento) references descuentos(id_descuento);
alter table detalle_ventas add constraint fk_detalleVenta_venta foreign key(id_venta) references ventas(id_venta);
alter table detalle_ventas add constraint fk_detalleVenta_producto foreign key(id_producto) references productos(id_producto);
alter table detalle_ventas add constraint fk_detalleVenta_tipoC foreign key(id_tipoCliente) references tipos_clientes(id_tipo);
alter table empleados add constraint fk_empleado_usuario foreign key(id_usuario) references usuarios(id_usuario);
alter table productos add constraint fk_producto_proveedor foreign key(id_proveedor) references proveedores(id_proveedor);
alter table inventarios add constraint fk_inventario_usuario foreign key(id_usuario) references usuarios(id_usuario);
alter table inventarios add constraint fk_inventario_producto foreign key(id_producto) references productos(id_producto);
alter table pedidos add constraint fk_pedidos_usuario foreign key(id_usuarioEmisor) references usuarios(id_usuario);
alter table pedidos add constraint fk_pedido_usuario foreign key(id_usuarioReceptor) references usuarios(id_usuario);
alter table pedidos add constraint fk_pedidos_empleado foreign key(id_empleado) references empleados(id_empleado);
alter table detalle_pedidos add constraint fk_detallePedidos_pedido foreign key(id_pedido) references pedidos(id_pedido);
alter table detalle_pedidos add constraint fk_detallePedidos_producto foreign key(id_producto) references productos(id_producto);
alter table documentos add constraint fk_documentos_empresa foreign key(id_empresa) references empresas(id_empresa);
alter table tiraje_documentos add constraint fk_tiraje_usuario foreign key(id_usuario) references usuarios(id_usuario);
alter table tiraje_documentos add constraint fk_tiraje_documento foreign key(id_documento) references documentos(id_documento);
alter table precios add constraint fk_precio_preductos foreign key(id_producto) references productos(id_producto);
alter table precios add constraint fk_precio_tiposC foreign key(id_tipo) references tipos_clientes(id_tipo);
alter table precios add constraint fk_precios_empresa foreign key(id_empresa) references empresas(id_empresa);
alter table clientes add constraint fk_clientes_empresa foreign key(id_empresa) references empresas(id_empresa);
alter table ventas add constraint fk_ventas_documentos foreign key(id_Documento) references documentos(id_documento);
alter table empleados add constraint fk_empleados_cargos foreign key(id_cargo) references cargo(id_cargo);
alter table ventas add constraint fk_ventas_empleados foreign key(id_empleado) references empleados(id_empleado);
alter table eventos add constraint fk_evento_tipoEvento foreign key(tipo) references tipo_eventos(id_tipo);
GO
--Crear disparadores


--########################################DML
--Insertar datos de pruebas
INSERT INTO empresas(nombre, giro, nit, propietario, nrc, pais) VALUES('Distribuidora La Galac', 'venta de productos comerciales', '2514-125-215-25', 'Hiñigo Perez', '88800-1', 'El Salvador');
INSERT INTO tipos_usuarios(id_tipo,nombre,descripcion) VALUES(1,'Administrador','Usuario encargado de supervisar, editar, etc'),(2,'Punto de Venta','Usuario que gestionará los movimientos de cajaen una sucursal'),(3,'Gestor de Inventario','Usuario encargado del control de inventarios en la sucursal'),(4,'Usuario dado de baja','Usuario que ha sido dado de baja del sistema');
GO

INSERT INTO usuarios(id_usuario, id_empresa, id_tipo, contrasennia, nombre) VALUES('DistGalacA', 1, 1, HASHBYTES('MD5','contrasennia123'), 'Distribuidura GALAC Sucursal A'),('DistGalacB', 1, 2, HASHBYTES('MD5','contrasennia'), 'Distribuidura GALAC Sucursal A');
GO

INSERT INTO mensajeria(id_emisor, id_receptor, fecha,prioridad, mensaje) VALUES('DistGalacA','DistGalacB',getdate(),2,'Hola, Soy Goku.');
GO
INSERT INTO mensajeria(id_emisor, id_receptor, fecha,prioridad, mensaje) VALUES('DistGalacB','DistGalacA',getdate(),2,'Hola insecto, soy Vegueta, el principe de los Sayayin.');
GO
INSERT INTO descuentos VALUES(0, 'No hay descuento',1);
GO
GO
INSERT INTO proveedores(id_empresa, nombre, direccion, num_telefono, correo, nrc, nit, estado) VALUES(1, 'Proveedora del Futuro', 'Zona Rosa, San Salvador', '6225-4545', 'distdelfut@df.com', '88800-1', '1245-5252-2525-0', 1); 
GO
INSERT INTO clientes(id_empresa,nombre,apellido,direccion,correo,num_telefono,num_dui,num_nit,estado) VALUES(1, 'Juan Antonio', 'Perez Trejo', 'Av. La rosita,d sk', 'perez@gmail.com', '2525-5658', '4545858-1', '1245-5685-545-0',1); 
INSERT INTO tipos_clientes(id_empresa,nombre_tipo,descripcion,estado) VALUES(1, 'normal', 'cliente regular',1),(1, 'Mayorista', 'Cliente que lleva mas de 5 articulos por producto...',1);
GO
INSERT INTO productos(nombre,descripcion,id_proveedor,precio_costo,estado,fraccion,contenido) VALUES('Limpiox', 'botella con atomizador de 500ml',1, 2.25, 1, '', ''),('Clorox', 'Lejilla para aliviar esas penas',1, 2.05, 1, '', '');
GO
INSERT INTO inventarios(id_usuario,cantidad,id_producto,fechaVen) VALUES('DistGalacA',20,1, '12/12/21');
GO
INSERT INTO cargo(nombre,id_empresa,gid,pos,descripcion) VALUES('Cajero', 1, 0, 0, 'Cargo para el cajero...');
GO
INSERT INTO empleados(contrasennia,nombre,apellidos,direccion,DUI,id_cargo,id_usuario,estado) VALUES('passwordChan', 'Jose', 'Lobos', 'Calle las magnolias', '2345623-2', 1,'DistGalacA', 1);
GO

INSERT INTO pedidos(id_usuarioEmisor,id_usuarioReceptor,fecha,estado,id_empleado,descripcion) VALUES('DistGalacA','DistGalacB', getdate(), 0, 1, 'Descripcion...');
GO
INSERT INTO detalle_pedidos(id_pedido,cantidad,id_producto,fechaVen) VALUES(1, 10, 1, '12/12/21');
GO
INSERT INTO precios(id_producto,id_empresa,id_tipo,precio_venta) VALUES(1, 1, 1, 20.99),(2, 1, 1, 5.55);
GO
INSERT INTO documentos(id_empresa,nombre,descripcion) VALUES(1,'Ticket','Factura de consumidor final pequeña');
GO
INSERT INTO tiraje_documentos(id_documento,num_tiraje,fecha,inicio,fin,id_usuario,corrActual,descripcion) VALUES(1,'SMSNC 551515',getdate(),0,1500,'DistGalacA',777,'Tiraje...');
GO
INSERT INTO ventas(id_usuario, id_cliente, id_tiraje,id_empleado,corrActual,estado,id_Documento) VALUES('DistGalacA', 1, 1, 1, 1, 0, 1);
GO
INSERT INTO detalle_ventas(id_venta,cantidad,id_producto,id_descuento,id_tipoCliente,precio_producto) VALUES(1, 3, 1, 1,1,(select precio_venta from precios where id_producto = 1)),(1, 1, 1, 1,1,(select precio_venta from precios where id_producto = 2));
GO
INSERT INTO tipo_eventos(id_tipo,nombre,descripcion) VALUES(1,'Compra','Un empleado registro una compra'),(2,'Editar','un usuario actualizó datos');
GO
INSERT INTO eventos(tipo, fecha,id_usuario, id_empleado) VALUES(1, getdate(), 'DistGalacA',1);
