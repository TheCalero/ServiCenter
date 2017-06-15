using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Proveedores
    {
        private Int32 id_proveedor;
        private Int32 id_empresa;
        private String nombre;
        private String direccion;
        private String num_telefono;
        private String correo;
        private String nrc;
        private String nit;
        private Int32 estado;

        public int Id_proveedor
        {
            get
            {
                return id_proveedor;
            }

            set
            {
                id_proveedor = value;
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

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Num_telefono
        {
            get
            {
                return num_telefono;
            }

            set
            {
                num_telefono = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public string Nrc
        {
            get
            {
                return nrc;
            }

            set
            {
                nrc = value;
            }
        }

        public string Nit
        {
            get
            {
                return nit;
            }

            set
            {
                nit = value;
            }
        }

        public int Estado {
            get {
                return estado;
            }
            set {
                estado = value;
            }
        }
    }
}
