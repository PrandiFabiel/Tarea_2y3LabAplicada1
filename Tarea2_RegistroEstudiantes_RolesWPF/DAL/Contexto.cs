using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2_RegistroEstudiantes_RolesWPF.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Tarea2_RegistroEstudiantes_RolesWPF.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Nacionalidades> Nacionalidades { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Tareas> Tareas { get; set; }
        public DbSet<Adicionales> Adicionales { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source= DATA/TeacherControl.db");
        }

    }
}
