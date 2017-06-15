using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Eventos_service_impl
/// </summary>
public class Eventos_service_impl : Eventos_servicio
{
    Conexion conect = null;

    public Eventos_service_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int agregar(Eventos eventos)
    {
        int i = 0;
        conect = new Conexion();
        SqlTransaction tran;
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        tran = conect.abrir_conexion().BeginTransaction("trans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.Transaction = tran;
            command.CommandText = "INSERT INTO eventos(tipo,fecha,id_usuario,id_empleado) VALUES(@tipo,@fecha,@id_usuario,@id_empleado);";
            command.Parameters.Add("@tipo", SqlDbType.Int);
            command.Parameters["@tipo"].Value = eventos.Tipo;
            command.Parameters.Add("@fecha", SqlDbType.DateTime);
            command.Parameters["@fecha"].Value = eventos.Fecha;
            command.Parameters.Add("@id_usuario", SqlDbType.VarChar,10);
            command.Parameters["@id_usuario"].Value = eventos.Id_usuario;
            command.Parameters.Add("@id_empleado", SqlDbType.Int);
            command.Parameters["@id_empleado"].Value = eventos.Id_empleado;
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


    public List<Eventos> Listar_eventos(int id_empresa)
    {
        List<Eventos> lst = new List<Eventos>(0); 
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT e.id_eventos as ID_evento, t.nombre as nombre_evento, t.descripcion, e.fecha, u.nombre as usuario, em.nombre as nombre_empleado, em.apellidos as apellido_empleado, emp.nombre as nombre_empresa FROM eventos AS e INNER JOIN usuarios AS u ON e.id_usuario = u.id_usuario INNER JOIN tipo_eventos AS t ON e.tipo = t.id_tipo INNER JOIN empresas AS emp ON u.id_empresa = emp.id_empresa INNER JOIN empleados AS em ON e.id_empleado = em.id_empleado WHERE u.id_empresa = @id_empresa;", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Eventos even = new Eventos();
            even.Id_eventos = read.GetInt32(0);
            even.Nombre_evento = read.GetString(1);
            even.Descripcion = read.GetString(2);
            even.Fecha = read.GetDateTime(3);
            even.Nombre_usuario = read.GetString(4);
            even.Nom_empleado = read.GetString(5);
            even.Ape_empleado = read.GetString(6);
            even.Nom_empresa = read.GetString(7);
            lst.Add(even);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

}