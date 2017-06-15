using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Compras_servicio_impl
/// </summary>
public class Compras_servicio_impl : Compras_servicio
{
    Conexion conect = null;
    public Compras_servicio_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int agregar_compras(Compras compras)
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
            command.CommandText = "INSERT INTO compras(correlativo,id_proveedor,fecha,id_usuario,total,saldo) VALUES(@corr,@prove,@fecha,@user,@total,@total,@saldo)";
            command.Parameters.Add("@corr", SqlDbType.Int);
            command.Parameters["@corr"].Value = compras.Correlativo;
            command.Parameters.Add("@prove", SqlDbType.Int);
            command.Parameters["@prove"].Value = compras.Id_proveedor;
            command.Parameters.Add("@fecha", SqlDbType.DateTime);
            command.Parameters["@fecha"].Value = compras.Fecha;
            command.Parameters.Add("@user", SqlDbType.VarChar, 10);
            command.Parameters["@user"].Value = compras.Id_usuario;
            command.Parameters.Add("@total", SqlDbType.Decimal);
            command.Parameters["@total"].Value = compras.Total;
            command.Parameters.Add("@saldo", SqlDbType.Decimal);
            command.Parameters["@saldo"].Value = compras.Saldo;
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

    public List<Compras> Listar_compras()
    {
        List<Compras> lst = new List<Compras>(0);
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT c.id_compra,p.nombre as nombre_proveedor,c.fecha,c.id_usuario,c.total,c.saldo FROM compras AS c INNER JOIN proveedores AS p ON c.id_proveedor = p.id_proveedor;", conect.abrir_conexion());
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Compras comp = new Compras();
            comp.Id_compra = read.GetInt32(0);
            comp.Nombre_proveedor = read.GetString(1);
            comp.Fecha = read.GetDateTime(2);
            comp.Id_usuario = read.GetString(3);
            comp.Total = read.GetDecimal(4);
            comp.Saldo = read.GetDecimal(5);
            lst.Add(comp);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar_compras(Compras compras)
    {
        int a = 0;
        String query = "UPDATE compras SET correlativo = @corr, fecha = @fecha, total = @total, saldo = @sal WHERE id_compra = @id_compra";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_compra", SqlDbType.Int);
            command.Parameters["@id_compra"].Value = compras.Id_compra;
            command.Parameters.Add("@corr", SqlDbType.Int);
            command.Parameters["@corr"].Value = compras.Correlativo;
            command.Parameters.Add("@fecha", SqlDbType.DateTime);
            command.Parameters["@fecha"].Value = compras.Fecha;
            command.Parameters.Add("@total", SqlDbType.Decimal);
            command.Parameters["@total"].Value = compras.Total;
            command.Parameters.Add("@sal", SqlDbType.Decimal);
            command.Parameters["@sal"].Value = compras.Saldo;
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

}

