using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Cliente_servicio
/// </summary>
public interface Cliente_servicio
{
    int agregar(Clientes cliente);

    List<Clientes> Listar_clientes(int id_empresa);

    int actualizar(Clientes cliente);
}
