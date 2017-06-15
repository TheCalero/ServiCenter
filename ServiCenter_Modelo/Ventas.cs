using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Ventas
    {
        private Int32 id_venta;
        private String id_usuario;
        private Int32 id_cliente;
        private Int32 id_tiraje;
        private Int32 id_empleado;
        private Int32 corrActual;
        private Int32 estado;
        private Int32 id_Documento;
        private String nombre_cliente;
        private String apellido_cliente;
        private String nombre_tipoDocumento;
        private String nombre_estado;
        private Decimal total;

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

        public int Id_cliente
        {
            get
            {
                return id_cliente;
            }

            set
            {
                id_cliente = value;
            }
        }

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

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
                if (value == 0)
                    Nombre_estado = "En cola";
                else if (value == 1)
                    Nombre_estado = "Completado";
                else
                    Nombre_estado = "Nulo";
            }
        }

        public int Id_Documento
        {
            get
            {
                return Id_Documento1;
            }

            set
            {
                Id_Documento1 = value;
            }
        }

        public int Id_Documento1
        {
            get
            {
                return id_Documento;
            }

            set
            {
                id_Documento = value;
            }
        }

        public string Nombre_cliente
        {
            get
            {
                return nombre_cliente;
            }

            set
            {
                nombre_cliente = value;
            }
        }

        public string Nombre_tipoDocumento
        {
            get
            {
                return nombre_tipoDocumento;
            }

            set
            {
                nombre_tipoDocumento = value;
            }
        }

        public string Nombre_estado
        {
            get
            {
                return nombre_estado;
            }

            set
            {
                nombre_estado = value;
            }
        }

        public decimal Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public string Apellido_cliente
        {
            get
            {
                return apellido_cliente;
            }

            set
            {
                apellido_cliente = value;
            }
        }
    }
}

