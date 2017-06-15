using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiCenter_Modelo;

/// <summary>
/// Descripción breve de Usuario_servicio
/// </summary>
public interface Usuario_servicio
{
    int agregar(Usuarios usuario);

    List<Usuarios> Listar_usuarios(int id_empresa);

    int actualizar(Usuarios usuario);

    bool existe_usuario(string id_usuario);
    bool contraDiferente(string contra_antigua, string id_usuario);
    Usuarios login(string usuario, string password);

}