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
    /// Lógica de interacción para regTipoCliente.xaml
    /// </summary>
    public partial class regTipoCliente : Page
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public regTipoCliente()
        {
            InitializeComponent();
            llenarDtgTipos();

        }

        public void llenarDtgTipos()
        {
            dtgTipoDecliente.ItemsSource = web.Listar_tipoClientes(sesion.id_empresa);
        }

        private void dtgTipoDecliente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var tpc = (Servicio.Tipos_clientes)dtgTipoDecliente.SelectedItem;
            if (tpc != null)
            {
                nuevoTipo newTipo = new nuevoTipo(tpc.Id_tipo, tpc.NombreTipo, tpc.Descripcion);
                newTipo.ShowInTaskbar = false;
                newTipo.Owner = (homeAdmin)Parent;
                newTipo.Closing += new System.ComponentModel.CancelEventHandler(nuevoTipo_closing);
                newTipo.ShowDialog();
                

            }
        }

        public void nuevoTipo_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            llenarDtgTipos();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nuevoTipo newTipo = new nuevoTipo();
            newTipo.ShowInTaskbar = false;
            newTipo.Owner = (homeAdmin)Parent;
            newTipo.Closing += new System.ComponentModel.CancelEventHandler(nuevoTipo_closing);
            newTipo.ShowDialog();
        }
    }
}
