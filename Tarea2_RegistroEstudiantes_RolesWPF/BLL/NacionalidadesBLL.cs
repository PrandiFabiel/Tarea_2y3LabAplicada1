﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2_RegistroEstudiantes_RolesWPF.Entidades;
using Tarea2_RegistroEstudiantes_RolesWPF.DAL;

namespace Tarea2_RegistroEstudiantes_RolesWPF.BLL
{
    public class NacionalidadesBLL
    {
        public static Nacionalidades Buscar(int id)
        {
            Nacionalidades nacionalidad;
            Contexto contexto = new Contexto();

            try
            {
                nacionalidad = contexto.Nacionalidades.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return nacionalidad;
        }

        public static List<Nacionalidades> GetNacionalidades()
        {
            List<Nacionalidades> lista = new List<Nacionalidades>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Nacionalidades.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}
