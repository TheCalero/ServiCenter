using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Documentos
    {
        private Int32 id_documento;
        private Int32 id_empresa;
        private String nombre;
        private String descripcion;

        public int Id_documento
        {
            get
            {
                return id_documento;
            }

            set
            {
                id_documento = value;
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

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
    }
}
