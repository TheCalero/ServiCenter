using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Ventas_servicio
/// </summary>
public interface Ventas_servicio
{
    List<Ventas> Listar_ventasPree(string id_usuario, int estado);
    int Agregar_venta(Ventas venta);
    int Agregar_detalleVentas(Detalle_ventas ventadetails);
}