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
    /// Lógica de interacción para regCliente.xaml
    /// </summary>
    public partial class regCliente : Page
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public regCliente()
        {
            InitializeComponent();
            llenarDtgClientes();
        

        }

        public void llenarDtgClientes()
        {
            dtgClientes.ItemsSource = web.Listar_clientes(sesion.id_empresa);
        }

        private void dtgProductos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var cliente = (Servicio.Clientes) dtgClientes.SelectedItem;
            if (cliente != null)
            {
                nuevoCliente newClient = new nuevoCliente(cliente.Id_cliente, cliente.Nombre, cliente.Apellido, cliente.Direccion, cliente.Correo, cliente.Num_telefono, cliente.Num_dui, cliente.Num_nit);
                newClient.ShowInTaskbar = false;
                newClient.Owner = (homeAdmin)Parent;
                newClient.Closing += new System.ComponentModel.CancelEventHandler(nuevoCliente_closing);
                newClient.ShowDialog();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nuevoCliente newClient = new nuevoCliente();
            newClient.ShowInTaskbar = false;
            newClient.Owner = (homeAdmin)Parent;
            newClient.Closing += new System.ComponentModel.CancelEventHandler(nuevoCliente_closing);
            newClient.ShowDialog();
        }

        public void nuevoCliente_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            llenarDtgClientes();

        }

        
    }
}
