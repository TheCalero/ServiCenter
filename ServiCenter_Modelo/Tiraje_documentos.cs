using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Tiraje_documentos
    {
        private Int32 id_tiraje;
        private Int32 id_documento;
        private Int32 num_tiraje;
        private DateTime fecha;
        private Int32 inicio;
        private Int32 fin;
        private String id_usuario;
        private Int32 corrActual;
        private String descripcion;

        public int Id_tiraje
        {
            get
            {
                return id_tiraje;
            }

            set
            {
                id_tiraje = value;
            }
        }

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

        public int Num_tiraje
        {
            get
            {
                return num_tiraje;
            }

            set
            {
                num_tiraje = value;
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

        public int Inicio
        {
            get
            {
                return inicio;
            }

            set
            {
                inicio = value;
            }
        }

        public int Fin
        {
            get
            {
                return fin;
            }

            set
            {
                fin = value;
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

        public int CorrActual
        {
            get
            {
                return corrActual;
            }

            set
            {
                corrActual = value;
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
