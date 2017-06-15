using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Clientes
    {
        private Int32 id_cliente;
        private Int32 id_empresa;
        private String nombre;
        private String apellido;
        private String direccion;
        private String correo;
        private String num_telefono;
        private String num_dui;
        private String num_nit;
        private Int32 estado;
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public int Id_cliente
        {
            get
            {
                return id_cliente;
            }

            set
            {
                id_cliente = value;
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

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
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

        public string Num_dui
        {
            get
            {
                return num_dui;
            }

            set
            {
                num_dui = value;
            }
        }

        public string Num_nit
        {
            get
            {
                return num_nit;
            }

            set
            {
                num_nit = value;
            }
        }
    }
}
