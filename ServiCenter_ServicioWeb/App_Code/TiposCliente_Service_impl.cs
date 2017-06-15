using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de TiposCliente_Service_impl
/// </summary>
public class TiposCliente_Service_impl : TiposCliente_Service
{
    Conexion conect = null;
    public TiposCliente_Service_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int agregar(Tipos_clientes tCliente, string id_usuario)
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
            command.CommandText = "INSERT INTO tipos_clientes(id_empresa, nombre_tipo, descripcion, estado) VALUES(@id_empresa,@nombre_tipo,@descripcion,@estado)";
            command.Parameters.Add("@id_empresa", SqlDbType.Int);
            command.Parameters["@id_empresa"].Value = tCliente.Id_empresa;
            command.Parameters.Add("@nombre_tipo", SqlDbType.VarChar, 50);
            command.Parameters["@nombre_tipo"].Value = tCliente.NombreTipo;
            command.Parameters.Add("@descripcion", SqlDbType.VarChar, 50);
            command.Parameters["@descripcion"].Value = tCliente.Descripcion;
            command.Parameters.Add("@estado",SqlDbType.Int);
            command.Parameters["@estado"].Value = tCliente.Estado;
           
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

    public List<Tipos_clientes> Listar_tiposClientes(int id_empresa)
    {
        List<Tipos_clientes> lst = new List<Tipos_clientes>(0); //Para qué es ese (0) que está ahí?
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT id_tipo,id_empresa,nombre_tipo,descripcion FROM tipos_clientes WHERE id_empresa = @id_empresa AND estado = 1", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Tipos_clientes tCliente = new Tipos_clientes();
            tCliente.Id_tipo = read.GetInt32(0);
            tCliente.Id_empresa = read.GetInt32(1);
            tCliente.NombreTipo = read.GetString(2);
            tCliente.Descripcion = read.GetString(3);


            lst.Add(tCliente);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar(Tipos_clientes tCliente, string idUsuario)
    {
        int a = 0;
        String query = "UPDATE tipos_clientes SET id_empresa = @id_empresa, nombre_tipo = @nombre, descripcion = @descripcion, estado = @estado WHERE id_tipo = @id_tipo";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_tipo", SqlDbType.Int);
            command.Parameters["@id_tipo"].Value = tCliente.Id_tipo;
            command.Parameters.Add("@id_empresa", SqlDbType.Int);
            command.Parameters["@id_empresa"].Value = tCliente.Id_empresa;
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            command.Parameters["@nombre"].Value = tCliente.NombreTipo;
            command.Parameters.Add("@descripcion", SqlDbType.VarChar, 50);
            command.Parameters["@descripcion"].Value = tCliente.Descripcion;
            command.Parameters.Add("@estado", SqlDbType.Int);
            command.Parameters["@estado"].Value = tCliente.Estado;


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