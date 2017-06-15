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

namespace Cliente_WPF.MM.POS
{
    /// <summary>
    /// Lógica de interacción para Listar_ventas.xaml
    /// </summary>
    public partial class Listar_ventas : Page
    {
        public Listar_ventas()
        {
            InitializeComponent();
            //llenargrid(1);
        }

        private void chkPendientes_Checked(object sender, RoutedEventArgs e)
        {
            //dtgVentas.Items.Clear();
            //llenargrid(1);
        }
        private void chkPendientes_Unchecked(object sender, RoutedEventArgs e)
        {
            //dtgVentas.Items.Clear();
            //llenargrid(2);
        }

        private void llenargrid(int estado)
        {
            Servicio.ServiceSoapClient ws = new Servicio.ServiceSoapClient();
            dtgVentas.ItemsSource = ws.Listar_ventasPree(sesion.id_usuario, estado);//cambiar
        }

    }
}
