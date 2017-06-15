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

namespace Cliente_WPF.EE
{
    /// <summary>
    /// Lógica de interacción para regProveedor.xaml
    /// </summary>
    public partial class regProveedor : Page
    {
        public regProveedor()
        {
            InitializeComponent();
            llenarGridProveedor();
        }

        public void llenarGridProveedor()
        {
            Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
            dtgProveedor.ItemsSource = web.Listar_proveedores(sesion.id_empresa);
           
        }

        private void dtgProveedor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var proveedor = (Servicio.Proveedores)dtgProveedor.SelectedItem;
            if (proveedor != null)
            {
                nuevoProveedor newProveedor = new nuevoProveedor(proveedor.Id_proveedor, proveedor.Nombre, proveedor.Direccion, proveedor.Num_telefono, proveedor.Correo, proveedor.Nrc, proveedor.Nit);
                newProveedor.ShowInTaskbar = false;
                newProveedor.Owner = (homeAdmin)Parent;
                newProveedor.Closing += new System.ComponentModel.CancelEventHandler(nuevoProducto_closing);
                newProveedor.ShowDialog();

            }
        }

        public void nuevoProducto_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            llenarGridProveedor();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nuevoProveedor newProveedor = new nuevoProveedor();
            newProveedor.ShowInTaskbar = false;
            newProveedor.Owner = (homeAdmin)Parent;
            newProveedor.Closing += new System.ComponentModel.CancelEventHandler(nuevoProducto_closing);
            newProveedor.ShowDialog();
        }
    }
}
