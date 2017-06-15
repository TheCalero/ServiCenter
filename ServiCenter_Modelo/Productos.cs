using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Productos
    {
        private Int32 id_producto;
        private String nombre;
        private String descripcion;
        private Int32 id_proveedor;
        private Decimal precio_costo;
        private Int32 estado;
        private String fraccion;
        private Int32 contenido;
        private String nombreProveedor;
        private Int32 cantidad;
        private Decimal precioU;
        private String descuento;
        private Decimal subT;
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

        public int Id_proveedor
        {
            get
            {
                return id_proveedor;
            }

            set
            {
                id_proveedor = value;
            }
        }

        public decimal Precio_costo
        {
            get
            {
                return precio_costo;
            }

            set
            {
                precio_costo = value;
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

        public string Fraccion
        {
            get
            {
                return fraccion;
            }

            set
            {
                fraccion = value;
            }
        }

        public int Contenido
        {
            get
            {
                return contenido;
            }

            set
            {
                contenido = value;
            }
        }

        public string NombreProveedor
        {
            get
            {
                return nombreProveedor;
            }

            set
            {
                nombreProveedor = value;
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

        public decimal PrecioU
        {
            get
            {
                return precioU;
            }

            set
            {
                precioU = value;
            }
        }

        public string Descuento
        {
            get
            {
                return descuento;
            }

            set
            {
                descuento = value;
            }
        }

        public decimal SubT
        {
            get
            {
                return subT;
            }

            set
            {
                subT = value;
            }
        }

    }
}
