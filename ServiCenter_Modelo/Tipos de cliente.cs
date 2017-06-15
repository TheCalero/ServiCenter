using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    class Tipos_de_cliente
    {
        private Int32 id_tipos;
        private String tipo_nombre;
        private String descripcion;

        public int Id_tipos
        {
            get
            {
                return id_tipos;
            }

            set
            {
                id_tipos = value;
            }
        }

        public string Tipo_nombre
        {
            get
            {
                return tipo_nombre;
            }

            set
            {
                tipo_nombre = value;
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
