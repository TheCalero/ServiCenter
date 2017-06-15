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
    /// Lógica de interacción para nuevoCliente.xaml
    /// </summary>
    public partial class nuevoCliente : Window
    {

        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public nuevoCliente()
        {
            InitializeComponent();
            lnlIdCliente.Content = "ID Cliente";
            btnEliminar.Visibility = Visibility.Hidden;
        }

        public nuevoCliente(int id_cliente, string nombre, string apellidos, string direccion, string correo, string numTel, string dui, string nit)
        {
            InitializeComponent();
            lnlIdCliente.Content = id_cliente;
            txtNombre.Text = nombre;
            txtApellidos.Text = apellidos;
            txtDireccion.Text = direccion;
            txtCorreo.Text = correo;
            txtTelefono.Text = numTel;
            txtDui.Text = dui;
            txtNit.Text = nit;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Boton cancelar
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if(web.actualizar_cliente(int.Parse(lnlIdCliente.Content.ToString()), txtNombre.Text, txtApellidos.Text, txtDireccion.Text, txtCorreo.Text, txtTelefono.Text, txtDui.Text, txtNit.Text, 0) == 1)
                {
                    MessageBox.Show("El cliente ha sido eliminado", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al eliminar   " + ex, "Operacion fallida", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show("El cambo nombre no puede quedar vacio", "Integridad de datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if(lnlIdCliente.Content.ToString() == "ID Cliente")
                {
                    try
                    {
                        web.Agregar_cliente(sesion.id_empresa, txtNombre.Text, txtApellidos.Text, txtDireccion.Text, txtCorreo.Text, txtTelefono.Text, txtDui.Text, txtNit.Text);
                        MessageBox.Show("El cliente ha sido registrado", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al registrar cliente, por favor revise su conexion a internet e intentelo de nueo...   " + ex, "Operacion Fallida", MessageBoxButton.OK, MessageBoxImage.Error);

                    } 
                }
                else
                {
                    try { 
                    web.actualizar_cliente(int.Parse(lnlIdCliente.Content.ToString()), txtNombre.Text, txtApellidos.Text, txtDireccion.Text, txtCorreo.Text, txtTelefono.Text, txtDui.Text, txtNit.Text, 1);
                        MessageBox.Show("El cliente se ha actualizado", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar cliente, por favor revise su conexion a internet e intentelo de nueo...   " + ex, "Operacion Fallida", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
            }
        }
    }
}
