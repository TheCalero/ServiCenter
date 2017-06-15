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
    /// Lógica de interacción para Inventarios.xaml
    /// </summary>
    public partial class Inventarios : Window
    {
        public Inventarios()
        {
            InitializeComponent();
        }

        private void txtBuscar_LostFocus(object sender, RoutedEventArgs e)
        {
            sinfoco();
        }
        private void sinfoco()
        {
            if (this.txtBuscar.Text == "")
            { this.txtBuscar.Foreground = Brushes.Gray; this.txtBuscar.Text = "Buscar..."; }
        }
        private void txtBuscar_GotFocus(object sender, RoutedEventArgs e)
        {
            if(this.txtBuscar.Text== "Buscar...")
            { this.txtBuscar.Foreground = Brushes.Black; this.txtBuscar.Text = ""; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sinfoco();
        }

        private void btnNuevo_Pedido_Click(object sender, RoutedEventArgs e)
        {
            Nuevo_pedido pedido = new Nuevo_pedido();
            pedido.Show();
        }
    }
}
