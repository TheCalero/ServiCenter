using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Proveedores_service
/// </summary>
public interface Proveedores_service
{
    int agregar(Proveedores proveedores, string id_usuario);

    List<Proveedores> Listar_proveedores(int id_empresa);

    int actualizar(Proveedores proveedores, string id_usuario);
}