using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    class Cliente
    {
        private string id_clientes;
        private string nombre;
        private string apellido;
        private string direccion;
        private string correo;
        private Int32 telefono;
        private Int32 dui;
        private Int32 nit;

        public string Id_clientes
        {
            get
            {
                return id_clientes;
            }

            set
            {
                id_clientes = value;
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

        public int Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public int Dui
        {
            get
            {
                return dui;
            }

            set
            {
                dui = value;
            }
        }

        public int Nit
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
    }
}
