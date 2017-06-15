using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Usuario_servicio_impl
/// </summary>
public class Usuario_servicio_impl : Usuario_servicio
{
    Conexion conect = null;
    public Usuario_servicio_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public int agregar(Usuarios usuario)
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
            command.CommandText = "INSERT INTO usuarios(id_usuario,id_empresa,id_tipo,contrasennia,nombre) VALUES(@id_usuario,@id_empresa,@tipo,HASHBYTES('MD5','"+usuario.Contrasennia+"'),@nombre)";
            command.Parameters.Add("@id_usuario", SqlDbType.VarChar, 10);
            command.Parameters["@id_usuario"].Value = usuario.Id_usuario;
            command.Parameters.Add("@id_empresa", SqlDbType.Int);
            command.Parameters["@id_empresa"].Value = usuario.Id_empresa;
            command.Parameters.Add("@tipo", SqlDbType.Int);
            command.Parameters["@tipo"].Value = usuario.Id_tipo;
            //command.Parameters.Add("@contrasennia", SqlDbType.VarChar, 30);
            //command.Parameters["@contrasennia"].Value = usuario.Contrasennia;
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            command.Parameters["@nombre"].Value = usuario.Nombre;
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

    public List<Usuarios> Listar_usuarios(int id_empresa)
    {
        List<Usuarios> lst = new List<Usuarios>(0); 
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT id_usuario, e.nombre as nom_empresa, u.nombre as nom_usuario, u.id_tipo, t.nombre FROM empresas AS e INNER JOIN usuarios AS u ON e.id_empresa = u.id_empresa INNER JOIN tipos_usuarios AS t ON u.id_tipo = t.id_tipo where u.id_empresa = @id_empresa;", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Usuarios user = new Usuarios();
            user.Id_usuario = read.GetString(0);
            user.Nombre_empresa = read.GetString(2);
            user.Nombre = read.GetString(1);
            user.Id_tipo = read.GetInt32(3);
            user.NombreTipo = read.GetString(4);
            lst.Add(user);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;
    }

    public bool contraDiferente(string contra_antigua, string id_usuario)
    {
        bool a;
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT id_usuario FROM usuarios WHERE contrasennia = @contra AND id_usuario = @user;", conect.abrir_conexion());//implementar hashbyte md5
            command.Parameters.Add("@user", SqlDbType.VarChar, 10);
            command.Parameters["@user"].Value = id_usuario;
            command.Parameters.Add("@contra", SqlDbType.VarChar, 30);
            command.Parameters["@contra"].Value = contra_antigua;
        SqlDataReader read = command.ExecuteReader();
        if (read.RecordsAffected>1)
            a = false;
        else{ a = true; }
        read.Close();
        conect.cerrar_conexion();
        return a;
    }

    public int actualizar(Usuarios usr)
    {
        int a = 0;
        String query = "UPDATE usuarios SET nombre = @nombre, contrasennia = @contraniu WHERE id_usuario = @id_usuario";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_usuario", SqlDbType.VarChar, 10);
            command.Parameters["@id_usuario"].Value = usr.Id_usuario;
            command.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
            command.Parameters["@nombre"].Value = usr.Nombre;
            command.Parameters.Add("@contraniu", SqlDbType.VarChar, 30);
            command.Parameters["@contraniu"].Value = usr.Contrasennia;
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
    public bool existe_usuario(string id_usuario)
    {
        bool a = true;
        String query = "SELECT id_usuario FROM usuarios WHERE id_usuario = @id_usuario";
        conect = new Conexion();
        SqlCommand command = conect.abrir_conexion().CreateCommand();
        SqlTransaction trans = conect.abrir_conexion().BeginTransaction("simpleTrans");
        try
        {
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Transaction = trans;
            command.Parameters.Add("@id_usuario", SqlDbType.VarChar, 10);
            command.Parameters["@id_usuario"].Value = id_usuario;
            command.ExecuteNonQuery();
            trans.Commit();
            a = false;
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
    
     public Usuarios login(string usuario, string password)
    {
        Usuarios user = new Usuarios();
        String query = "SELECT * from usuarios WHERE id_usuario = @id_usuario AND contrasennia = HashBytes('MD5','" + password+"');"; //buscar como hacerlo con parámetros
        Conexion conect = new Conexion();

        SqlCommand command = new SqlCommand(query,conect.abrir_conexion());
        command.CommandType = CommandType.Text;
        try
        {
            
            command.Connection = conect.abrir_conexion();
            command.CommandText = query;
            command.Parameters.Add("@id_usuario", SqlDbType.VarChar, 10);
            command.Parameters["@id_usuario"].Value = usuario;
            //command.Parameters.Add("@contrasennia", SqlDbType.VarChar, 30);
            //command.Parameters["@contrasennia"].Value = password;
            SqlDataReader rowReader = command.ExecuteReader();
            if (rowReader.HasRows)
            {
                
                while (rowReader.Read()) {
                    user.Id_usuario = rowReader["id_usuario"].ToString();
                    user.Id_empresa = (int)rowReader["id_empresa"];
                    user.Id_tipo = (int)rowReader["id_tipo"];
                    //user.Contrasennia = rowReader["contrasennia"].ToString();
                    user.Nombre = rowReader["nombre"].ToString();
                    //return user;
                }
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
        return user;

    }

}
