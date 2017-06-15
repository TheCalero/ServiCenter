using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Cargo_servicio_impl
/// </summary>
public class Cargo_servicio_impl : Cargo_servicio
{
    Conexion conect = null;
    public Cargo_servicio_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int agregar(Cargo cargo)
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
            command.CommandText = "INSERT INTO cargo(nombre,gid,pos,descripcion,id_empresa) VALUES(@nombre,@gid,@pos,@descripcion,@id_empresa)";
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            command.Parameters["@nombre"].Value = cargo.Nombre;
            command.Parameters.Add("@gid", SqlDbType.Bit);
            command.Parameters["@gid"].Value = cargo.Gid;
            command.Parameters.Add("@pos", SqlDbType.Bit);
            command.Parameters["@pos"].Value = cargo.Pos;
            command.Parameters.Add("@descripcion", SqlDbType.Text);
            command.Parameters["@descripcion"].Value = cargo.Descripcion;
            command.Parameters.Add("@id_empresa", SqlDbType.Int);
            command.Parameters["@id_empresa"].Value = cargo.Id_empresa;
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

    public List<Cargo> Listar_cargos(int id_empresa)
    {
        List<Cargo> lst = new List<Cargo>(0);
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT id_cargo, nombre, gid, pos, descripcion, id_empresa tipo FROM cargo", conect.abrir_conexion());
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Cargo carg = new Cargo();
            carg.Id_cargo = read.GetInt32(0);
            carg.Nombre = read.GetString(1);
            carg.Gid = read.GetBoolean(2);
            carg.Pos = read.GetBoolean(3);
            carg.Descripcion = read.GetString(4);
            carg.Id_empresa = read.GetInt32(5);
            lst.Add(carg);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar(Cargo car)
    {
        int a = 0;
        String query = "UPDATE cargo SET nombre = @nombre, gid = @gid, pos = @pos, descripcion = @descripcion  WHERE id_cargo = @id_cargo";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_cargo", SqlDbType.Int);
            command.Parameters["@id_cargo"].Value = car.Id_cargo;
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            command.Parameters["@nombre"].Value = car.Nombre;
            command.Parameters.Add("@gid", SqlDbType.Bit);
            command.Parameters["@gid"].Value = car.Gid;
            command.Parameters.Add("@pos", SqlDbType.Bit);
            command.Parameters["@pos"].Value = car.Pos;
            command.Parameters.Add("@descripcion", SqlDbType.Text);
            command.Parameters["@descripcion"].Value = car.Descripcion;
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
