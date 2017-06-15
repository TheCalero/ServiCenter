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

namespace Cliente_WPF
{
    /// <summary>
    /// Lógica de interacción para Nuevo_pedido.xaml
    /// </summary>
    
    public partial class Nuevo_pedido : Window
    {
        public Nuevo_pedido()
        {
            InitializeComponent();
            Servicio.ServiceSoapClient web = new Servicio.ServiceSoapClient();//instancío el servicio web
            Servicio.Pedidos pedidos = web.agregarPedido(sesion.id_usuario); //instancío el modelo de pedidos, con el objeto que me devuelve el metodo agregarPedido()
            if (pedidos.Id_pedido != 0)
            {
                this.lblNumPedido.Content = "PEDIDO Nº 0" + pedidos.Id_pedido; //asigo el numero del id del pedido al label
                DateTime dt = new DateTime(Int64.Parse(pedidos.Fecha)); //recupero el string con Ticks y los convierto 
                txtFecha.Text = dt.ToString(); //le agrego la fecha, convirtiendo a string
                cmbHechoPor.Items.Insert(0, sesion.id_usuario);
                cmbHechoPor.SelectedIndex = 0;
                cmbEstado.Items.Add("En proceso");//quizas también haya que cambiar esto, también xD
                cmbEstado.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Ha currido un error al inicializar. Por favor, intentelo de nuevo.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
                Nuevo_pedido n = new Nuevo_pedido();
                n.Close();
            }

        }
    }
}
