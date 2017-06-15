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
    /// Lógica de interacción para regEmpleado.xaml
    /// </summary>
    public partial class regEmpleado : Page
    {
        Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();
        public regEmpleado()
        {
            InitializeComponent();
            llenarDtgEmpleados();

        }

        public void llenarDtgEmpleados()
        {
            dtgEmpleado.ItemsSource = web.Listar_empleados(sesion.id_empresa);
        }

        private void dtgEmpleado_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var emp = (Servicio.Empleados)dtgEmpleado.SelectedItem;
            nuevoEmpleado newEmployee = new nuevoEmpleado(emp.Id_empleado, emp.Nombre, emp.Apellidos, emp.Direccion, emp.Dui, emp.Id_cargo, emp.NombreCargo, emp.Id_usuario);
            newEmployee.ShowInTaskbar = false;
            newEmployee.Owner = (homeAdmin)Parent;
            newEmployee.Closing += new System.ComponentModel.CancelEventHandler(nuevoEmpleado_closing);
            newEmployee.ShowDialog();
        }

        public void nuevoEmpleado_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            llenarDtgEmpleados();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nuevoEmpleado newEmpleado = new nuevoEmpleado();
            newEmpleado.ShowInTaskbar = false;
            newEmpleado.Owner = (homeAdmin)Parent;
            newEmpleado.Closing += new System.ComponentModel.CancelEventHandler(newEmpleado_closing);
            newEmpleado.ShowDialog();

        }

        public void newEmpleado_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            llenarDtgEmpleados();
        }
    }
}
