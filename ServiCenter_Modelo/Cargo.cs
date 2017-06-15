using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Cargo
    {
        private Int32 id_cargo;
        private Int32 id_empresa;
        private String nombre;
        private Boolean gid;
        private Boolean pos;
        private String descripcion;

        public int Id_empresa
        {
            get { return id_empresa; }
            set { id_empresa = value; }
        }

        public int Id_cargo
        {
            get
            {
                return id_cargo;
            }

            set
            {
                id_cargo = value;
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

        public Boolean Gid
        {
            get
            {
                return gid;
            }

            set
            {
                gid = value;
            }
        }

        public Boolean Pos
        {
            get
            {
                return pos;
            }

            set
            {
                pos = value;
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
