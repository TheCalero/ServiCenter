using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Descuentos_servicio_impl
/// </summary>
public class Descuentos_servicio_impl : Descuentos_servicio
{
    Conexion conect = null;
    public Descuentos_servicio_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int agregar_descuento(Descuentos descuento)
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
            command.CommandText = "INSERT INTO descuentos(valor,descripcion, id_empresa) VALUES(@val,@des,@id_empresa)";
            command.Parameters.Add("@val", SqlDbType.Decimal);
            command.Parameters["@val"].Value = descuento.Valor;
            command.Parameters.Add("@des", SqlDbType.Text);
            command.Parameters["@des"].Value = descuento.Descripcion;
            command.Parameters.Add("@id_empresa", SqlDbType.Int);
            command.Parameters["@id_empresa"].Value = descuento.Id_empresa;
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

    public List<Descuentos> Listar_descuentos(int id_empresa)
    {
        List<Descuentos> lst = new List<Descuentos>(0);
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT id_descuento,valor,descripcion FROM descuentos WHERE id_empresa = @empresa;", conect.abrir_conexion());
        command.Parameters.Add("@empresa", SqlDbType.Int);
        command.Parameters["@empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Descuentos des = new Descuentos();
            des.Id_descuento = read.GetInt32(0);
            des.Valor = read.GetDecimal(1);
            des.Descripcion = read.GetString(2);
            des.Descripcionvalor = " " + read.GetString(2) + " " + read.GetDecimal(1) * 100 + "%";
            lst.Add(des);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar_descuento(Descuentos descuento)
    {
        int a = 0;
        String query = "UPDATE descuentos SET valor = @val, descripcion = @des WHERE id_descuento = @id";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@val", SqlDbType.Decimal);
            command.Parameters["@val"].Value = descuento.Valor;
            command.Parameters.Add("@des", SqlDbType.Text);
            command.Parameters["@des"].Value = descuento.Descripcion;
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = descuento.Id_descuento;
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


