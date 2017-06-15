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
    /// Lógica de interacción para regProductoxaml.xaml
    /// </summary>
    public partial class regProducto : Page
    {
        public regProducto()
        {
            InitializeComponent();

            llenarGridProductos();
        }

        public void llenarGridProductos()
        {
            Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
            dtgProductos.ItemsSource = web.Listar_productos(sesion.id_empresa);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nuevoProducto newProduct = new nuevoProducto();
            newProduct.ShowInTaskbar = false;
            newProduct.Owner = (homeAdmin)Parent;
            newProduct.Closing += new System.ComponentModel.CancelEventHandler(nuevoProducto_closing);
            newProduct.ShowDialog();
            
    
        }

        private void dtgProductos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var producto = (Servicio.Productos) dtgProductos.SelectedItem;
            if (producto != null)
            {
                nuevoProducto newProduct = new nuevoProducto(producto.Id_producto,producto.Nombre,producto.Id_proveedor,producto.Precio_costo,producto.Fraccion,producto.Contenido,producto.Descripcion);
                newProduct.ShowInTaskbar = false;
                newProduct.Owner = (homeAdmin)Parent;
                newProduct.Closing += new System.ComponentModel.CancelEventHandler(nuevoProducto_closing);
                newProduct.ShowDialog();
                
            }

        }


        public void nuevoProducto_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            llenarGridProductos();

        }

    }
}
