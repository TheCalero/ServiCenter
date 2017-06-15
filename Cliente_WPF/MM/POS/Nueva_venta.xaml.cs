using System;
using System.Collections;
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

namespace Cliente_WPF.MM.POS
{
    /// <summary>
    /// Lógica de interacción para Nueva_venta.xaml
    /// </summary>
    
    public partial class Nueva_venta : Window
    {
        Servicio.Productos productoseleccionado = new Servicio.Productos();
        Servicio.Clientes clienteseleccionado = new Servicio.Clientes();
        Servicio.Tipos_clientes tiposeleccionado = new Servicio.Tipos_clientes();
        Servicio.Detalle_ventas detalleventas = new Servicio.Detalle_ventas();
        Servicio.Descuentos descuentoseleccionado = new Servicio.Descuentos();
        Servicio.Tiraje_documentos tirajeseleccionado = new Servicio.Tiraje_documentos();
        Servicio.Documentos documentoseleccionado = new Servicio.Documentos();
        Servicio.ServiceSoapClient ws = new Servicio.ServiceSoapClient();
        public Nueva_venta()
        {
            InitializeComponent();
            btnAgregarP.IsEnabled = false;
            expDetalles.Height = 48;
            autoPro.ItemsSource = ws.Listar_productos(sesion.id_empresa); 
            autoPro.ValueMemberPath = "Nombre";
            autoClientes.ItemsSource = ws.Listar_clientes(1);
            autoClientes.ValueMemberPath = "Nombre";
            llenarCmbs();
            cmbDescuento.SelectedIndex = 0;
            cmbTiposClientes.SelectedIndex = 0;
            cmbDocumento.SelectedIndex = 0;
            txtEstado.Text = "En proceso";
        }


        public void llenarCmbs()
        {
            Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
            cmbTiposClientes.ItemsSource = web.Listar_tipoClientes(sesion.id_empresa);
            cmbTiposClientes.DisplayMemberPath = "NombreTipo";
            cmbTiposClientes.SelectedValuePath = "Id_tipo";
            cmbDescuento.ItemsSource = web.Listar_descuentos(sesion.id_empresa);
            cmbDescuento.DisplayMemberPath = "Descripcionvalor";
            cmbDescuento.SelectedValuePath = "Valor";
            cmbDocumento.ItemsSource = web.Listar_documentos(sesion.id_empresa);
            cmbDocumento.DisplayMemberPath = "Nombre";
            cmbDocumento.SelectedValuePath = "Id_documento";
        } //Llena el CMB 
        //subtotal = (precioproducto - (precioproducto * valordescuento)) * numpreo

        private void expDetalles_Expanded(object sender, RoutedEventArgs e)
        {
            expDetalles.Height = 257;
        }

        private void expDetalles_Collapsed(object sender, RoutedEventArgs e)
        {
            expDetalles.Height = 48;
        }

        private void autoPro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            productoseleccionado = (Servicio.Productos)autoPro.SelectedItem;
            if (productoseleccionado != null)
            {
                lblb.Content = "ID producto: " + productoseleccionado.Id_producto;
                if (txtCantidad.Text != "")
                    if (int.Parse(txtCantidad.Text) > 0)
                        { btnAgregarP.IsEnabled = true; }
            }
            else
            { lblb.Content = ""; btnAgregarP.IsEnabled = false; }

        }

        private void autoClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clienteseleccionado = (Servicio.Clientes)autoClientes.SelectedItem;
            if (clienteseleccionado != null)
                lblIdCliente.Content = clienteseleccionado.Id_cliente; 
            else
                lblIdCliente.Content = "";

        }


        private void btnAgregarP_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            if (productoseleccionado != null)
            { 
                productoseleccionado = (Servicio.Productos)autoPro.SelectedItem;
                for(int i = 0; i < dtgProductos.Items.Count; i++)
                {
                    var producto = (Servicio.Productos)dtgProductos.Items[i];
                    if (productoseleccionado.Id_producto == producto.Id_producto)
                    {
                        producto.Cantidad = int.Parse(txtCantidad.Text) + producto.Cantidad;
                        producto.Descuento = "" + descuentoseleccionado.Valor * 100 + "%";
                        producto.SubT = (productoseleccionado.PrecioU - (productoseleccionado.PrecioU * descuentoseleccionado.Valor)) * productoseleccionado.Cantidad;
                        dtgProductos.Items[i] = producto;
                        result = 1;
                        break;
                    }
                }
                if (result == 0) { 
                productoseleccionado.Cantidad = int.Parse(txtCantidad.Text);
                productoseleccionado.PrecioU = ws.retornarPrecioPro(productoseleccionado.Id_producto);
                productoseleccionado.Descuento = ""+descuentoseleccionado.Valor*100+"%";
                productoseleccionado.SubT = (productoseleccionado.PrecioU - (productoseleccionado.PrecioU * descuentoseleccionado.Valor)) * productoseleccionado.Cantidad;
                dtgProductos.Items.Add(productoseleccionado);                
                }
                autoPro.Text = "";
                txtCantidad.Text = "";
                lblb.Content = "";
            }
        }


        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Back || e.Key == Key.Delete)
                e.Handled = false;
            else
                e.Handled = true; 

            }

        private void txtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (productoseleccionado != null && txtCantidad.Text != "" && txtCantidad.Text != null && int.Parse(txtCantidad.Text) > 0 && productoseleccionado.Id_producto != 0)
            {
             btnAgregarP.IsEnabled = true; 
            }
            else
            { btnAgregarP.IsEnabled = false;}
                
            
        }

        private void cmbDescuento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            descuentoseleccionado = (Servicio.Descuentos)cmbDescuento.SelectedItem;
            /*if (descuentoseleccionado != null)
                productoseleccionado.Descuento = descuentoseleccionado.Valor;
            else
                productoseleccionado.Descuento = 0;*/

        }

        private void btnAgregarClientes_Click(object sender, RoutedEventArgs e)
        {
            if(lblIdCliente.Content.ToString() == "" && autoClientes.Text != "")
            {
                
            }
        }

        private void cmbTiposClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tiposeleccionado = (Servicio.Tipos_clientes)cmbTiposClientes.SelectedItem;

        }

        private void btnGuardarventa_Click(object sender, RoutedEventArgs e)
        {
            //añadir montones de IFs antes de esto :v
           // ws.Agregar_venta(sesion.id_usuario, );
        }
    }
}
