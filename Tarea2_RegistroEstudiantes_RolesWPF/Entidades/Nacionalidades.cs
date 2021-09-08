using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tarea2_RegistroEstudiantes_RolesWPF.Entidades
{
    public class Nacionalidades
    {
        [Key]
        public int NacionalidadId { get; set; }
        public string Nacionalidad { get; set; }
    }
}
