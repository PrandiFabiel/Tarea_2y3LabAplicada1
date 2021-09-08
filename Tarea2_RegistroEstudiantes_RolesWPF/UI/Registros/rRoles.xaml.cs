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
    /// <summary>
    /// Interaction logic for rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
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

        private Roles Rol = new Roles();
       // private RolesBLL RolBll = new RolesBLL(); 

        public rRoles()
        {
            InitializeComponent();

            this.DataContext = Rol;
        }

        private bool ValidarRol()
        {
            bool esValido = true;

            if (RolesBLL.ExisteRol(Rol.Descripcion))
            {
                esValido = false;
                MessageBox.Show("La descripcion ya existe", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Rellena los campos vacios", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void Limpiar()
        {
            this.Rol = new Roles();
            this.DataContext = Rol;
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarRol())
                return;
            if (!Validar())
                return;

            var paso = RolesBLL.Guardar(Rol);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado exitoso!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Guardado Fallido", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
 
            if (RolesBLL.Eliminar(Utilidades.ToInt(RolIdTextBox.Text)))
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

