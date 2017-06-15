﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ServiCenter_Modelo;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }
    [WebMethod]
    public Pedidos agregarPedido(string id_usuario)
    {
        Pedidos_servicio ped = new Implementar_metodos_M();
        Pedidos pedi = new Pedidos();
        pedi.Id_usuarioEmisor = id_usuario;
        pedi.Fecha = DateTime.Now.Ticks.ToString();
        ped.crear_pedido(pedi);
        pedi.Id_pedido = ped.obtenerid(pedi.Id_usuarioEmisor, pedi.Fecha);
        return pedi;
    }

    [WebMethod]
    public int Agregar_usuario(string id_usuario, int id_empresa, int id_tipo, string contrasennia, string nombre)
    {
        Usuario_servicio obj = new Usuario_servicio_impl();
        if (id_tipo != 1 && id_tipo != 2)
            return 0;
        else
        {
            if (obj.existe_usuario(id_usuario.Trim()) == false)
            {
                Usuarios usuario = new Usuarios();
                usuario.Id_usuario = id_usuario.Trim();
                usuario.Id_empresa = id_empresa;
                usuario.Id_tipo = id_tipo;
                usuario.Contrasennia = contrasennia; //implementar md5 https://msdn.microsoft.com/es-es/library/system.security.cryptography.md5(v=vs.110).aspx
                usuario.Nombre = nombre;
                return (int)obj.agregar(usuario);
            }
            else
            {
                return 0;
            }
        }
    }
    [WebMethod]
    public List<Usuarios> Listar_usuarios(int id_empresa)
    {
        Usuario_servicio res = new Usuario_servicio_impl();
        return res.Listar_usuarios(id_empresa);
    }

    [WebMethod]
    public int actualizar_usuario(string id_usuario, string nombre, string contra_antigua, string contra_nueva)
    {
        Usuario_servicio act = new Usuario_servicio_impl();
        Usuarios usr = new Usuarios();
        usr.Id_usuario = id_usuario.Trim();
        usr.Nombre = nombre.Trim();
        usr.Contrasennia = contra_nueva.Trim();
        if (act.contraDiferente(contra_antigua, id_usuario) == true)//en proceso.
            return (int)act.actualizar(usr);
        else { return 0; }
    }

    [WebMethod]
    public int Agregar_cargo(string nombre, Boolean gid, Boolean pos, string descripcion, int id_empresa)
    {
        Cargo cargo = new Cargo();
        cargo.Id_empresa = id_empresa;
        cargo.Nombre = nombre.Trim();
        cargo.Gid = gid;
        cargo.Pos = pos;
        cargo.Descripcion = descripcion.Trim();
        Cargo_servicio objCargo = new Cargo_servicio_impl();
        return (int)objCargo.agregar(cargo);
    }

    [WebMethod]
    public List<Cargo> Listar_cargos(int id_empresa)
    {
        Cargo_servicio cargObj = new Cargo_servicio_impl();
        return cargObj.Listar_cargos(id_empresa);
    }

    [WebMethod]
    public int actualizar_cargo(int id_cargo, string nombre, Boolean gid, Boolean pos, string descripcion, int id_empresa)
    {
        Cargo car = new Cargo();
        car.Id_empresa = id_empresa;
        car.Id_cargo = id_cargo;
        car.Nombre = nombre.Trim();
        car.Gid = gid;
        car.Pos = pos;
        car.Descripcion = descripcion.Trim();
        Cargo_servicio objcar = new Cargo_servicio_impl();
        return (int)objcar.actualizar(car);
    }

    [WebMethod]
    public int Agregar_cliente(int id_empresa, string nombre, string apellido, string direccion, string correo, string num_telefono, string num_dui, string num_nit)
    {
        Clientes cliente = new Clientes();
        cliente.Id_empresa = id_empresa;
        cliente.Nombre = nombre.Trim();
        cliente.Apellido = apellido.Trim();
        cliente.Direccion = direccion.Trim();
        cliente.Correo = correo.Trim();
        cliente.Num_telefono = num_telefono.Trim();
        cliente.Num_dui = num_dui.Trim();
        cliente.Num_nit = num_nit.Trim();
        Cliente_servicio objCliente = new Cliente_servicio_impl();
        return (int)objCliente.agregar(cliente);
    }

    [WebMethod]
    public List<Clientes> Listar_clientes(int id_empresa)
    {
        Cliente_servicio objClient = new Cliente_servicio_impl();
        return objClient.Listar_clientes(id_empresa);
    }

    [WebMethod]
    public int actualizar_cliente(int id_cliente, string nombre, string apellido, string direccion, string correo, string num_telefono, string num_dui, string num_nit, int estado)
    {
        Clientes clien = new Clientes();
        clien.Id_cliente = id_cliente;
        clien.Nombre = nombre.Trim();
        clien.Apellido = apellido.Trim();
        clien.Direccion = direccion.Trim();
        clien.Correo = correo.Trim();
        clien.Num_telefono = num_telefono.Trim();
        clien.Num_dui = num_dui.Trim();
        clien.Num_nit = num_nit.Trim();
        clien.Estado = estado;
        Cliente_servicio objclien = new Cliente_servicio_impl();
        return (int)objclien.actualizar(clien);
    }

    [WebMethod]
    public int agregar_compras(int correlativo, int id_proveedor, DateTime fecha, string id_usuario, decimal total, decimal saldo)
    {
        Compras com = new Compras();
        com.Correlativo = correlativo;
        com.Id_proveedor = id_proveedor;
        com.Fecha = fecha;
        com.Id_usuario = id_usuario;
        com.Total = total;
        com.Saldo = saldo;
        Compras_servicio comp = new Compras_servicio_impl();
        return (int)comp.agregar_compras(com);
    }

    [WebMethod]
    public List<Compras> listar_compras()
    {
        Compras_servicio com = new Compras_servicio_impl();
        return com.Listar_compras();
    }
    [WebMethod]
    public int actualizar_compras(int idCompra, int Corr, DateTime fecha, decimal total, decimal saldo)
    {
        Compras comp = new Compras();
        comp.Id_compra = idCompra;
        comp.Correlativo = Corr;
        comp.Fecha = fecha;
        comp.Total = total;
        comp.Saldo = saldo;
        Compras_servicio com = new Compras_servicio_impl();
        return (int)com.actualizar_compras(comp);
    }
    [WebMethod]
    public int agregar_descuento(decimal valor, string descripcion, int id_empresa)
    {
        Descuentos des = new Descuentos();
        des.Valor = valor;
        des.Descripcion = descripcion;
        des.Id_empresa = id_empresa;
        Descuentos_servicio desc = new Descuentos_servicio_impl();
        return (int)desc.agregar_descuento(des);
    }

    [WebMethod]
    public List<Descuentos> Listar_descuentos(int id_empresa)
    {
        Descuentos_servicio des = new Descuentos_servicio_impl();
        return des.Listar_descuentos(id_empresa);
    }

    [WebMethod]
    public int actualizar_descuento(int id, decimal valor, string descripcion)
    {
        Descuentos des = new Descuentos();
        des.Id_descuento = id;
        des.Valor = valor;
        des.Descripcion = descripcion;
        Descuentos_servicio desc = new Descuentos_servicio_impl();
        return (int)desc.actualizar_descuento(des);
    }

    [WebMethod]
    public int Agregar_inventarios(string id_usuario, int cantidad, int id_producto, DateTime fechaVen, int emp)
    {
        Inventarios inventarios = new Inventarios();
        inventarios.Id_usuario = id_usuario.Trim();
        inventarios.Cantidad = cantidad;
        inventarios.Id_producto = id_producto;
        inventarios.FechaVen = fechaVen;
        Inventarios_servicio objInventarios = new Inventarios_servicio_impl();
        return (int)objInventarios.agregar(inventarios,id_usuario, emp);
    }

    [WebMethod]
    public List<Inventarios> Listar_inventarios(int id_empresa)
    {
        Inventarios_servicio objinvent = new Inventarios_servicio_impl();
        return objinvent.Listar_inventarios(id_empresa);
    }

    [WebMethod]
    public int actualizar_inventarios(int id_inventario, string id_usuario, int cantidad, int id_producto, DateTime fechaVen, int emp)
    {
        Inventarios inven = new Inventarios();
        inven.Id_inventarios = id_inventario;
        inven.Id_usuario = id_usuario.Trim();
        inven.Cantidad = cantidad;
        inven.Id_producto = id_producto;
        inven.FechaVen = fechaVen;

        Inventarios_servicio objinven = new Inventarios_servicio_impl();
        return (int)objinven.actualizar(inven, id_usuario, emp);
    }

    [WebMethod]
    public int Agregar_mensajeria(string id_emisor, string id_receptor, DateTime fecha, int prioridad, string mensaje, int emp)
    {
        Mensajeria mensajeria = new Mensajeria();
        mensajeria.Emisor = id_emisor.Trim();
        mensajeria.Receptor = id_receptor.Trim();
        mensajeria.Fecha = fecha;
        mensajeria.Prioridad = prioridad;
        mensajeria.Mensaje = mensaje;
        Mensajeria_service objMensajeria = new Mensajeria_service_impl();
        return (int)objMensajeria.agregar(mensajeria, id_emisor, emp);
    }

    [WebMethod]
    public List<Mensajeria> Listar_mensajeria(int id_empresa)
    {
        Mensajeria_service objmensajeria = new Mensajeria_service_impl();
        return objmensajeria.Listar_mensajeria(id_empresa);
    }

    [WebMethod]
    public int actualizar_mensajeria(int id_mensaje, string id_emisor, string id_receptor, DateTime fecha, int prioridad, string mensaje, int emp)
    {
        Mensajeria men = new Mensajeria();
        men.Id_mensaje = id_mensaje;
        men.Emisor = id_emisor.Trim();
        men.Receptor = id_receptor.Trim(); ;
        men.Fecha = fecha;
        men.Prioridad = prioridad;
        men.Mensaje = mensaje;
        Mensajeria_service objmen = new Mensajeria_service_impl();
        return (int)objmen.actualizar(men, id_emisor, emp);
    }





    [WebMethod]
    public int Agregar_pedidos(string id_emisor, string id_receptor, int estado, int id_empleado, string descripcion)
    {
        Pedidos pedidos = new Pedidos();
        pedidos.Id_usuarioEmisor = id_emisor.Trim();
        pedidos.Id_usuarioReceptor = id_receptor.Trim();
        pedidos.Fecha = DateTime.Now.ToString();
        pedidos.Estado = estado;
        pedidos.Id_empleado = id_empleado;
        pedidos.Descripcion = descripcion;
        Pedidos_servicio objPedidos = new Implementar_metodos_M();
        return (int)objPedidos.agregar(pedidos);
    }

    [WebMethod]
    public List<Pedidos> Listar_pedidos(int id_empresa)
    {
        Pedidos_servicio objPedidos = new Implementar_metodos_M();
        return objPedidos.Listar_pedidos(id_empresa);
    }


    [WebMethod]
    public int actualizar_pedidos(int id_pedido, string id_emisor, string id_receptor, int estado, int id_empleado, string descripcion)
    {
        Pedidos pedid = new Pedidos();
        pedid.Id_pedido = id_pedido;
        pedid.Id_usuarioEmisor = id_emisor.Trim();
        pedid.Id_usuarioReceptor = id_receptor.Trim();
        pedid.Fecha = DateTime.Now.ToString();
        pedid.Estado = estado;
        pedid.Id_empleado = id_empleado;
        pedid.Descripcion = descripcion;
        Pedidos_servicio objpedid = new Implementar_metodos_M();
        return (int)objpedid.actualizar(pedid);
    }

  //Metodos de la tabla Precios
    [WebMethod]
    public int Agregar_precios(int id_producto, int id_tipo, int id_empresa, decimal precioVenta)
    {
        Precios precios = new Precios();
        precios.Id_producto = id_producto;
        precios.Id_tipo = id_tipo;
        precios.Id_empresa = id_empresa;
        precios.Precio_venta = precioVenta;
        Precios_service objPrecios = new Precios_service_impl();
        return (int)objPrecios.agregar(precios);
    }

    [WebMethod]
    public List<Precios> Listar_precios(int id_producto)
    {
        Precios precio = new Precios();
        precio.Id_producto = id_producto;
        Precios_service objPrecios = new Precios_service_impl();
        return objPrecios.Listar_precios(precio);
    }


    [WebMethod]
    public int actualizar_precios(int id_precio, decimal precioVenta)
    {
        Precios prec = new Precios();
        prec.Id_precio = id_precio;
        prec.Precio_venta = precioVenta;
        Precios_service objprec = new Precios_service_impl();
        return (int)objprec.actualizar(prec);
    }
    
     //Metodos de la tabla Productos

    [WebMethod]
    public int Agregar_productos(string id_usuario, string nombre, string descripcion, int id_proveedor, decimal precio_costo, int estado, string fraccion, int contenido)
    {
        Productos productos = new Productos();
        productos.Nombre = nombre;
        productos.Descripcion = descripcion;
        productos.Id_proveedor = id_proveedor;
        productos.Precio_costo = precio_costo;
        productos.Estado = estado;
        productos.Fraccion = fraccion;
        productos.Contenido = contenido;
        Productos_service objProductos = new Productos_service_impl();
        return (int)objProductos.agregar(productos, id_usuario);
    }

    [WebMethod]
    public List<Productos> Listar_productos(int id_empresa)
    {
        Productos_service objProducto = new Productos_service_impl();
        return objProducto.Listar_productos(id_empresa);
    }


    [WebMethod]
    public int actualizar_productos(string id_usuario, int id_producto, string nombre, string descripcion, int id_proveedor, decimal precio_costo, int estado, string fraccion, int contenido)
    {
        Productos product = new Productos();
        product.Id_producto = id_producto;
        product.Nombre = nombre;
        product.Descripcion = descripcion;
        product.Id_proveedor = id_proveedor;
        product.Precio_costo = precio_costo;
        product.Estado = estado;
        product.Fraccion = fraccion;
        product.Contenido = contenido;
        Productos_service objproduct = new Productos_service_impl();
        return (int)objproduct.actualizar(product, id_usuario);
    }



    //Metodos de la tabla Proveedores

    [WebMethod]
    public int Agregar_proveedor(int id_empresa, string id_usuario, string nombre, string direccion, string num_telefono, string correo, string nrc, string nit)
    {
        Proveedores proveedor = new Proveedores();
        proveedor.Id_empresa = id_empresa;
        proveedor.Nombre = nombre;
        proveedor.Direccion = direccion;
        proveedor.Num_telefono = num_telefono;
        proveedor.Correo = correo;
        proveedor.Nrc = nrc;
        proveedor.Nit = nit;
        Proveedores_service objProveedor = new Proveedores_service_impl();
        return (int)objProveedor.agregar(proveedor, id_usuario);
    }

    [WebMethod]
    public List<Proveedores> Listar_proveedores(int id_empresa)
    {
        Proveedores_service objProveedor = new Proveedores_service_impl();
        return objProveedor.Listar_proveedores(id_empresa);
    }


    [WebMethod]
    public int actualizar_proveedores(int id_proveedor, int id_empresa, string id_usuario, string nombre, string direccion, string num_telefono, string correo, string nrc, string nit, int estado)
    {
        Proveedores proveedor = new Proveedores();
        proveedor.Id_proveedor = id_proveedor;
        proveedor.Id_empresa = id_empresa;
        proveedor.Nombre = nombre;
        proveedor.Direccion = direccion;
        proveedor.Num_telefono = num_telefono;
        proveedor.Correo = correo;
        proveedor.Nrc = nrc;
        proveedor.Nit = nit;
        proveedor.Estado = estado;
        Proveedores_service objprovee = new Proveedores_service_impl();
        return (int)objprovee.actualizar(proveedor, id_usuario);
    }



    //WebMethod's de Tipos de clientes

    [WebMethod]
    public int Agregar_tipoCliente(int id_empresa, string nombre, string descripcion, string id_usuario, int estado)
    {
        Tipos_clientes tCliente = new Tipos_clientes();
        tCliente.Id_empresa = id_empresa;
        tCliente.NombreTipo = nombre;
        tCliente.Descripcion = descripcion;
        tCliente.Estado = estado;
        TiposCliente_Service objTipoCliente = new TiposCliente_Service_impl();
        return (int)objTipoCliente.agregar(tCliente, id_usuario);
    }

    [WebMethod]
    public List<Tipos_clientes> Listar_tipoClientes(int id_empresa)
    {
        TiposCliente_Service objTipoClientes = new TiposCliente_Service_impl();
        return objTipoClientes.Listar_tiposClientes(id_empresa);
    }


    [WebMethod]
    public int actualizar_tiposClientes(String id_usuario, int id_tipo, int id_empresa, string nombre, string descripcion, int estado)
    {
        Tipos_clientes tCliente = new Tipos_clientes();
        tCliente.Id_empresa = id_empresa;
        tCliente.Id_tipo = id_tipo;
        tCliente.NombreTipo = nombre;
        tCliente.Descripcion = descripcion;
        tCliente.Estado = estado;
        TiposCliente_Service objTClien = new TiposCliente_Service_impl();
        return (int)objTClien.actualizar(tCliente, id_usuario);
    }


    //Web Methods de empleados


    [WebMethod]
    public int Agregar_empleado(string nombre, string apellidos, string direccion, string dui, int id_cargo, string id_usuario)
    {
        Empleados emp = new Empleados();
        emp.Nombre = nombre;
        emp.Apellidos = apellidos;
        emp.Direccion = direccion;
        emp.Dui = dui;
        emp.Id_cargo = id_cargo;
        emp.Id_usuario = id_usuario;
        Empleado_service objEmp = new Empleado_service_impl();
        return (int)objEmp.agregar(emp);
    }

    [WebMethod]
    public List<Empleados> Listar_empleados(int id_empresa)
    {
        Empleado_service objEmp = new Empleado_service_impl();
        return objEmp.Listar_empleados(id_empresa);
    }


    [WebMethod]
    public int actualizar_empleado(int id_empleado, string nombre, string apellidos, string direccion, string dui, int id_cargo, string id_usuario, int estado)
    {
        Empleados emp = new Empleados();
        emp.Id_empleado = id_empleado;
        emp.Nombre = nombre;
        emp.Apellidos = apellidos;
        emp.Direccion = direccion;
        emp.Dui = dui;
        emp.Id_cargo = id_cargo;
        emp.Id_usuario = id_usuario;
        emp.Estado = estado;
        Empleado_service objEmpleado = new Empleado_service_impl();
        return (int)objEmpleado.actualizar(emp);
    }



    //WebMethod del Login

    [WebMethod]
    public Usuarios login(string id_usuario, string contrasennia)
    {
        Usuario_servicio userLogin = new Usuario_servicio_impl();
        return userLogin.login(id_usuario, contrasennia);
    }
    [WebMethod]
    public List<Ventas> Listar_ventasPree(string id_usuario, int estado) //Modificar esta wea
    {
        Ventas_servicio ven = new Implementar_metodos_M();
        return ven.Listar_ventasPree(id_usuario, estado);
    }
    [WebMethod]
    public List<Detalle_ventas> Listar_detalleVentas(string id_usuario, int estado)
    {
        List<Detalle_ventas> ls = new List<Detalle_ventas>();
        return ls;
    }
    [WebMethod]
    public Decimal retornarPrecioPro(int id_producto)
    {
        Precios_service precios = new Precios_service_impl();
        return precios.retornarprecioventa(id_producto);
    }
    [WebMethod]
    public int Agregar_venta(string id_usuario, int id_cliente, int id_tiraje, int id_empleado, int corrActual, int estado, int id_documento)
    {
        Ventas ventas = new Ventas();
        ventas.Id_usuario = id_usuario;
        ventas.Id_cliente = id_cliente;
        ventas.Id_tiraje = id_tiraje;
        ventas.Id_empleado = id_empleado;
        ventas.CorrActual = corrActual;
        ventas.Estado = estado;
        ventas.Id_Documento = id_documento;
        Ventas_servicio ven = new Implementar_metodos_M();
        return ven.Agregar_venta(ventas);
    }
    /*[WebMethod]
    public int Agregar_detalleVentas(int id_venta, int id_producto, decimal cantidad, int id_descuento, int tipo_cliente, decimal precio_producto)
    {

    }*/
    [WebMethod]
    public Tiraje_documentos Listar_tiraje(string id_usuario, int id_documento)
    {
        Tiraje_documentos tiraje = new Tiraje_documentos();
        return tiraje;
    }
    [WebMethod]
    public List<Documentos> Listar_documentos(int id_empresa)
    {
        Documentos_servicio docu = new Documentos_servicio_impl();
        return docu.listar_documentos(id_empresa);
    }


}



