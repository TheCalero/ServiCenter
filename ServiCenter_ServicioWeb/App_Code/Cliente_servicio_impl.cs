using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Cliente_servicio_impl
/// </summary>
public class Cliente_servicio_impl : Cliente_servicio
{
    Conexion conect = null;
    public Cliente_servicio_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int agregar(Clientes cliente)
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
            command.CommandText = "INSERT INTO clientes(id_empresa,nombre,apellido,direccion,correo,num_telefono,num_dui,num_nit,estado) VALUES(@id_empresa,@nombre,@apellido,@direccion,@correo,@num_telefono,@num_dui,@num_nit,1)";
            command.Parameters.Add("@id_empresa", SqlDbType.Int);
            command.Parameters["@id_empresa"].Value = cliente.Id_empresa;
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 25);
            command.Parameters["@nombre"].Value = cliente.Nombre;
            command.Parameters.Add("@apellido", SqlDbType.VarChar, 25);
            command.Parameters["@apellido"].Value = cliente.Apellido;
            command.Parameters.Add("@direccion", SqlDbType.VarChar, 50);
            command.Parameters["@direccion"].Value = cliente.Direccion;
            command.Parameters.Add("@correo", SqlDbType.VarChar, 60);
            command.Parameters["@correo"].Value = cliente.Correo;
            command.Parameters.Add("@num_telefono", SqlDbType.VarChar, 9);
            command.Parameters["@num_telefono"].Value = cliente.Num_telefono;
            command.Parameters.Add("@num_dui", SqlDbType.VarChar, 10);
            command.Parameters["@num_dui"].Value = cliente.Num_dui;
            command.Parameters.Add("@num_nit", SqlDbType.VarChar, 20);
            command.Parameters["@num_nit"].Value = cliente.Num_nit;
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

    public List<Clientes> Listar_clientes(int id_empresa)
    {
        List<Clientes> lst = new List<Clientes>(0); //Para qué es ese (0) que está ahí?
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT id_cliente,nombre,apellido,direccion,correo,num_telefono,num_dui,num_nit FROM clientes WHERE id_empresa = @id_empresa AND estado = 1", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Clientes client = new Clientes();
            client.Id_cliente = read.GetInt32(0);
            client.Nombre = read.GetString(1);
            client.Apellido = read.GetString(2);
            client.Direccion = read.GetString(3);
            client.Correo = read.GetString(4);
            client.Num_telefono = read.GetString(5);
            client.Num_dui = read.GetString(6);
            client.Num_nit = read.GetString(7);
            lst.Add(client);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar(Clientes clien)
    {
        int a = 0;
        String query = "UPDATE clientes SET nombre  = @nombre, apellido = @apellido, direccion = @direccion, correo = @correo, num_telefono = @num_telefono, num_dui = @num_dui, num_nit = @num_nit, estado = @estado  WHERE id_cliente = @id_cliente";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_cliente", SqlDbType.Int);
            command.Parameters["@id_cliente"].Value = clien.Id_cliente;
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 25);
            command.Parameters["@nombre"].Value = clien.Nombre;
            command.Parameters.Add("@apellido", SqlDbType.VarChar, 25);
            command.Parameters["@apellido"].Value = clien.Apellido;
            command.Parameters.Add("@direccion", SqlDbType.VarChar, 50);
            command.Parameters["@direccion"].Value = clien.Direccion;
            command.Parameters.Add("@correo", SqlDbType.VarChar, 60);
            command.Parameters["@correo"].Value = clien.Correo;
            command.Parameters.Add("@num_telefono", SqlDbType.VarChar, 9);
            command.Parameters["@num_telefono"].Value = clien.Num_telefono;
            command.Parameters.Add("@num_dui", SqlDbType.VarChar, 10);
            command.Parameters["@num_dui"].Value = clien.Num_dui;
            command.Parameters.Add("@num_nit", SqlDbType.VarChar, 20);
            command.Parameters["@num_nit"].Value = clien.Num_nit;
            command.Parameters.Add("@estado", SqlDbType.Int);
            command.Parameters["@estado"].Value = clien.Estado;
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

