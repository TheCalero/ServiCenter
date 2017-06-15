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
    /// Lógica de interacción para homePos.xaml
    /// </summary>
    public partial class homePos : Window
    {

        public homePos()
        {
            InitializeComponent();
            listar_ventas();
            lblUser.Content = sesion.nombre;
        }
        private void btnStats_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnMasterPrd_Click(object sender, RoutedEventArgs e)
        {

        }
        private void logo_MouseDown(object sender, RoutedEventArgs e)
        {

        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
                listar_ventas();
        }
        private void listar_ventas()
        {
            framePOS.Navigate(new Uri("MM/POS/Listar_ventas.xaml", UriKind.Relative));
            this.btnVentas.IsEnabled = false;
            this.btnInventarios.IsEnabled = true;
            this.btnClientes.IsEnabled = true;
        }

        private void btnInventarios_Click(object sender, RoutedEventArgs e)
        {
            framePOS.Navigate(new MM.POS.Inventarios());
            this.btnVentas.IsEnabled = true;
            this.btnInventarios.IsEnabled = false;
            this.btnClientes.IsEnabled = true;
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            framePOS.Navigate(new MM.POS.Clientes());
            this.btnVentas.IsEnabled = true;
            this.btnInventarios.IsEnabled = true;
            this.btnClientes.IsEnabled = false;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            MM.POS.Nueva_venta nuevaven = new MM.POS.Nueva_venta();
            nuevaven.ShowInTaskbar = false;
            nuevaven.Owner = (homeAdmin)Parent;
            nuevaven.ShowDialog();
        }
    }
}
