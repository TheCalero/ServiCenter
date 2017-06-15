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
    /// Lógica de interacción para regUsuario.xaml
    /// </summary>
    public partial class regUsuario : Page
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public regUsuario()
        {
            InitializeComponent();
            llenarDtg();
        }


    public void llenarDtg()
        {
            dtgUsuario.ItemsSource = null;
            dtgUsuario.ItemsSource = web.Listar_usuarios(sesion.id_empresa);
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nuevoUsuario newUser = new nuevoUsuario();
            newUser.ShowInTaskbar = false;
            newUser.Owner = (Window)this.Parent;
            newUser.Closing += new System.ComponentModel.CancelEventHandler(nuevoUsuario_closing);
            newUser.ShowDialog();
        }

        public void nuevoUsuario_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            llenarDtg();
        }
    }
}
