using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Compras
    {
        private Int32 id_compra;
        private Int32 correlativo;
        private Int32 id_proveedor;
        private DateTime fecha;
        private String id_usuario;
        private decimal total;
        private decimal saldo;
        private String nombre_proveedor;

        public int Id_compra
        {
            get
            {
                return id_compra;
            }

            set
            {
                id_compra = value;
            }
        }

        public int Correlativo
        {
            get
            {
                return correlativo;
            }

            set
            {
                correlativo = value;
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

        public DateTime Fecha
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

        public decimal Saldo
        {
            get
            {
                return saldo;
            }

            set
            {
                saldo = value;
            }
        }

        public string Nombre_proveedor
        {
            get
            {
                return nombre_proveedor;
            }

            set
            {
                nombre_proveedor = value;
            }
        }
    }
}
