using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Detalle_ventas 
    {
        private Int32 id_detalle_deventa;
        private Int32 id_venta;
        private Decimal cantidad;
        private Int32 id_producto;
        private Int32 id_descuento;
        private Int32 id_tipoCliente;
        private Decimal precio_producto;

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

        public int Id_tipoCliente
        {
            get
            {
                return id_tipoCliente;
            }

            set
            {
                id_tipoCliente = value;
            }
        }

        public decimal Precio_producto
        {
            get
            {
                return precio_producto;
            }

            set
            {
                precio_producto = value;
            }
        }
    }
}
