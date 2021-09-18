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
    public partial class rUsuarios : Window
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



        private Usuarios Usuario = new Usuarios(); 
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = Usuario;

            //Tomando los datos del combobox de roles
            RolesComboBox.ItemsSource = RolesBLL.GetRoles();
            RolesComboBox.SelectedValuePath = "RolId";
            RolesComboBox.DisplayMemberPath = "Descripcion"; 
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var estudiante = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));

            if (Usuario != null)
                this.Usuario = estudiante;
            else
                Limpiar();

            this.DataContext = this.Usuario;
        }

        private void Limpiar()
        {
            this.Usuario = new Usuarios();
            ClavePasswordBox.Password = string.Empty;
            ConfirmarClavePasswordBox.Password = string.Empty;
            this.DataContext = Usuario;
        }


        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar(); 
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuariosBLL.Guardar(Usuario);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado exitoso!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallida al guardar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado con exito", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombres está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (AliasTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Alias está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                AliasTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (EmailTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Email está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ClavePasswordBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Clave está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ClavePasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarClavePasswordBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Confirmar clave está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarClavePasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarClavePasswordBox.Password != ClavePasswordBox.Password)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Las claves no coiciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarClavePasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }


            return esValido;
        }
    } 
}
