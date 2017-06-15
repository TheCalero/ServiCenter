using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    class Detalle_de_ventas
    {
        private Int32 id_detalle_deventa;
        private Int32 id_venta;
        private decimal cantidad;
        private Int32 id_producto;
        private Int32 id_descuento;

        public int Id_detalle_deventa
        {
            get
            {
                return id_detalle_deventa;
            }

            set
            {
                id_detalle_deventa = value;
            }
        }

        public int Id_venta
        {
            get
            {
                return id_venta;
            }

            set
            {
                id_venta = value;
            }
        }

        public decimal Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
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

        public int Id_descuento
        {
            get
            {
                return id_descuento;
            }

            set
            {
                id_descuento = value;
            }
        }
    }
}
