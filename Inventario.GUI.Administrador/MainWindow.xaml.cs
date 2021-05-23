using Inventario.BIZ;
using Inventario.DAL;
using Inventarioo.COMMON.Entidades;
using Inventarioo.COMMON.Interfaces;
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

namespace Inventario.GUI.Administrador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }

        IManejadorEmpleados manejadorEmpleados;

        accion accionEmpleados;
        public MainWindow()
        {
            InitializeComponent();

            manejadorEmpleados = new ManejadorEmpleados(new RepositorioDeEmpleados());

            PonerBotonesEmpleadosEnEdicion(false);
            LimpiarCamposDeEmpleados();       
            ActualizarTablaEmpleados();
        }

        private void ActualizarTablaEmpleados()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = manejadorEmpleados.Listar;
        }

        private void LimpiarCamposDeEmpleados()
        {
            txbEmpleadosApellidos.Clear();
            txbEmpledosArea.Clear();
            txbEmpleadosId.Text = "";
            txbEmpleadosNombre.Clear();
        }

        private void PonerBotonesEmpleadosEnEdicion(bool value)
        {
            btnEmpleadosCancelar.IsEnabled = value;
            btnEmpleadosEditar.IsEnabled = !value;
            btnEmpleadosEliminar.IsEnabled = !value;
            btnEmpleadosGuardar.IsEnabled = value;
            btnEmpleadosNuevo.IsEnabled = !value;
        }

        private void BtnEmpleadosNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados();
            PonerBotonesEmpleadosEnEdicion(true);
            accionEmpleados = accion.Nuevo;
        }

        private void BtnEmpleadosEditar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = dtgEmpleados.SelectedItem as Empleado;
            if (emp != null)
            {
                txbEmpleadosId.Text = emp.Id;
                txbEmpleadosApellidos.Text = emp.Apellidos;
                txbEmpledosArea.Text = emp.Area;
                txbEmpleadosNombre.Text = emp.Nombre;
                accionEmpleados = accion.Editar;
                PonerBotonesEmpleadosEnEdicion(true);
            }       
        }

        private void BtnEmpleadosGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(accionEmpleados== accion.Nuevo)
            {
                Empleado emp = new Empleado()
                {
                    Nombre = txbEmpleadosNombre.Text,
                    Apellidos = txbEmpleadosApellidos.Text,
                    Area = txbEmpledosArea.Text
                };
                if (manejadorEmpleados.Agregar(emp))
                {
                    MessageBox.Show("Empleado agregado correctamente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEmpleados();
                    ActualizarTablaEmpleados();
                    PonerBotonesEmpleadosEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Empleado no se puedo agregar", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empleado emp = dtgEmpleados.SelectedItem as Empleado;
                emp.Apellidos = txbEmpleadosApellidos.Text;
                emp.Area = txbEmpledosArea.Text;
                emp.Nombre = txbEmpleadosNombre.Text;
                if(manejadorEmpleados.Modificar(emp))
                {
                    MessageBox.Show("Empleado modificado correctamente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEmpleados();
                    ActualizarTablaEmpleados();
                    PonerBotonesEmpleadosEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Empleado no se puedo actualizar", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void BtnEmpleadosCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados();
            PonerBotonesEmpleadosEnEdicion(false);
        }

        private void BtnEmpleadosEliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = dtgEmpleados.SelectedItem as Empleado;
            if(emp!=null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este empleado?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEmpleados.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Empleado eliminado", "InventarioS", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("No se puedo eliminar el empleado", "InventarioS", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

        }
    }
}
