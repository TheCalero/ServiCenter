using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Descripción breve de Proveedores_service_impl
/// </summary>
public class Proveedores_service_impl : Proveedores_service
{
    Conexion conect = null;
    public Proveedores_service_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int agregar(Proveedores proveedores, string id_usuario)
    {
        int i = 0;
        conect = new Conexion();
        SqlTransaction tran;
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        tran = conect.abrir_conexion().BeginTransaction("simpleTransicion");
       
            command.Connection = conect.abrir_conexion();
            command.Transaction = tran;
            command.CommandText = "INSERT INTO proveedores(id_empresa,nombre,direccion,num_telefono,correo, nrc, nit, estado) VALUES(@id_empresa,@nombre,@direccion,@num_telefono,@correo,@nrc,@nit, 1)";
            command.Parameters.Add("@id_empresa", SqlDbType.Int);
            command.Parameters["@id_empresa"].Value = proveedores.Id_empresa;
            command.Parameters.Add("@nombre", SqlDbType.VarChar,50);
            command.Parameters["@nombre"].Value = proveedores.Nombre;
            command.Parameters.Add("@direccion", SqlDbType.VarChar,50);
            command.Parameters["@direccion"].Value = proveedores.Direccion;
            command.Parameters.Add("@num_telefono", SqlDbType.VarChar, 9);
            command.Parameters["@num_telefono"].Value = proveedores.Num_telefono;
            command.Parameters.Add("@correo", SqlDbType.VarChar, 60);
            command.Parameters["@correo"].Value = proveedores.Correo;
            command.Parameters.Add("@nrc", SqlDbType.VarChar, 15);
            command.Parameters["@nrc"].Value = proveedores.Nrc;
            command.Parameters.Add("@nit", SqlDbType.VarChar, 16);
            command.Parameters["@nit"].Value = proveedores.Nit;
             command.ExecuteNonQuery();
            tran.Commit();
            i = 1;

        return i;
    }

    public List<Proveedores> Listar_proveedores(int id_empresa)
    {
        List<Proveedores> lst = new List<Proveedores>(0); //Para qué es ese (0) que está ahí?
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT id_proveedor,id_empresa,nombre,direccion,num_telefono,correo, nrc, nit FROM proveedores WHERE id_empresa = @id_empresa AND estado = 1", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Proveedores proveedor = new Proveedores();
            proveedor.Id_proveedor = read.GetInt32(0);
            proveedor.Id_empresa = read.GetInt32(1);
            proveedor.Nombre = read.GetString(2);
            proveedor.Direccion = read.GetString(3);
            proveedor.Num_telefono = read.GetString(4);
            proveedor.Correo = read.GetString(5);
            proveedor.Nrc = read.GetString(6);
            proveedor.Nit = read.GetString(7);
          
            lst.Add(proveedor);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar(Proveedores proveedor, string id_usuario)
    {
        int a = 0;
        String query = "UPDATE proveedores SET id_empresa = @id_empresa, nombre = @nombre, direccion = @direccion, num_telefono = @num_telefono, correo = @correo, nrc = @nrc, nit = @nit, estado = @estado  WHERE id_proveedor = @id_proveedor";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        command.Connection = conect.abrir_conexion();
        command.CommandText = query;
        command.Transaction = trans;
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = proveedor.Id_empresa;
            command.Parameters.Add("@id_proveedor", SqlDbType.Int);
            command.Parameters["@id_proveedor"].Value = proveedor.Id_proveedor;
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            command.Parameters["@nombre"].Value = proveedor.Nombre;
            command.Parameters.Add("@direccion", SqlDbType.VarChar, 50);
            command.Parameters["@direccion"].Value = proveedor.Direccion;
            command.Parameters.Add("@num_telefono", SqlDbType.VarChar, 9);
            command.Parameters["@num_telefono"].Value = proveedor.Num_telefono;
            command.Parameters.Add("@correo", SqlDbType.VarChar, 60);
            command.Parameters["@correo"].Value = proveedor.Correo;
            command.Parameters.Add("@nrc", SqlDbType.VarChar, 15);
            command.Parameters["@nrc"].Value = proveedor.Nrc;
            command.Parameters.Add("@nit", SqlDbType.VarChar, 16);
            command.Parameters["@nit"].Value = proveedor.Nit;
            command.Parameters.Add("@estado", SqlDbType.Int);
            command.Parameters["@estado"].Value = proveedor.Estado;
     


            command.ExecuteNonQuery();
            trans.Commit();
            a = 1;

         
    
        return a;
    }
}