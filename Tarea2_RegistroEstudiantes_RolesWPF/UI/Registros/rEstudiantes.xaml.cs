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
using Tarea2_RegistroEstudiantes_RolesWPF.BLL;
using Tarea2_RegistroEstudiantes_RolesWPF.Entidades;

namespace Tarea2_RegistroEstudiantes_RolesWPF.UI.Registros
{
    public partial class rEstudiantes : Window
    {

        public class DateFormat : System.Windows.Data.IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null) return null;

                return ((DateTime)value).ToString("dd/MM/yyyy");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private Estudiantes Estudiante = new Estudiantes();


        public rEstudiantes()
        {
            InitializeComponent();


            // Asignar la instancia del al formulario para usarla en BINDINGS
            this.DataContext = Estudiante;

            //Cargar las nacionalidades al ComboBox
            //NacionalidadesComboBox.ItemsSource = NacionalidadesBLL.GetNacionalidades();
            //NacionalidadesComboBox.SelectedValuePath = "NacionalidadId";
            //NacionalidadesComboBox.DisplayMemberPath = "Nacionalidad";
        }

        private void Limpiar()
        {
            this.Estudiante = new Estudiantes();
            this.DataContext = Estudiante;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }




        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var estudiante = EstudiantesBLL.Buscar(Utilidades.ToInt(EstudianteIdTextBox.Text));

            if (estudiante != null)
                this.Estudiante = estudiante;
            else
                this.Estudiante = new Estudiantes();

            this.DataContext = this.Estudiante;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = EstudiantesBLL.Guardar(Estudiante);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EstudiantesBLL.Eliminar(Utilidades.ToInt(EstudianteIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
