using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2_RegistroEstudiantes_RolesWPF.Entidades;
using Tarea2_RegistroEstudiantes_RolesWPF.DAL;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Security.RightsManagement;

namespace Tarea2_RegistroEstudiantes_RolesWPF.BLL
{
    public class UsuariosBLL
    {
        //Guardando un usuario
        public static bool Guardar(Usuarios usuario)
        {
            if (!Existe(usuario.UsuarioId))
                return Insertar(usuario);
            else
                return Modificar(usuario);
        }

        //Insertar el usuario
        private static bool Insertar(Usuarios usuario)
        {
            Contexto contexto = new Contexto();
            bool guardado = false;

            try
            {
                usuario.Clave = GetSHA256(usuario.Clave);
                if (contexto.Usuarios.Add(usuario) != null)
                    guardado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return guardado;
        }

        //Modificar/editar
        //Metodo para Modificar en la base de datos
        private static bool Modificar(Usuarios usuario)
        {
            Contexto contexto = new Contexto();
            bool modificado = false;
            usuario.Clave = GetSHA256(usuario.Clave);
            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                modificado = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }

        //Eliminar un usuario
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var usuario = contexto.Usuarios.Find(id);

                if (usuario != null)
                {
                    contexto.Usuarios.Remove(usuario);
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

        //Para saber si un usuario existe 
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Usuarios.Any(e => e.UsuarioId == id);
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

        //Validar usuario
        public static bool Validar(string nombre, string clave)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Usuarios
                    .Any(u => u.Nombres.Equals(nombre)
                                && u.Clave.Equals(clave)
                          );
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

        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuario = new Usuarios();

            try
            {
                usuario = contexto.Usuarios.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }

        //Metodo para encriptar la clave 
        private static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}
