using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PrimerParcial.Models;
using PrimerParcialBlazor.DAL;
using Microsoft.EntityFrameworkCore;

namespace PrimerParcial.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos producto)
        {
            if(!Existe(producto.ProductoId))
                return Insertar(producto);
            else
                return Modificar(producto);
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado;
            try
            {
                encontrado = contexto.Productos.Any(p => p.ProductoId == id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        private static bool Insertar(Productos producto)
        {
            Contexto contexto = new Contexto();
            bool guardado;
            try
            {
                contexto.Productos.Add(producto);
                guardado = (contexto.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return guardado;
        }

        private static bool Modificar(Productos producto)
        {
            Contexto contexto = new Contexto();
            bool modificado;
            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
                modificado = (contexto.SaveChanges() > 0);
            }   
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;
            try
            {
                var producto = contexto.Productos.Find(id);

                if(producto != null)
                {
                    contexto.Productos.Remove(producto);
                    eliminado = (contexto.SaveChanges() > 0);
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminado;
        }

        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos producto = new Productos();

            try
            {
                producto = contexto.Productos.Find(id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return producto;
        }

        public static List<Productos> GetList(Expression<Func<Productos,bool>>producto)
        {
            Contexto contexto = new Contexto();
            List<Productos> Lista = new List<Productos>();

            try
            {
                Lista = contexto.Productos.Where(producto).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
} 