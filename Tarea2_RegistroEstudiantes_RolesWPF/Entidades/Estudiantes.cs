using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tarea2_RegistroEstudiantes_RolesWPF.Entidades
{
    public class Estudiantes
    {

        [Key]
        public int EstudianteId { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public string Nombres { get; set; }
        public int Semestre { get; set; }
        public float PuntosExtra { get; set; }

    }
}
