using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cliente_WPF.EE
{
    /// <summary>
    /// Lógica de interacción para nuevoDescuento.xaml
    /// </summary>
    public partial class nuevoDescuento : Window
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public nuevoDescuento()
        {
            InitializeComponent();
            validar();
        }

        public nuevoDescuento(int idDescuento, string valor, string descripcion)
        {
            InitializeComponent();
            lblIdDescuento.Content = idDescuento;
            txtValor.Text = valor;
            txtDescripcion.Text = descripcion;
        }

        public void validar()
        {
            if(txtValor.Text.Length !=0 && txtDescripcion.Text.Length > 4)
            {
                btnGuardar.IsEnabled = true;
            }
            else
            {
                btnGuardar.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtValor_TextChanged(object sender, TextChangedEventArgs e)
        {
            validar();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            decimal valor = decimal.Parse(txtValor.Text) / 100;
            if (lblIdDescuento.Content.ToString() != "ID Descuento")
            {
               
                if (web.actualizar_descuento(int.Parse(lblIdDescuento.Content.ToString()), valor, txtDescripcion.Text) == 1) {
                    MessageBox.Show("Se ha actualizado el descuento", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar", "Operacion fallida", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if(web.agregar_descuento(valor, txtDescripcion.Text, sesion.id_empresa) == 1)
                {
                    MessageBox.Show("Se ha agregado el descuento", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar descuento", "Operacion fallida", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
