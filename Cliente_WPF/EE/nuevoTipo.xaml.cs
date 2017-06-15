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
    /// Lógica de interacción para nuevoTipo.xaml
    /// </summary>
    public partial class nuevoTipo : Window
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public nuevoTipo()
        {
            InitializeComponent();
            btnEliminar.Visibility = Visibility.Hidden;
            lblIdTipo.Content = "Id Tipo";
        }

        public nuevoTipo(int idTipo, string nombre, string descripcion)
        {
            InitializeComponent();
            lblIdTipo.Content = idTipo.ToString();
            txtNombreTipo.Text = nombre;
            txtDescripcion.Text = descripcion;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Eliminar
        {
            try
            {
                web.actualizar_tiposClientes(sesion.id_usuario, int.Parse(lblIdTipo.Content.ToString()), sesion.id_empresa, txtNombreTipo.Text, txtDescripcion.Text, 0);
                MessageBox.Show("El tipo de cliente ha sido eliminado", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception exep)
            {
                MessageBox.Show("Error al eliminar tipo de cliente, revise su conexion a internet. " + exep, "Operacion fallida", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtNombreTipo.Text == "")
            {
                MessageBox.Show("El cambo nombre de tipo cliente no puede quedar vacio", "Integridad de datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {

            
            if(lblIdTipo.Content.ToString() != "Id Tipo")
            {
                try { 
                web.actualizar_tiposClientes(sesion.id_usuario, int.Parse(lblIdTipo.Content.ToString()), sesion.id_empresa, txtNombreTipo.Text, txtDescripcion.Text, 1);
                    MessageBox.Show("El tipo de cliente ha sido actualizado", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch(Exception exepc)
                    {
                        MessageBox.Show("Error al actualizar tipo de cliente. " + exepc, "Operacion fallida", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            else
                {
                    try
                    {
                        web.Agregar_tipoCliente(sesion.id_empresa, txtNombreTipo.Text, txtDescripcion.Text, sesion.id_usuario, 1);
                        MessageBox.Show("Se ha agregado un nuevo tipo de usuario", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error al agregar tipo de cliente. " + ex, "Operacion fallida", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
