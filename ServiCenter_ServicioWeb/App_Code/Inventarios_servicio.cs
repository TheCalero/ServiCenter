using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;
/// <summary>
/// Descripción breve de Inventarios_servicio
/// </summary>
public interface Inventarios_servicio
{
    int agregar(Inventarios inventarios, string id_usuario, int id_empleado);

    List<Inventarios> Listar_inventariosSuc(int id_empresa, string id_usuario);

    List<Inventarios> Listar_inventarios(int id_empresa);

    int actualizar(Inventarios inventarios, string id_usuario, int id_empleado);


}