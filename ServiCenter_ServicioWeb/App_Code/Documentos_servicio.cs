using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Documentos_servicio
/// </summary>
public interface Documentos_servicio
{
    List<Documentos> listar_documentos(int id_empresa);
}