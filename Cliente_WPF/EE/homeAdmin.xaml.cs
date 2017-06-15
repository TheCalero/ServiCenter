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

namespace Cliente_WPF
{
    /// <summary>
    /// Lógica de interacción para homeAdminxaml.xaml
    /// </summary>
    public partial class homeAdmin : Window
    {
        public homeAdmin()
        {
            InitializeComponent();
            lbl.Content = "Bienvenido, ";
            lblUser.Content = sesion.nombre;
       

        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
        
        }

        private void btnMasterPrd_Click(object sender, RoutedEventArgs e)
        {
            rectangle.Fill = Brushes.DarkSlateBlue;
            lblUser.Visibility = Visibility.Hidden;
            lbl.Content = "Master de Productos";
            MyHost.Navigate(new EE.regProducto());
        }

        private void logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lbl.Content = "Bienvenido, ";
            lblUser.Content = sesion.id_usuario;
            rectangle.Fill = Brushes.Black;
            lblUser.Visibility = Visibility.Visible;
        }

    

       

     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                lblUser.Visibility = Visibility.Hidden;
                rectangle.Fill = Brushes.Indigo;
                lbl.Content = "Master de Proveedores";
                MyHost.Navigate(new EE.regProveedor());
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lblUser.Visibility = Visibility.Hidden;
            rectangle.Fill = Brushes.Coral;
            lbl.Content = "Tipos de Clientes";
            MyHost.Navigate(new EE.regTipoCliente());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            lblUser.Visibility = Visibility.Hidden;
            rectangle.Fill = Brushes.DarkOrange;
            lbl.Content = "Master de Clientes";
            MyHost.Navigate(new EE.regCliente());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            sesion.id_empresa = 0;
            sesion.id_usuario = null;
            sesion.id_tipo = 0;
            sesion.nombre = null;
            Iniciar iniciar = new Iniciar();
            iniciar.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            lblUser.Visibility = Visibility.Hidden;
            rectangle.Fill = Brushes.DarkTurquoise;
            lbl.Content = "Master de Clientes";
            MyHost.Navigate(new EE.regEmpleado());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) //Abre cargos
        {
            lblUser.Visibility = Visibility.Hidden;
            rectangle.Fill = Brushes.Blue;
            lbl.Content = "Mantenimiento de cargos";
            MyHost.Navigate(new EE.regCargo());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            lblUser.Visibility = Visibility.Hidden;
            rectangle.Fill = Brushes.CadetBlue;
            lbl.Content = "Sucursales y almacenes";
            MyHost.Navigate(new EE.regUsuario());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            lblUser.Visibility = Visibility.Hidden;
            rectangle.Fill = Brushes.Chocolate;
            lbl.Content = "Descuentos y promociones";
            MyHost.Navigate(new EE.regDescuentos());
        }
    }
}
