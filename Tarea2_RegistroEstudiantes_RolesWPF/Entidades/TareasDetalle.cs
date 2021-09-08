using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tarea2_RegistroEstudiantes_RolesWPF.Entidades
{
    public class TareasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int TareaId { get; set; }
        public string Requerimiento { get; set; }
        public float Valor { get; set; }

        public TareasDetalle(int tareaId, string requerimiento, float valor)
        {
            Id = 0;
            TareaId = tareaId;
            Requerimiento = requerimiento;
            Valor = valor;
        }
    }
}
