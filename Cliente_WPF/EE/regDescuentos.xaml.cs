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
    /// Lógica de interacción para regDescuentos.xaml
    /// </summary>
    public partial class regDescuentos : Page
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public regDescuentos()
        {
            InitializeComponent();
            llenarDtg();
        }

        public void llenarDtg()
        {
            dtgDescuento.ItemsSource = web.Listar_descuentos(sesion.id_empresa);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nuevoDescuento newDiscount = new nuevoDescuento();
            newDiscount.ShowInTaskbar = false;
            newDiscount.Owner = (Window)this.Parent;
            newDiscount.Closing += new System.ComponentModel.CancelEventHandler(nuevoDescuento_closing);
            newDiscount.ShowDialog();
        }

        public void nuevoDescuento_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            llenarDtg();
        }

        private void dtgDescuento_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var descuento = (Servicio.Descuentos)dtgDescuento.SelectedItem;
            if (descuento != null) { 
            nuevoDescuento newDiscount = new nuevoDescuento(descuento.Id_descuento, descuento.RetornarValor.TrimEnd('%'), descuento.Descripcion);
            newDiscount.ShowInTaskbar = false;
            newDiscount.Owner = (Window)this.Parent;
            newDiscount.Closing += new System.ComponentModel.CancelEventHandler(nuevoDescuento_closing);
            newDiscount.ShowDialog();
            }
        }
    }
}
