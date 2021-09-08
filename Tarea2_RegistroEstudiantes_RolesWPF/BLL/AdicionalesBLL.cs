using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2_RegistroEstudiantes_RolesWPF.Entidades;
using Tarea2_RegistroEstudiantes_RolesWPF.DAL;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace Tarea2_RegistroEstudiantes_RolesWPF.BLL
{
    public class AdicionalesBLL
    {
        public static bool Guardar(Adicionales adicionales)
        {
            if (!Existe(adicionales.AdicionalId))
                return Insertar(adicionales);
            else
                return Modificar(adicionales);
        }


        private static bool Insertar(Adicionales adicionales)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Adicionales.Add(adicionales);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        private static bool Modificar(Adicionales adicionales)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(adicionales).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var adicionales = AdicionalesBLL.Buscar(id);

                if (adicionales != null)
                {
                    contexto.Adicionales.Remove(adicionales); //remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        public static Adicionales Buscar(int id)
        {
            Adicionales adicionales = new Adicionales();
            Contexto contexto = new Contexto();

            try
            {
                adicionales = contexto.Adicionales.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return adicionales;
        }


        public static List<Adicionales> GetList(Expression<Func<Adicionales, bool>> criterio)
        {
            List<Adicionales> Lista = new List<Adicionales>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Adicionales.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }



        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Adicionales.Any(e => e.AdicionalId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

    }
}
