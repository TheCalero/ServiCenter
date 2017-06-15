using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Conexion
/// </summary>
public class Conexion
{
    private SqlConnection conect = null;
    public Conexion()
    {
        string cadena_de_conexion = "Data Source=DELL-INSPIRON15;Initial Catalog=DBVentas;Integrated Security=True";
        //E: Data Source=PROJECT1\\SQLEXPRESS;Persist Security Info=False;Integrated Security=SSPI;Initial Catalog=DBVentas
        //M: Data Source=DELL-INSPIRON15;Initial Catalog=DBVentas;Integrated Security=True
        conect = new SqlConnection(cadena_de_conexion);

        try
        {
            conect.Open();
        }
        catch (Exception ex)
        {
            throw new Exception("Error ", ex);
        }
    }
    public SqlConnection abrir_conexion()
    {
        return conect;
    }

    public void cerrar_conexion()
    {
        if (conect != null)
        { conect.Close(); }
    }

}