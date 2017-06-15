using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Descuentos_servicio
/// </summary>
public interface Descuentos_servicio
{
    int agregar_descuento(Descuentos descuento);

    List<Descuentos> Listar_descuentos(int id_empresa);

    int actualizar_descuento(Descuentos descuento);
}