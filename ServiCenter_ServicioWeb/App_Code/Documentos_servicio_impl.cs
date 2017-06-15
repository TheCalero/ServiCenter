using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Documentos_servicio_impl
/// </summary>
public class Documentos_servicio_impl : Documentos_servicio
{
    Conexion conect = null;
    public Documentos_servicio_impl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public List<Documentos> listar_documentos(int id_empresa)
    {
        List<Documentos> lst = new List<Documentos>(0);
        conect = new Conexion();
        SqlCommand command = new SqlCommand("SELECT * FROM documentos WHERE id_empresa = @id_empresa", conect.abrir_conexion());
        command.Parameters.Add("@id_empresa", SqlDbType.Int);
        command.Parameters["@id_empresa"].Value = id_empresa;
        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            Documentos doc = new Documentos();
            doc.Id_documento = read.GetInt32(0);
            doc.Id_empresa = read.GetInt32(1);
            doc.Nombre = read.GetString(2);
            doc.Descripcion = read.GetString(3);


            lst.Add(doc);
        }
        read.Close();
        conect.cerrar_conexion();
        return lst;

    }

}