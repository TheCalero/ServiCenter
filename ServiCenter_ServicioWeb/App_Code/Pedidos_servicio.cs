using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Pedidos_servicio
/// </summary>
public interface Pedidos_servicio
{
    int obtenerid(string id_usuarioEmisor, string fecha);
    int crear_pedido(Pedidos pedido);

    int agregar (Pedidos pedidos);
    List<Pedidos> Listar_pedidos(int id_empresa);
    int actualizar(Pedidos pedidos);

}