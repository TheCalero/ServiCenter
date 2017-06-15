using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiCenter_Modelo
{
    class servicios
    {
        private Int32 id_servicios;
        private string nombre;
        private string descripcion;
        private decimal precio;

        public int Id_servicios
        {
            get
            {
                return id_servicios;
            }

            set
            {
                id_servicios = value;
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

        public decimal Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }
    }
}
