using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Inventarios
    {
        private Int32 id_inventarios;
        private String id_usuario;
        private Int32 cantidad;
        private Int32 id_producto;
        private DateTime fechaVen;
        private String nombreProducto;

        public int Id_inventarios
        {
            get
            {
                return id_inventarios;
            }

            set
            {
                id_inventarios = value;
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
    }
}
