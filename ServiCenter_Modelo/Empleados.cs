using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Empleados
    {
        private Int32 id_empleado;
        private String contrasennia;
        private String nombre;
        private String apellidos;
        private String direccion;
        private String dui;
        private Int32 id_cargo;
        private String nombreCargo;
        private String id_usuario;
        private String nombreSuc;
        private Int32 estado;

        public String NombreSuc
        {
            get { return nombreSuc; }
            set { nombreSuc = value; }
        }

        public String NombreCargo
        {
            get {return nombreCargo;}
            set {nombreCargo = value;}
        }

        public int Id_empleado
        {
            get
            {
                return id_empleado;
            }

            set
            {
                id_empleado = value;
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

        public string Apellidos
        {
            get
            {
                return apellidos;
            }

            set
            {
                apellidos = value;
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

        public string Dui
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

        public Int32 Id_cargo
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

        public Int32 Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}
