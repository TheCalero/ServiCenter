using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Inventarios_servicio_impl
/// </summary>
public class Inventarios_servicio_impl : Inventarios_servicio
{
    Conexion conect = null;
    public Inventarios_servicio_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int agregar(Inventarios inventarios, string id_usuario, int id_empleado)
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
            command.CommandText = "INSERT INTO inventarios(id_usuario,cantidad,id_producto,fechaVen) VALUES(@id_usuario,@cantidad,@id_producto,@fechaVen)";
            command.Parameters.Add("@id_usuario", SqlDbType.VarChar, 10);
            command.Parameters["@id_usuario"].Value = inventarios.Id_usuario;
            command.Parameters.Add("@cantidad", SqlDbType.Int);
            command.Parameters["@cantidad"].Value = inventarios.Cantidad;
            command.Parameters.Add("@id_producto", SqlDbType.Int);
            command.Parameters["@id_producto"].Value = inventarios.Id_producto;
            command.Parameters.Add("@fechaVen", SqlDbType.DateTime);
            command.Parameters["@fechaVen"].Value = inventarios.FechaVen;
            command.ExecuteNonQuery();
            tran.Commit();
            i = 1;

            Eventos_servicio evento = new Eventos_service_impl();
            Eventos evento1 = new Eventos();
            evento1.Id_usuario = id_usuario;
            evento1.Id_empleado = id_empleado;
            evento1.Tipo = 3;
            evento1.Fecha = DateTime.Now;
            evento.agregar(evento1);
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

     public List<Inventarios> Listar_inventariosSuc(int id_empresa, string id_usuario)
    {
        List<Inventarios> lst = new List<Inventarios>(0); //Para qué es ese (0) que está ahí?
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT i.id_inventarios, i.id_usuario, i.id_producto, i.cantidad, i.fechaVen, p.nombre FROM inventarios AS i INNER JOIN productos AS p ON i.id_producto = p.id_producto INNER JOIN usuarios AS u ON i.id_usuario = u.id_usuario WHERE u.id_usuario = @id_usuario", conect.abrir_conexion());
        command.Parameters.Add("@id_usuario", SqlDbType.Int);
        command.Parameters["@id_usuario"].Value = id_usuario;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Inventarios inven = new Inventarios();
            inven.Id_inventarios = read.GetInt32(0);
            inven.Id_usuario = read.GetString(1);
            inven.Id_producto = read.GetInt32(2);
            inven.Cantidad = read.GetInt32(3);
            inven.FechaVen = read.GetDateTime(4);
            inven.NombreProducto = read.GetString(5);
            lst.Add(inven);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }


    public List<Inventarios> Listar_inventarios(int id_empresa)
    {
        List<Inventarios> lst = new List<Inventarios>(0); //Para qué es ese (0) que está ahí?
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT i.id_inventarios, i.id_usuario, i.id_producto, i.cantidad, i.fechaVen, p.nombre FROM inventarios AS i INNER JOIN productos AS p ON i.id_producto = p.id_producto INNER JOIN usuarios AS u ON i.id_usuario = u.id_usuario WHERE u.id_empresa = @id_empresa", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Inventarios inven = new Inventarios();
            inven.Id_inventarios = read.GetInt32(0);
            inven.Id_usuario = read.GetString(1);
            inven.Id_producto = read.GetInt32(2);
            inven.Cantidad = read.GetInt32(3);
            inven.FechaVen = read.GetDateTime(4);
            inven.NombreProducto = read.GetString(5);
            lst.Add(inven);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar(Inventarios inv, string id_usuario, int id_empleado)
    {
        int a = 0;
        String query = "UPDATE inventarios SET id_usuario = @id_usuario, cantidad = @cantidad, id_producto = @id_producto, fechaVen = @fechaVen  WHERE id_inventarios = @id_inventarios";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_inventarios", SqlDbType.Int);
            command.Parameters["@id_inventarios"].Value = inv.Id_inventarios;
            command.Parameters.Add("@id_usuario", SqlDbType.VarChar, 10);
            command.Parameters["@id_usuario"].Value = inv.Id_usuario;
            command.Parameters.Add("@id_producto", SqlDbType.Int);
            command.Parameters["@id_producto"].Value = inv.Id_producto;
            command.Parameters.Add("@fechaVen", SqlDbType.DateTime);
            command.Parameters["@fechaVen"].Value = inv.FechaVen;
            
            command.ExecuteNonQuery();
            trans.Commit();
            a = 1;

            Eventos_servicio evento = new Eventos_service_impl();
            Eventos evento1 = new Eventos();
            evento1.Id_usuario = id_usuario;
            evento1.Id_empleado = id_empleado;
            evento1.Tipo = 4;
            evento1.Fecha = DateTime.Now;
            evento.agregar(evento1);
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
}