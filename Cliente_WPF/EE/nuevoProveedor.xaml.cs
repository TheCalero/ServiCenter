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
    /// Lógica de interacción para nuevoProveedor.xaml
    /// </summary>
    public partial class nuevoProveedor : Window
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public nuevoProveedor() //Constructor para insertar un nuevo registro
        {
            InitializeComponent();
            lblIdProveedor.Content = "ID";
            btnEliminar.Visibility = Visibility.Hidden;
        }

        public nuevoProveedor(int id, string nombre, string direccion, string telefono, string correo, string nrc, string nit)
        {
            InitializeComponent();
            lblIdProveedor.Content = id;
            txtProveedor.Text = nombre;
            txtDireccion.Text = direccion;
            txtTelefono.Text = telefono;
            txtCorreo.Text = correo;
            txtNrc.Text = nrc;
            txtNit.Text = nit;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Boton eliminar
        {
            try
            {
                web.actualizar_proveedores(int.Parse(lblIdProveedor.Content.ToString()), sesion.id_empresa, sesion.id_usuario, txtProveedor.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, txtNrc.Text, txtNit.Text, 0);
                MessageBox.Show("Se ha eliminado el proveedor", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }
            catch (Exception exe)
            {
                MessageBox.Show("Error al eliminar, por favor revise su conexion. " + exe, "Operacion Fallida", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(txtProveedor.Text == "")
            {
                MessageBox.Show("El campo nombre proveedor no puede quedar vacio", "Integridad de datos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else { 
            if (lblIdProveedor.Content.ToString() != "ID")
            {
                try {
                    web.actualizar_proveedores(int.Parse(lblIdProveedor.Content.ToString()), sesion.id_empresa, sesion.id_usuario, txtProveedor.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, txtNrc.Text, txtNit.Text, 1);
                    MessageBox.Show("Se ha actualizado el proveedor", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                }
                catch(Exception exe)
                {
                    MessageBox.Show("Error al actualizar, por favor revise su conexion. " + exe, "Operacion Fallida", MessageBoxButton.OK, MessageBoxImage.Error);   
                }



            }
            else { 
            try
                {
                    web.Agregar_proveedor(sesion.id_empresa, sesion.id_usuario, txtProveedor.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, txtNrc.Text, txtNit.Text);
                        MessageBox.Show("Se ha registrado el proveedor", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (Exception except)
                    {
                        MessageBox.Show("Error al agregar proveedor, por favor revise su conexion" + except, "Operacion Fallida", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    }
            }
        }
    }
}
