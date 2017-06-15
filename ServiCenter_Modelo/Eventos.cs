using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Eventos
    {
        private Int32 id_eventos;
        private Int32 tipo;
        private DateTime fecha;
        private String id_usuario;
        private Int32 id_empleado;
        private String nombre_evento;
        private String descripcion;
        private String nombre_usuario;
        private String nom_empleado;
        private String ape_empleado;
        private String nom_empresa;

        public int Id_eventos
        {
            get
            {
                return id_eventos;
            }

            set
            {
                id_eventos = value;
            }
        }

        public int Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
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

        public int Id_empleado
        {
            get
            {
                return Id_empleado1;
            }

            set
            {
                Id_empleado1 = value;
            }
        }

        public int Id_empleado1
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

        public string Nombre_evento
        {
            get
            {
                return nombre_evento;
            }

            set
            {
                nombre_evento = value;
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

        public string Nombre_usuario
        {
            get
            {
                return nombre_usuario;
            }

            set
            {
                nombre_usuario = value;
            }
        }

        public string Nom_empleado
        {
            get
            {
                return nom_empleado;
            }

            set
            {
                nom_empleado = value;
            }
        }

        public string Ape_empleado
        {
            get
            {
                return ape_empleado;
            }

            set
            {
                ape_empleado = value;
            }
        }

        public string Nom_empresa
        {
            get
            {
                return nom_empresa;
            }

            set
            {
                nom_empresa = value;
            }
        }
    }
}
