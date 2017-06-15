using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Cargo_servicio
/// </summary>
public interface Cargo_servicio
{

    int agregar(Cargo cargo);

    List<Cargo> Listar_cargos(int id_empresa);

    int actualizar(Cargo cargo);

}
