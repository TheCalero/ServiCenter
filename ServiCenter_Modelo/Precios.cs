using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Precios
    {
        private Int32 id_precio;
        private Int32 id_producto;
        private String nombreProducto;
        private Int32 id_tipo;
        private String nombreTipo;
        private Int32 id_empresa;
        private Decimal precio_venta;
        private String retornar;
        public int Id_precio
        {
            get
            {
                return id_precio;
            }

            set
            {
                id_precio = value;
            }
        }

        public int Id_producto
        {
            get
            {
                return id_producto;
            }

            set
            {
                id_producto = value;
            }
        }

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

        public string NombreProducto
        {
            get
            {
                return nombreProducto;
            }

            set
            {
                nombreProducto = value;
            }
        }

        public string Retornar
        {
            get
            {
                return retornar;
            }

            set
            {
                retornar = value;
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
    }
}
