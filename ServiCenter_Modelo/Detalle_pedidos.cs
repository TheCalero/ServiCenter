using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Detalle_pedidos
    {
        private Int32 id_detalle_pedido;
        private Int32 id_pedido;
        private Int32 cantidad;
        private Int32 id_producto;
        private DateTime fechaVen;

        public int Id_detalle_pedido
        {
            get
            {
                return id_detalle_pedido;
            }

            set
            {
                id_detalle_pedido = value;
            }
        }

        public int Id_pedido
        {
            get
            {
                return id_pedido;
            }

            set
            {
                id_pedido = value;
            }
        }

        public int Cantidad
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

        public DateTime FechaVen
        {
            get
            {
                return fechaVen;
            }

            set
            {
                fechaVen = value;
            }
        }
    }
}
