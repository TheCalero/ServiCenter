using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de TiposCliente_Service
/// </summary>
public interface TiposCliente_Service
{
    int agregar(Tipos_clientes tipoCliente, string id_usuario);

    List<Tipos_clientes> Listar_tiposClientes(int id_empresa);

    int actualizar(Tipos_clientes tipoClient, string id_usuario);
}