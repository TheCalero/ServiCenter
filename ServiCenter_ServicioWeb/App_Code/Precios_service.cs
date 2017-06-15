using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Precios_service
/// </summary>
public interface Precios_service
{
    int agregar(Precios precios);

    List<Precios> Listar_precios(Precios prec);

    int actualizar(Precios precios);
    Decimal retornarprecioventa(int id_producto);
}