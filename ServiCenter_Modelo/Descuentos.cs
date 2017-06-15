using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    public class Descuentos
    {
        private Int32 id_descuento;
        private Decimal valor;
        private String retornarValor;
        private String descripcion;
        private Int32 id_empresa;
        private String descripcionvalor;

        public string Descripcionvalor
        {
            get
            {
                return descripcionvalor;
            }

            set
            {
                descripcionvalor = value;
            }
        }

        public String RetornarValor
        {
            get { return retornarValor; }
            set { retornarValor = value; }
        }
        public int Id_empresa
        {
            get { return id_empresa;}
            set { id_empresa = value; }
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

        public decimal Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
                decimal operacion = valor * 100;
                RetornarValor = operacion + "%";
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
    }
}
