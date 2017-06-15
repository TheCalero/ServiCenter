using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Mensajeria
    {
        private Int32 id_mensaje;
        private String emisor;
        private String receptor;
        private DateTime fecha;
        private Int32 prioridad;
        private String mensaje;

        public int Id_mensaje
        {
            get
            {
                return id_mensaje;
            }

            set
            {
                id_mensaje = value;
            }
        }

        public string Emisor
        {
            get
            {
                return emisor;
            }

            set
            {
                emisor = value;
            }
        }

        public string Receptor
        {
            get
            {
                return receptor;
            }

            set
            {
                receptor = value;
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

        public int Prioridad
        {
            get
            {
                return prioridad;
            }

            set
            {
                prioridad = value;
            }
        }

        public string Mensaje
        {
            get
            {
                return mensaje;
            }

            set
            {
                mensaje = value;
            }
        }
    }
}
