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
    /// Lógica de interacción para nuevoEmpleado.xaml
    /// </summary>
    public partial class nuevoEmpleado : Window
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        int pas;
        public nuevoEmpleado()
        {
            InitializeComponent();
            pas = 1;
            llenarCmbs();
            btnEliminar.IsEnabled = false;
            forCapa8();
        }

        public nuevoEmpleado(int idEmpleado, string nombre, string apellidos, string direccion, string dui, int idCargo, string nombreCargo, string id_Usuario)
        {
            InitializeComponent();
            pas = 2;
            lblIdEmpleado.Content = idEmpleado;
            txtNombres.Text = nombre;
            txtApellidos.Text = apellidos;
            txtDireccion.Text = direccion;
            txtDui.Text = dui;
            btnGuardar.IsEnabled = true;
            llenarCmbs();
            cmbCargo.SelectedValue = idCargo;
            lblIdCargo.Content = cmbCargo.SelectedValue;
            cmbSucursal.SelectedValue = id_Usuario;
            lblIdSucursal.Content = cmbSucursal.SelectedValue;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void llenarCmbs()
        {
            cmbCargo.ItemsSource = web.Listar_cargos(sesion.id_empresa);
            cmbCargo.DisplayMemberPath = "Nombre";
            cmbCargo.SelectedValuePath = "Id_cargo";
            cmbSucursal.ItemsSource = web.Listar_usuarios(sesion.id_empresa);
            cmbSucursal.DisplayMemberPath = "Nombre";
            cmbSucursal.SelectedValuePath = "Id_usuario";
        }

        private void cmbCargo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblIdCargo.Content = cmbCargo.SelectedValue;
            if (pas == 1)
                forCapa8();
        }

        private void cmbSucursal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblIdSucursal.Content = cmbSucursal.SelectedValue;
            if (pas == 1)
                forCapa8();
        }
        private void forCapa8()
        {
            if (txtNombres.Text.Length > 2 && txtApellidos.Text.Length > 2 && lblIdCargo.Content.ToString() != "Id cargo" && lblIdSucursal.Content.ToString() != "Id Sucursal")
                btnGuardar.IsEnabled = true;
            else
                btnGuardar.IsEnabled = false;
        }

        private void txtDui_TextChanged(object sender, TextChangedEventArgs e)
        { 
            forCapa8();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (lblIdEmpleado.Content.ToString() == "ID")
            {
                if (web.Agregar_empleado(txtNombres.Text, txtApellidos.Text, txtDireccion.Text, txtDui.Text, int.Parse(lblIdCargo.Content.ToString()), lblIdSucursal.Content.ToString()) == 1)
                { MessageBox.Show("Se ha agregado exitosamente", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information); this.Close(); }

                else { MessageBox.Show("Ha ocurrido un error", "Operacion no exitosa", MessageBoxButton.OK, MessageBoxImage.Error); }
                

            }
            else
            {
                if (web.actualizar_empleado(int.Parse(lblIdEmpleado.Content.ToString()), txtNombres.Text, txtApellidos.Text, txtDireccion.Text, txtDui.Text, int.Parse(lblIdCargo.Content.ToString()), lblIdSucursal.Content.ToString(), 1) == 1)
                { MessageBox.Show("Se ha agregado exitosamente", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information); this.Close(); }

                else { MessageBox.Show("Ha ocurrido un error", "Operacion no exitosa", MessageBoxButton.OK, MessageBoxImage.Error); }

            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (web.actualizar_empleado(int.Parse(lblIdEmpleado.Content.ToString()), txtNombres.Text, txtApellidos.Text, txtDireccion.Text, txtDui.Text, int.Parse(lblIdCargo.Content.ToString()), lblIdSucursal.Content.ToString(), 0) == 1)
            { MessageBox.Show("Se ha eliminado exitosamente", "Operacion exitosa", MessageBoxButton.OK, MessageBoxImage.Information); this.Close(); }

            else { MessageBox.Show("Ha ocurrido un error", "Operacion no exitosa", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
