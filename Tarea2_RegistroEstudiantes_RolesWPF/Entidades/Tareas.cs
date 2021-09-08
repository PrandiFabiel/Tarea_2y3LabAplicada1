using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea2_RegistroEstudiantes_RolesWPF.Entidades
{
    public class Tareas
    {
        [Key]
        public int TareaId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public float Puntos { get; set; }

        [ForeignKey("TareaId")]
        public List<TareasDetalle> Detalle { get; set; } = new List<TareasDetalle>();
    }
}
