using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Mensajeria_service
/// </summary>

public interface Mensajeria_service
{
    int agregar(Mensajeria mensajeria, string id_usuario, int id_empleado);

    List<Mensajeria> Listar_mensajeria(int id_empresa);

    int actualizar(Mensajeria mensajeria, string id_usuario, int id_empleado);
}