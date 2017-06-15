using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Mensajeria_service_impl
/// </summary>
public class Mensajeria_service_impl : Mensajeria_service
{
    Conexion conect = null;
    public Mensajeria_service_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int agregar(Mensajeria mensajeria, string id_usuario, int id_empleado)
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
            command.CommandText = "INSERT INTO mensajeria(id_emisor,id_receptor,fecha,prioridad,mensaje) VALUES(@id_emisor,@id_receptor,@fecha,@prioridad,@mensaje)";
            command.Parameters.Add("@id_emisor", SqlDbType.VarChar, 10);
            command.Parameters["@id_emisor"].Value = mensajeria.Emisor;
            command.Parameters.Add("@id_receptor", SqlDbType.VarChar, 10);
            command.Parameters["@id_receptor"].Value = mensajeria.Receptor;
            command.Parameters.Add("@fecha", SqlDbType.DateTime);
            command.Parameters["@fecha"].Value = mensajeria.Fecha;
            command.Parameters.Add("@prioridad", SqlDbType.Int);
            command.Parameters["@prioridad"].Value = mensajeria.Prioridad;
            command.Parameters.Add("@mensaje", SqlDbType.Text);
            command.Parameters["@mensaje"].Value = mensajeria.Mensaje;
            command.ExecuteNonQuery();
            tran.Commit();
            i = 1;

            Eventos_servicio evento = new Eventos_service_impl();
            Eventos evento1 = new Eventos();
            evento1.Id_usuario = id_usuario;
            evento1.Id_empleado = id_empleado;
            evento1.Tipo = 5;
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

    public List<Mensajeria> Listar_mensajeria(int id_empresa)
    {
        List<Mensajeria> lst = new List<Mensajeria>(0); //Para qué es ese (0) que está ahí?
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT m.id_mensaje,m.id_emisor,m.id_receptor,m.fecha,m.prioridad,m.mensaje FROM mensajeria AS m INNER JOIN usuarios AS u ON m.id_emisor = u.id_usuario WHERE u.id_empresa = @id_empresa", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Mensajeria msg = new Mensajeria();
            msg.Id_mensaje = read.GetInt32(0);
            msg.Emisor = read.GetString(1);
            msg.Receptor = read.GetString(2);
            msg.Fecha = read.GetDateTime(3);
            msg.Prioridad = read.GetInt32(4);
            msg.Mensaje = read.GetString(5);
            lst.Add(msg);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar(Mensajeria mensaje, string id_usuario, int id_empleado)
    {
        int a = 0;
        String query = "UPDATE mensajeria SET prioridad  = @prioridad  WHERE id_mensaje = @id_mensaje";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_mensaje", SqlDbType.Int);
            command.Parameters["@id_mensaje"].Value = mensaje.Id_mensaje;
            command.Parameters.Add("@prioridad", SqlDbType.Int);
            command.Parameters["@prioridad"].Value = mensaje.Prioridad;
           
            command.ExecuteNonQuery();
            trans.Commit();
            a = 1;

            Eventos_servicio evento = new Eventos_service_impl();
            Eventos evento1 = new Eventos();
            evento1.Id_usuario = id_usuario;
            evento1.Id_empleado = id_empleado;
            evento1.Tipo = 6;
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