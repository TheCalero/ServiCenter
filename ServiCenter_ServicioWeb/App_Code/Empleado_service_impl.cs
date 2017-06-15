using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Descripción breve de Empleado_service_impl
/// </summary>
public class Empleado_service_impl : Empleado_service
{
    Conexion conect = null;
    public Empleado_service_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int agregar(Empleados empleado)
    {
        int i = 0;
        conect = new Conexion();
        SqlTransaction tran;
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        tran = conect.abrir_conexion().BeginTransaction("simpleTransicion");
      try { 
        command.Connection = conect.abrir_conexion();
        command.Transaction = tran;
        command.CommandText = "INSERT INTO empleados(nombre, apellidos, direccion, DUI, id_cargo, id_usuario, estado) VALUES(@nombre, @apellido, @direccion, @dui, @id_cargo, @id_usuario, 1)";
        command.Parameters.Add("@nombre", SqlDbType.VarChar, 25);
        command.Parameters["@nombre"].Value = empleado.Nombre;
        command.Parameters.Add("@apellido", SqlDbType.VarChar, 25);
        command.Parameters["@apellido"].Value = empleado.Apellidos;
        command.Parameters.Add("@direccion", SqlDbType.VarChar, 50);
        command.Parameters["@direccion"].Value = empleado.Direccion;
        command.Parameters.Add("@dui", SqlDbType.VarChar, 9);
        command.Parameters["@dui"].Value = empleado.Dui;
        command.Parameters.Add("@id_cargo", SqlDbType.Int);
        command.Parameters["@id_cargo"].Value = empleado.Id_cargo;
        command.Parameters.Add("@id_usuario", SqlDbType.VarChar, 10);
        command.Parameters["@id_usuario"].Value = empleado.Id_usuario;
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

    public List<Empleados> Listar_empleados(int id_empresa)
    {
        List<Empleados> lst = new List<Empleados>(0);
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT e.id_empleado, e.nombre, e.apellidos, e.direccion, e.DUI, e.id_cargo, e.id_usuario, u.nombre, c.nombre, e.estado FROM empleados AS e INNER JOIN usuarios AS u ON e.id_usuario = u.id_usuario INNER JOIN cargo AS c ON e.id_cargo = c.id_cargo WHERE e.estado = 1 AND u.id_empresa = @id_empresa", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Empleados emp = new Empleados();
            emp.Id_empleado = read.GetInt32(0);
            emp.Nombre = read.GetString(1);
            emp.Apellidos = read.GetString(2);
            emp.Direccion = read.GetString(3);
            emp.Dui = read.GetString(4);
            emp.Id_cargo = read.GetInt32(5);
            emp.Id_usuario = read.GetString(6);
            emp.NombreSuc = read.GetString(7);
            emp.NombreCargo = read.GetString(8);
            emp.Estado = read.GetInt32(9);
            lst.Add(emp);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar(Empleados emp)
    {
        int a = 0;
        String query = "UPDATE empleados SET nombre = @nombre, apellidos = @apellido, direccion = @direccion, DUI = @dui, id_cargo = @idCargo, id_usuario = @idUsuario, estado = @estado  WHERE id_empleado = @idEmpleado";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@idEmpleado", SqlDbType.Int);
            command.Parameters["@idEmpleado"].Value = emp.Id_empleado;
            command.Parameters.Add("@nombre", SqlDbType.VarChar);
            command.Parameters["@nombre"].Value = emp.Nombre;
            command.Parameters.Add("@apellido", SqlDbType.VarChar);
            command.Parameters["@apellido"].Value = emp.Apellidos;
            command.Parameters.Add("@direccion", SqlDbType.VarChar);
            command.Parameters["@direccion"].Value = emp.Direccion;
            command.Parameters.Add("@dui", SqlDbType.VarChar);
            command.Parameters["@dui"].Value = emp.Dui;
            command.Parameters.Add("@idCargo", SqlDbType.Int);
            command.Parameters["@idCargo"].Value = emp.Id_cargo;
            command.Parameters.Add("@idUsuario", SqlDbType.VarChar);
            command.Parameters["@idUsuario"].Value = emp.Id_usuario;
            command.Parameters.Add("@estado", SqlDbType.Int);
            command.Parameters["@estado"].Value = emp.Estado;

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