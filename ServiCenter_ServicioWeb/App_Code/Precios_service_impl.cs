using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Descripción breve de Precios_service_impl
/// </summary>
public class Precios_service_impl : Precios_service
{
    Conexion conect = null;
    public Precios_service_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public Decimal retornarprecioventa(int id_producto)
    {
        Decimal i = 0;
        conect = new Conexion();
        string select = "select precio_venta from precios where id_producto = " + id_producto + ";";
        SqlCommand selectCommand = new SqlCommand(select, conect.abrir_conexion());
        selectCommand.CommandType = CommandType.Text;
        try
        {
            conect.abrir_conexion();
            SqlDataReader rowReader = selectCommand.ExecuteReader();
            if (rowReader.Read())
            {
                i = rowReader.GetDecimal(0);
            }
        }
        catch (Exception e)
        {
            ;
        }
        finally
        {
            conect.cerrar_conexion();
        }

        return i;
    }

    public int agregar(Precios precios)
    {
        int i = 0;
        conect = new Conexion();
        SqlTransaction tran;
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        tran = conect.abrir_conexion().BeginTransaction("simpleTransicion");
       
            command.Connection = conect.abrir_conexion();
            command.Transaction = tran;
            command.CommandText = "INSERT INTO precios(id_producto, id_tipo, id_empresa, precio_venta) VALUES(@id_producto,@id_tipo,@id_empresa,@precioVenta)";
            command.Parameters.Add("@id_producto", SqlDbType.Int);
            command.Parameters["@id_producto"].Value = precios.Id_producto;
            command.Parameters.Add("@id_tipo", SqlDbType.Int);
            command.Parameters["@id_tipo"].Value = precios.Id_tipo;
            command.Parameters.Add("@id_empresa", SqlDbType.Int);
            command.Parameters["@id_empresa"].Value = precios.Id_empresa;
            command.Parameters.Add("@precioVenta", SqlDbType.Decimal);
            command.Parameters["@precioVenta"].Value = precios.Precio_venta;
            command.ExecuteNonQuery();
            tran.Commit();
            i = 1;
            return i;
    }

    public List<Precios> Listar_precios(Precios precio)
    {
        List<Precios> lst = new List<Precios>(0); 
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT p.id_precio, p.id_producto, p.id_tipo, p.precio_venta, pr.nombre, t.nombre_tipo FROM precios AS p INNER JOIN productos AS pr ON p.id_producto = pr.id_producto INNER JOIN tipos_clientes AS t ON p.id_tipo = t.id_tipo WHERE pr.id_producto = @id_producto ", conect.abrir_conexion());
        command.Parameters.Add("@id_producto", SqlDbType.Int);
        command.Parameters["@id_producto"].Value = precio.Id_producto; 
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Precios prec = new Precios();
            prec.Id_precio = read.GetInt32(0);
            prec.Id_producto = read.GetInt32(1);
            prec.Id_tipo = read.GetInt32(2);
            prec.Precio_venta = read.GetDecimal(3);
            prec.NombreProducto = read.GetString(4);
            prec.NombreTipo = read.GetString(5);
            prec.Retornar = Convert.ToString(read.GetInt32(0)) + "." + Convert.ToString(read.GetDecimal(3));
            lst.Add(prec);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar(Precios prec)
    {
        int a = 0;
        String query = "UPDATE precios SET precio_venta = @precioVenta  WHERE id_precio = @id_precio";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_precio", SqlDbType.Int);
            command.Parameters["@id_precio"].Value = prec.Id_precio;
            command.Parameters.Add("@precioVenta", SqlDbType.Decimal);
            command.Parameters["@precioVenta"].Value = prec.Precio_venta;
            
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