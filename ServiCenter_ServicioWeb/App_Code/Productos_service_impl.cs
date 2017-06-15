using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Productos_service_impl
/// </summary>
public class Productos_service_impl : Productos_service
{
    Conexion conect = null;
    public Productos_service_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public int agregar(Productos productos, string id_usuario)
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
        
            command.CommandText = "INSERT INTO productos(nombre,descripcion,id_proveedor,precio_costo,estado,fraccion,contenido) VALUES(@nombre,@descripcion,@id_proveedor,@precio_costo,@estado,@fraccion,@contenido);SELECT SCOPE_IDENTITY();";
        
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            command.Parameters["@nombre"].Value =  productos.Nombre;
            command.Parameters.Add("@descripcion", SqlDbType.Text);
            command.Parameters["@descripcion"].Value = productos.Descripcion;
            command.Parameters.Add("@id_proveedor", SqlDbType.Int);
            command.Parameters["@id_proveedor"].Value = productos.Id_proveedor;
            command.Parameters.Add("@precio_costo", SqlDbType.Decimal);
            command.Parameters["@precio_costo"].Value = productos.Precio_costo;
            command.Parameters.Add("@estado", SqlDbType.Int);
            command.Parameters["@estado"].Value = productos.Estado;
            command.Parameters.Add("@fraccion", SqlDbType.VarChar);
            command.Parameters["@fraccion"].Value = productos.Fraccion;
            command.Parameters.Add("@contenido", SqlDbType.Int);
            command.Parameters["@contenido"].Value = productos.Contenido;
         
           i = int.Parse(command.ExecuteScalar().ToString());
            tran.Commit();
           

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

    public List<Productos> Listar_productos(int id_empresa)
    {
        List<Productos> lst = new List<Productos>(0); //Para qué es ese (0) que está ahí?
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT p.id_producto, p.nombre, p.descripcion, p.id_proveedor, pr.nombre, p.precio_costo, p.estado, p.fraccion, p.contenido FROM productos AS p INNER JOIN proveedores AS pr ON p.id_proveedor = pr.id_proveedor  WHERE pr.id_empresa = @id_empresa AND p.estado =1", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Productos producto = new Productos();
            producto.Id_producto = read.GetInt32(0);
            producto.Nombre = read.GetString(1);
            producto.Descripcion = read.GetString(2);
            producto.Id_proveedor = read.GetInt32(3);
            producto.NombreProveedor = read.GetString(4);
            producto.Precio_costo = read.GetDecimal(5);
            producto.Estado = read.GetInt32(6);
            producto.Fraccion = read.GetString(7);
            producto.Contenido = read.GetInt32(8);
            lst.Add(producto);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public int actualizar(Productos produc, string id_usuario)
    {
        
        int a = 0;
        String query = "UPDATE productos SET nombre = @nombre, descripcion = @descripcion, id_proveedor = @id_proveedor, precio_costo = @precio_costo, estado = @estado, fraccion = @fraccion, contenido = @contenido  WHERE id_producto = @id_producto";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_producto", SqlDbType.Int);
            command.Parameters["@id_producto"].Value = produc.Id_producto;
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            command.Parameters["@nombre"].Value = produc.Nombre;
            command.Parameters.Add("@descripcion", SqlDbType.Text);
            command.Parameters["@descripcion"].Value = produc.Descripcion;
            command.Parameters.Add("@id_proveedor", SqlDbType.Int);
            command.Parameters["@id_proveedor"].Value = produc.Id_proveedor;
            command.Parameters.Add("@precio_costo", SqlDbType.Decimal);
            command.Parameters["@precio_costo"].Value = produc.Precio_costo;
            command.Parameters.Add("@estado", SqlDbType.Int);
            command.Parameters["@estado"].Value = produc.Estado;
            command.Parameters.Add("@fraccion", SqlDbType.VarChar);
            command.Parameters["@fraccion"].Value = produc.Fraccion;
            command.Parameters.Add("@contenido", SqlDbType.Int);
            command.Parameters["@contenido"].Value = produc.Contenido;


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