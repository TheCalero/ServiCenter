using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Eventos_servicio
/// </summary>
public interface Eventos_servicio
{
    int agregar(Eventos eventos);

    List<Eventos> Listar_eventos(int id_empresa);

}