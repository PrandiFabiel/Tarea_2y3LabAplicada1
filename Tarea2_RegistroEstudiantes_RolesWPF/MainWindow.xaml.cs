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
using Tarea2_RegistroEstudiantes_RolesWPF.UI.Registros;
using Tarea2_RegistroEstudiantes_RolesWPF.BLL;

namespace Tarea2_RegistroEstudiantes_RolesWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EstudianteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rEstudiantes rEstudiantes = new UI.Registros.rEstudiantes();
            rEstudiantes.Show();
        }

        private void ConsultaEstudianteMenuItem_Click(object sender, RoutedEventArgs e)
        {


        }

        private void NacionalidadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void RolMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRoles rRoles = new UI.Registros.rRoles();
            rRoles.Show();
        }
    }
}
