using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Tipos_clientes
    {
        private Int32 id_tipo;
        private Int32 id_empresa;
        private String nombreTipo;
        private String descripcion;
        private Int32 estado;
        private decimal precio_venta;
        public int Id_tipo
        {
            get
            {
                return id_tipo;
            }

            set
            {
                id_tipo = value;
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

        public string NombreTipo
        {
            get
            {
                return nombreTipo;
            }

            set
            {
                nombreTipo = value;
            }
        }

        public int Estado
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

        public decimal Precio_venta
        {
            get
            {
                return precio_venta;
            }

            set
            {
                precio_venta = value;
            }
        }
    }
}
