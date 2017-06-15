using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Productos_service
/// </summary>
public interface Productos_service
{
    int agregar(Productos productos, string id_usuario);

    List<Productos> Listar_productos(int id_empresa);

    int actualizar(Productos productos, string id_usuario);

}