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
    /// Lógica de interacción para nuevoUsuario.xaml
    /// </summary>
    public partial class nuevoUsuario : Window
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public nuevoUsuario()
        {
            InitializeComponent();
            validar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void validar()
        {
            if(txtNombre.Text.Length > 3 && txtUser.Text.Length >1 && password.Password.Length > 1 && (radioTipoGid.IsChecked == true || radioTipoPos.IsChecked == true))
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

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            validar();
        }

        private void radioTipoGid_Checked(object sender, RoutedEventArgs e)
        {
            validar();
        }

        int tipo;
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(radioTipoGid.IsChecked == true)
            {
                tipo = 3;
            }
            else {
                tipo = 2;
            }
            if(web.Agregar_usuario(txtUser.Text, sesion.id_empresa, tipo, password.Password, txtNombre.Text) == 1)
            {
                MessageBox.Show("El usuario ha sido registrado satisfactoriamente", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error al registrar", "Operacion fallida", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
