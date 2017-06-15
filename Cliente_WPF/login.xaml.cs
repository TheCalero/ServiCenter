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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cliente_WPF
{

    public static class sesion
    {
        static public String id_usuario { get; set; }
        static public Int32 id_empresa { get; set; }
        static public Int32 id_tipo { get; set; }
        static public String nombre { get; set; }


    }

    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
            txtUser.Focus();

        }

        private void txtUser_GotFocus(object sender, RoutedEventArgs e)
        {

            txtUser.SelectAll();
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text != "" && txtPassword.Text != "")
            {
                Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
                Servicio.Usuarios n = (Servicio.Usuarios)web.login(txtUser.Text, txtPassword.Text);
                if (n.Id_tipo != 0)
                {
                    sesion.id_usuario = n.Id_usuario;
                    sesion.id_empresa = n.Id_empresa;
                    sesion.id_tipo = n.Id_tipo;
                    sesion.nombre = n.Nombre;
                    switch (sesion.id_tipo)
                    {
                        case 1:
                            homeAdmin homeAd = new homeAdmin();
                            homeAd.Show();
                            break;
                        case 2:
                            homeGID gid = new homeGID();
                            gid.Show();
                            break;
                        case 3:
                            homePos pos = new homePos();
                            pos.Show();
                            break;
                        default:
                            MessageBox.Show("Su usuario ah sido dado de baja del sistema. Imposible proceder.", "Mensaje del sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;

                    }

                }
                else
                {
                    MessageBox.Show("El usuario y/o la contraseña que ha ingresado son incorrectos.", "Credenciales Incorrectas", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un usuario y una contraseña", "Faltan datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}