using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Implementar_metodos_M
/// </summary>
public class Implementar_metodos_M : Pedidos_servicio, Ventas_servicio
{
    Conexion conect = null;
    //Run
    public int crear_pedido(Pedidos pedido)
    {
        int i = 0;
        conect = new Conexion();
        SqlTransaction tran;
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        tran = conect.abrir_conexion().BeginTransaction("simpleTransicion");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.Transaction = tran;
            command.CommandText = "insert into pedidos(id_usuarioEmisor,fecha) values(@user,@fecha)";
            command.Parameters.Add("@user", SqlDbType.VarChar, 10);
            command.Parameters["@user"].Value = pedido.Id_usuarioEmisor;
            command.Parameters["@user"].Direction = ParameterDirection.Input;
            command.Parameters.Add("@fecha", SqlDbType.VarChar, 30);
            command.Parameters["@fecha"].Value = pedido.Fecha;
            command.Parameters["@fecha"].Direction = ParameterDirection.Input;
            i = command.ExecuteNonQuery();
            tran.Commit();
        }
        catch (Exception e)
        {
            tran.Rollback();
        }
        finally
        {
            conect.cerrar_conexion();
        }
        return i;
    }
    //Run
    public int obtenerid(string id_usuarioEmisor, string fecha)
    {
        int i = 0;
        conect = new Conexion();
        string select = "select max(id_pedido) as id_pedido from pedidos where id_usuarioEmisor = '" + id_usuarioEmisor + "' and fecha = '" + fecha + "'";
        SqlCommand selectCommand = new SqlCommand(select, conect.abrir_conexion());
        selectCommand.CommandType = CommandType.Text;
        try
        {
            conect.abrir_conexion();
            SqlDataReader rowReader = selectCommand.ExecuteReader();
            if (rowReader.Read())
            {
                i = rowReader.GetInt32(0);
            }
        }
        catch (Exception e)
        {
            ;
        }
        finally
        {
            conect.cerrar_conexion();
        }
        return i;
    }

    public int Agregar_venta(Ventas venta)
    {
        int i = 0;
        conect = new Conexion();
        SqlTransaction tran;
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        tran = conect.abrir_conexion().BeginTransaction("simpleTransicion");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.Transaction = tran;
            command.CommandText = "INSERT INTO ventas(id_usuario, id_cliente,id_tiraje,id_empleado,corrActual,estado,id_documento) VALUES(@user,@clie,@tiraje,@emple,@corr,@est,@doc);SELECT SCOPE_IDENTITY();";
            command.Parameters.Add("@user", SqlDbType.VarChar, 10);
            command.Parameters["@user"].Value = venta.Id_usuario;
            command.Parameters.Add("@clie", SqlDbType.Int);
            command.Parameters["@clie"].Value = venta.Id_cliente;
            command.Parameters.Add("@tiraje", SqlDbType.Int);
            command.Parameters["@tiraje"].Value = venta.Id_tiraje;
            command.Parameters.Add("@emple", SqlDbType.Int);
            command.Parameters["@emple"].Value = venta.Id_empleado;
            command.Parameters.Add("@corr", SqlDbType.Int);
            command.Parameters["@corr"].Value = venta.CorrActual;
            command.Parameters.Add("@est", SqlDbType.Int);
            command.Parameters["@est"].Value = venta.Estado;
            command.Parameters.Add("@doc", SqlDbType.Int);
            command.Parameters["@doc"].Value = venta.Id_Documento;
            i = int.Parse(command.ExecuteScalar().ToString());
            tran.Commit();
        }
        catch (Exception e)
        {
            tran.Rollback();
        }
        finally
        {
            conect.cerrar_conexion();
        }
        return i;
    }

    public int Agregar_detalleVentas(Detalle_ventas ventadetails)
    {
        int i = 0;
        conect = new Conexion();
        SqlTransaction tran;
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        tran = conect.abrir_conexion().BeginTransaction("simpleTransicion");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.Transaction = tran;
            command.CommandText = "INSERT INTO detalle_ventas(id_venta, cantidad,id_producto,id_descuento,id_tipoClientes,precio_producto) VALUES(@venta,@cant,@pro,@des,@tipc,@prep)";
            command.Parameters.Add("@venta", SqlDbType.Int);
            command.Parameters["@venta"].Value = ventadetails.Id_venta;
            command.Parameters.Add("@cant", SqlDbType.Decimal);
            command.Parameters["@cant"].Value = ventadetails.Cantidad;
            command.Parameters.Add("@pro", SqlDbType.Int);
            command.Parameters["@pro"].Value = ventadetails.Id_producto;
            command.Parameters.Add("@des", SqlDbType.Int);
            command.Parameters["@des"].Value = ventadetails.Id_descuento;
            command.Parameters.Add("@tipc", SqlDbType.Int);
            command.Parameters["@tipc"].Value = ventadetails.Id_tipoCliente;
            command.Parameters.Add("@prep", SqlDbType.Int);
            command.Parameters["@prep"].Value = ventadetails.Precio_producto;
            command.ExecuteNonQuery();
            tran.Commit();
            i = 1;
        }
        catch (Exception e)
        {
            tran.Rollback();
        }
        finally
        {
            conect.cerrar_conexion();
        }
        return i;

    }

    //No run
    public int agregar(Pedidos pedidos)
    {
        int i = 0;
        conect = new Conexion();
        SqlTransaction tran;
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        tran = conect.abrir_conexion().BeginTransaction("simpleTransicion");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.Transaction = tran;
            command.CommandText = "INSERT INTO pedidos(id_usuario, Emisor,id_usuarioReceptor,fecha,estado,id_empleado,descripcion) VALUES(@emisor,@receptor,@fecha,@estado,@id_empleado,@descripcion)";
            command.Parameters.Add("@emisor", SqlDbType.VarChar, 10);
            command.Parameters["@emisor"].Value = pedidos.Id_usuarioEmisor;
            command.Parameters.Add("@receptor", SqlDbType.VarChar, 10);
            command.Parameters["@receptor"].Value = pedidos.Id_usuarioReceptor;
            command.Parameters.Add("@fecha", SqlDbType.DateTime);
            command.Parameters["@fecha"].Value = pedidos.Fecha;
            command.Parameters.Add("@id_empleado", SqlDbType.Int);
            command.Parameters["@id_empleado"].Value = pedidos.Id_empleado;
            command.Parameters.Add("@descripcion", SqlDbType.Text);
            command.Parameters["@descripcion"].Value = pedidos.Descripcion;
            command.ExecuteNonQuery();
            tran.Commit();
            i = 1;
        }
        catch (Exception e)
        {
            tran.Rollback();
        }
        finally
        {
            conect.cerrar_conexion();
        }
        return i;
    }

    //No run
    public List<Pedidos> Listar_pedidos(int id_empresa)
    {
        List<Pedidos> lst = new List<Pedidos>(0);
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT p.id_pedido, p.id_usuarioEmisor,p.id_usuarioReceptor,p.fecha,p.estado,p.id_empleado,p.descripcion, e.nombre FROM pedidos AS p INNER JOIN empleados AS e ON p.id_empleado = e.id_empleado INNER JOIN usuarios AS u ON u.id_usuario = p.id_usuarioEmisor WHERE u.id_empresa = @id_empresa ", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Pedidos pedido = new Pedidos();
            pedido.Id_pedido = read.GetInt32(0);
            pedido.Id_usuarioEmisor = read.GetString(1);
            pedido.Id_usuarioReceptor = read.GetString(2);
            pedido.Fecha = read.GetString(3);
            pedido.Estado = read.GetInt32(4);
            pedido.Id_empleado = read.GetInt32(5);
            pedido.Descripcion = read.GetString(6);
            pedido.NombreEmpleado = read.GetString(7);
            lst.Add(pedido);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    //No run
    public int actualizar(Pedidos pedid)
    {
        int a = 0;
        String query = "UPDATE pedidos SET id_usuarioEmisor = @emisor, id_usuarioReceptor = @receptor, fecha  = @fecha, estado = @estado, id_empleado = @empleado, descripcion = @descripcion  WHERE id_pedido = @id_pedido";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_pedido", SqlDbType.Int);
            command.Parameters["@id_pedido"].Value = pedid.Id_pedido;
            command.Parameters.Add("@emisor", SqlDbType.VarChar, 10);
            command.Parameters["@emisor"].Value = pedid.Id_usuarioEmisor;
            command.Parameters.Add("@receptor", SqlDbType.VarChar, 10);
            command.Parameters["@receptor"].Value = pedid.Id_usuarioReceptor;
            command.Parameters.Add("@fecha", SqlDbType.DateTime);
            command.Parameters["@fecha"].Value = pedid.Fecha;
            command.Parameters.Add("@estado", SqlDbType.Bit);
            command.Parameters["@estado"].Value = pedid.Estado;
            command.Parameters.Add("@empleado", SqlDbType.Int);
            command.Parameters["@empleado"].Value = pedid.Id_empleado;
            command.Parameters.Add("@descripcion", SqlDbType.Text);
            command.Parameters["@descripcion"].Value = pedid.Descripcion;
            command.ExecuteNonQuery();
            trans.Commit();
            a = 1;
        }
        catch (Exception e)
        {
            trans.Rollback();
        }
        finally
        {
            conect.cerrar_conexion();
        }
        return a;
    }
    public List<Ventas> Listar_ventasPree(string id_usuario, int estado)
    {
        List<Ventas> lst = new List<Ventas>(0);
        conect = new Conexion();
        SqlCommand command = new SqlCommand("select v.id_venta,c.nombre,c.apellido, d.nombre as documento,v.estado,(select sum(precio_producto*cantidad) from detalle_ventas as dl where v.id_venta = dl.id_venta) as total from ventas as v inner join clientes as c on v.id_cliente = c.id_cliente inner join documentos as d on v.id_Documento = d.id_documento where v.id_usuario = @user and v.estado = @estado;", conect.abrir_conexion());
        command.Parameters.Add("@estado", SqlDbType.Int);
        command.Parameters["@estado"].Value = estado;
        command.Parameters.Add("@user", SqlDbType.VarChar, 10);
        command.Parameters["@user"].Value = id_usuario;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Ventas ventas = new Ventas();
            ventas.Id_venta = read.GetInt32(0);
            ventas.Nombre_cliente = read.GetString(1);
            ventas.Apellido_cliente = read.GetString(2);
            ventas.Nombre_tipoDocumento = read.GetString(3);
            ventas.Estado = read.GetInt32(4);
            ventas.Total = read.GetDecimal(5);
            lst.Add(ventas);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;

    }

}