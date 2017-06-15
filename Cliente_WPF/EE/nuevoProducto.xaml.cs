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

namespace Cliente_WPF.EE
{
    /// <summary>
    /// Lógica de interacción para nuevoProducto.xaml
    /// </summary>
    public partial class nuevoProducto : Window
    {
        

        //Constructor para la ventada de un nuevo registro de producto
        public nuevoProducto()
        {
            InitializeComponent();
            Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();


            lblIdProducto.Content = "ID";
            btnEliminar.Visibility = Visibility.Hidden;
            llenarCmbs();
            dtgPrecios.Columns[1].Visibility = Visibility.Hidden;
            dtgPrecios.ItemsSource = web.Listar_tipoClientes(sesion.id_empresa);

         

        }

        //Constructor para la ventana de actualizar
        public nuevoProducto(int id_producto, string nombreProducto, int id_proveedor, decimal precioCosto, string fraccion, int contenido, string descripcion)
        {
            InitializeComponent();
            Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
            dtgPrecios.Columns[0].Visibility = Visibility.Hidden;


            llenarCmbs();
            lblIdProducto.Content = Convert.ToString(id_producto);
            txtNombre.Text = nombreProducto;
            cmbProveedor.SelectedValue = id_proveedor;
            lblProveedor.Content = cmbProveedor.SelectedValue;
            txtPrecioCosto.Text = Convert.ToString(precioCosto);
            dtgPrecios.ItemsSource = web.Listar_precios(id_producto);
         

            if (fraccion != "")
            {
                checkFraccion.IsChecked = true;
                txtUnidad.Text = fraccion;
                txtContenido.Text = Convert.ToString(contenido);

            }
            else
            {
                checkFraccion.IsChecked = false;
                txtUnidad.IsEnabled = false;
                txtContenido.IsEnabled = false;
                txtUnidad.Text = fraccion;
                txtContenido.Text = Convert.ToString(contenido);
            }

            txtDescripcion.Text = descripcion;
        }



        public void llenarCmbs()
        {
            Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
            cmbProveedor.ItemsSource = web.Listar_proveedores(sesion.id_empresa);
            cmbProveedor.DisplayMemberPath = "Nombre";
            cmbProveedor.SelectedValuePath = "Id_proveedor";


        } //Llena el CMB proveedor

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } //Boton de Cancelar (Cierra la ventana).

        private void CheckBox_Checked(object sender, RoutedEventArgs e) //Habilita los textbox cuando la venta por fraccion esta activada
        {
            txtUnidad.IsEnabled = true;
            txtContenido.IsEnabled = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) //Desabilita los textbox respectivos cuando la venta por fraccion esta deshabilitada en un producto
        {
          
            txtUnidad.IsEnabled = false;
            txtContenido.IsEnabled = false;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) //Cambia el ID de proveedor al ValueMember que este seleccionado en el cmbProveedor
        {
            lblProveedor.Content = cmbProveedor.SelectedValue;
        }


        //Boton de Guardar Nuevo/Actualizar
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();

            
            if (lblIdProducto.Content.ToString() == "ID")  //Validacion para saber si es un nuevo producto o se esta actualizando
            {
                try
                {
                    //Validaciones GUARDAR
                    if (txtNombre.Text == "")
                    {
                        MessageBox.Show("El campo nombre es obligatorio", "Integridad de datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else if (txtPrecioCosto.Text == "")
                    {
                        MessageBox.Show("El campo 'Precio Costo' es obligatorio.", "Integridad de datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        if (checkFraccion.IsChecked == true &&  txtUnidad.Text == "")
                        {
                            MessageBox.Show("El campo 'Unidad' es obligatorio", "Integridad de Datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }

                        else if (checkFraccion.IsChecked == true && txtContenido.Text == "")
                        {
                            MessageBox.Show("El campo 'Contenido' es obligatorio.", "Integridad de Datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }

                        else
                        {
                            int cond = 0;
                            for (int i = 0; i < dtgPrecios.Items.Count - 1; i++)
                            {
                                var precio = (Servicio.Tipos_clientes)dtgPrecios.Items[i];
                                if (precio.Precio_venta == 0)
                                {
                                    cond = 1;
                                }
                            }

                            if (cond == 1)
                            {

                                MessageBox.Show("Los precios del producto deben ser mayores a cero.", "Integridad de Datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            }
                            else
                            {
                                int contenido = 0;
                                string fraccion = "";
                                if (checkFraccion.IsChecked == true)
                                {
                                    contenido = int.Parse(txtContenido.Text);
                                    fraccion = txtUnidad.Text;
                                }

                                int idProduct = web.Agregar_productos(sesion.id_usuario, txtNombre.Text, txtDescripcion.Text, int.Parse(lblProveedor.Content.ToString()), Decimal.Parse(txtPrecioCosto.Text), 1, fraccion, contenido);
                                for (int i = 0; i < dtgPrecios.Items.Count; i++)
                                    {
                                    
                                    var tc = (Servicio.Tipos_clientes)dtgPrecios.Items[i];
                                    web.Agregar_precios(idProduct, tc.Id_tipo, sesion.id_empresa, tc.Precio_venta);
                                    }

                                MessageBox.Show("El producto se ha registrado satisfactoriamente.", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                        }
                    }
                }

                catch (Exception exe)
                {
                    MessageBox.Show("Se ha producido un error al guaradar: " + exe + " Revise su conexion a Internet e intente de vueo", "Error al guardar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            //ACTUALIZAR
            else
            {
                if (txtNombre.Text == "")
                {
                    MessageBox.Show("El campo nombre es obligatorio", "Integridad de datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (txtPrecioCosto.Text == "")
                {
                    MessageBox.Show("El campo 'Precio Costo' es obligatorio.", "Integridad de datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    if (checkFraccion.IsChecked == true && txtUnidad.Text == "")
                    {
                        MessageBox.Show("El campo 'Unidad' es obligatorio", "Integridad de Datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }

                    else if (checkFraccion.IsChecked == true && txtContenido.Text == "")
                    {
                        MessageBox.Show("El campo 'Contenido' es obligatorio.", "Integridad de Datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }

                
                else
                {
                    int cond = 0;
                    for (int i = 0; i < dtgPrecios.Items.Count - 1; i++)
                    {
                        var precio = (Servicio.Precios)dtgPrecios.Items[i];
                        if (precio.Precio_venta == 0)
                        {
                            cond = 1;
                        }
                    }

                    if (cond == 1)
                    {
                        MessageBox.Show("Los precios del producto deben ser mayores a cero.", "Integridad de Datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    else
                    {
                        try
                        {



                            for (int i = 0; i < dtgPrecios.Items.Count; i++)
                            {
                                var precio = (Servicio.Precios)dtgPrecios.Items[i];

                                web.actualizar_precios(precio.Id_precio, precio.Precio_venta);
                            }
                                int contenido = 0;
                                string fraccion = "";
                                if (checkFraccion.IsChecked == true)
                                {
                                    contenido = int.Parse(txtContenido.Text);
                                    fraccion = txtUnidad.Text;
                                }
                             
                            web.actualizar_productos(sesion.id_usuario, int.Parse(lblIdProducto.Content.ToString()), txtNombre.Text, txtDescripcion.Text, int.Parse(lblProveedor.Content.ToString()), Decimal.Parse(txtPrecioCosto.Text), 1, fraccion, contenido);

                            MessageBox.Show("Se ha actualizado el producto", "Registro", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Error al actualizar" + err + " Por favor verifique su conexion a Internet e intentelo de nuevo", "Error en la aplicacion", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            
        }
            }
        }
        private void dtgPrecios_KeyDown(object sender, KeyEventArgs e) //Valida que solo se acepten numeros, backspace, Del y puntos decimales en los precios
        {
           
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Decimal || e.Key == Key.OemPeriod || e.Key == Key.Back || e.Key == Key.Delete)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtContenido_KeyDown(object sender, KeyEventArgs e) //Valida que solo se acepten numeros, Backspace y Del en el campo Contenido
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 ||  e.Key == Key.Back || e.Key == Key.Delete)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //Boton de Eliminar (Actualiza el estado del registro a 0)
        {
            Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
            try { 
            web.actualizar_productos(sesion.id_usuario, int.Parse(lblIdProducto.Content.ToString()), txtNombre.Text, txtDescripcion.Text, int.Parse(lblIdProducto.Content.ToString()), Decimal.Parse(txtPrecioCosto.Text), 0, txtUnidad.Text, int.Parse(txtContenido.Text));
                MessageBox.Show("El producto se ha eliminado correctamente", "Operacion Exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error al eliminar" + excep, "Error al eliminar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
