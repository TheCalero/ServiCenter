using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Pedidos
    {
        private Int32 id_pedido;
        private String id_usuarioEmisor;
        private String id_usuarioReceptor;
        private String fecha;
        private Int32 estado;
        private Int32 id_empleado;
        private String descripcion;
        private String nombreProducto;
        private String nombreEmpleado;

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

        public string Id_usuarioEmisor
        {
            get
            {
                return id_usuarioEmisor;
            }

            set
            {
                id_usuarioEmisor = value;
            }
        }

        public string Id_usuarioReceptor
        {
            get
            {
                return id_usuarioReceptor;
            }

            set
            {
                id_usuarioReceptor = value;
            }
        }

        public string Fecha
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

        public int Id_empleado
        {
            get
            {
                return id_empleado;
            }

            set
            {
                id_empleado = value;
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

        public string NombreEmpleado
        {
            get
            {
                return nombreEmpleado;
            }

            set
            {
                nombreEmpleado = value;
            }
        }
    }
}
