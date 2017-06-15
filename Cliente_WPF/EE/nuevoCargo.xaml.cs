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
    /// Lógica de interacción para nuevoCargo.xaml
    /// </summary>
    public partial class nuevoCargo : Window
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();

        Boolean pos;
        Boolean gid;
        public nuevoCargo()
        {
            InitializeComponent();
            validar();
            checkGID.IsChecked = false;
            checkPOS.IsChecked = false ;
            lblIdCargo.Content = "ID Cargo";
        }

        public nuevoCargo(int id_cargo, string nombre_cargo, Boolean gid, Boolean pos, string descripcion)
        {
            InitializeComponent();

            lblIdCargo.Content = id_cargo;
            txtNombre.Text = nombre_cargo;
            if (gid == true)
            {
                
                checkGID.IsChecked = true;
            }
            else
            {
                checkGID.IsChecked = false;
            }
            if (pos == true)
            {
                checkPOS.IsChecked = true;
            }
            else
            {
                checkPOS.IsChecked = false;
            }
            validar();
            txtDescripcion.Text = descripcion;
        }

        public void validar()
        {
            if(txtNombre.Text.Length > 2)
            {
                btnGuardar.IsEnabled = true;
            }
            else
            {
                btnGuardar.IsEnabled = false;
            }
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            validar();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

     

        private void checkGID_Checked(object sender, RoutedEventArgs e)
        {
            gid = true;
        }

        private void checkGID_Unchecked(object sender, RoutedEventArgs e)
        {
            gid = false;
        }

        private void checkPOS_Checked(object sender, RoutedEventArgs e)
        {
            pos = true;
        }

        private void checkPOS_Unchecked(object sender, RoutedEventArgs e)
        {
            pos = false;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (lblIdCargo.Content.ToString() != "ID Cargo")
            {
                if(web.actualizar_cargo(int.Parse(lblIdCargo.Content.ToString()), txtNombre.Text, gid, pos, txtDescripcion.Text, sesion.id_empresa) == 1)
                {
                    MessageBox.Show("El cargo ha sido actualizado", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el cargo", "Operacion fallida", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if(web.Agregar_cargo(txtNombre.Text, gid, pos, txtDescripcion.Text, sesion.id_empresa) == 1)
                {
                    MessageBox.Show("El cargo se ha agregado correctamente", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar cargo", "Operacion fallida", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
