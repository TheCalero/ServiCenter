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
    /// Lógica de interacción para regCargoxaml.xaml
    /// </summary>
    public partial class regCargo : Page
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public regCargo()
        {
            InitializeComponent();
            llenarDtg();
        }

        public void llenarDtg()
        {
            dtgCargo.ItemsSource = web.Listar_cargos(sesion.id_empresa);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nuevoCargo newCargo = new nuevoCargo();
            newCargo.ShowInTaskbar = false;
            newCargo.Owner = (Window)this.Parent;
            newCargo.Closing += new System.ComponentModel.CancelEventHandler(nuevoCargo_closing);
            newCargo.ShowDialog();
        }

        public void nuevoCargo_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            llenarDtg();
        }

        private void dtgCargo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var cargo = (Servicio.Cargo)dtgCargo.SelectedItem;
            if (cargo != null)
            {
                nuevoCargo newCargo = new nuevoCargo(cargo.Id_cargo, cargo.Nombre, cargo.Gid, cargo.Pos, cargo.Descripcion);
                newCargo.ShowInTaskbar = false;
                newCargo.Owner = (Window)this.Parent;
                newCargo.Closing += new System.ComponentModel.CancelEventHandler(nuevoCargo_closing);
                newCargo.ShowDialog();
            }
        }
    }
}
