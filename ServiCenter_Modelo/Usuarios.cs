using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Usuarios
    {
        private String id_usuario;
        private Int32 id_empresa;
        private Int32 id_tipo;
        private String contrasennia;
        private String nombre;
        private String nombre_empresa;
        private String nombreTipo;
        public string NombreTipo
        {
            get { return nombreTipo; }
            set { nombreTipo = value; }
        }

        public string Id_usuario
        {
            get
            {
                return id_usuario;
            }

            set
            {
                id_usuario = value;
            }
        }

        public int Id_empresa
        {
            get
            {
                return id_empresa;
            }

            set
            {
                id_empresa = value;
            }
        }

        public int Id_tipo
        {
            get
            {
                return id_tipo;
            }

            set
            {
                id_tipo = value;
            }
        }

        public string Contrasennia
        {
            get
            {
                return contrasennia;
            }

            set
            {
                contrasennia = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Nombre_empresa
        {
            get
            {
                return nombre_empresa;
            }

            set
            {
                nombre_empresa = value;
            }
        }
    }
}
