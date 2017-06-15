using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Empleado_service
/// </summary>
public interface Empleado_service
{
    int agregar(Empleados empleado);

    List<Empleados> Listar_empleados(int id_empresa);

    int actualizar(Empleados empleado);
}