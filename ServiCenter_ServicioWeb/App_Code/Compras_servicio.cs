using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Cliente_servicio
/// </summary>
public interface Compras_servicio
{
    int agregar_compras(Compras compras);

    List<Compras> Listar_compras();

    int actualizar_compras(Compras compras);
}
