using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tarea2_RegistroEstudiantes_RolesWPF.Entidades
{
    public class Adicionales
    {
        [Key]
        public int AdicionalId { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteId { get; set; }
        public float Puntos { get; set; }
    }
}
