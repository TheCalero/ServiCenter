using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Empresas
    {
        private Int32 id_empresa;
        private String nombre;
        private String giro;
        private String nit;
        private String propietario;
        private String nrc;
        private String pais;

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

        public string Giro
        {
            get
            {
                return giro;
            }

            set
            {
                giro = value;
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

        public string Propietario
        {
            get
            {
                return propietario;
            }

            set
            {
                propietario = value;
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

        public string Pais
        {
            get
            {
                return pais;
            }

            set
            {
                pais = value;
            }
        }
    }
}
