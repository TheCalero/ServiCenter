using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    class descuento
    {
        private Int32 id_descuento;
        private decimal valor;
        private string descripcion;

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
