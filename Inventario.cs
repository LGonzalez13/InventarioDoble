using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyControlInv
{
    class Inventario
    {
        private Producto primero;
        private int numeroProductos;

        public Inventario()
        {
            numeroProductos = 0;
        }

        public void agregarEnInicio(Producto p)
        {
            if (primero == null)
            {
                primero = p;
            }
            else
            {
                primero.anterior = p;
                Producto temp = primero;
                primero = p;
                primero.quienSigue = temp;

            }
            numeroProductos++;
        }

        public void agregar(Producto p)
        {
            if (primero == null)
                primero = p;
            else
                agregar(p, primero);
        }

        private void agregar(Producto p, Producto ultimo)
        {
            if (ultimo.quienSigue == null)
            {
                ultimo.quienSigue = p;
                ultimo.quienSigue.anterior = ultimo;
            }
                
            else
                agregar(p, ultimo.quienSigue);
        }


        public Producto buscar(string nombre)
        {
            Producto temp = primero;
            while (temp != null && temp.nombre != nombre)
            {
                temp = temp.quienSigue;
            }
            return temp;

        }

        public void eliminar(string nombre)
        {
            if (primero != null)
            {
                if(primero.quienSigue != null)
                {
                    eliminar(primero.quienSigue, nombre);
                }
            }
            
        }

        private void eliminar(Producto p, string nombre)
        {
            if (p.quienSigue != null && p.nombre != nombre)
                eliminar(p.quienSigue, nombre);
            else
                if(p.quienSigue != null)
                    p.anterior.quienSigue = p.quienSigue;
        }

        public void eliminarInicio()
        {
            if(primero != null)
            {
                if (primero.quienSigue != null)
                {
                    primero = primero.quienSigue;
                    primero.anterior = null;
                }
                else
                    primero = null;
            }
            
        }

        public void eliminarUltimo()
        {
            if (primero != null)
            {
                if (primero.quienSigue != null)
                {
                    eliminarUlt(primero.quienSigue);
                }
                else
                    primero = null;
            }
            
        }

        private void eliminarUlt(Producto p)
        {
            if (p.quienSigue == null)
                p.anterior.quienSigue = null;
            else
                eliminarUlt(p.quienSigue);
        }

        public string reporte()
        {
            if (primero != null)
            {
                Producto temp = primero;
                string reporte = temp.ToString() + Environment.NewLine + Environment.NewLine;
                while (temp.quienSigue != null)
                {
                    reporte += temp.quienSigue.ToString() + Environment.NewLine + Environment.NewLine;
                    temp = temp.quienSigue;
                }
                return reporte;
            }
            else
                return "No hay elementos";
            
        }

        public string reporteInverso()
        {
            if (primero != null)
                return reporteInverso(primero.quienSigue);
            else
                return "No hay elementos";
        }

        private string reporteInverso(Producto p)
        {
            if (p.quienSigue == null)
                return p.ToString();
            else
                return reporteInverso(p.quienSigue) + Environment.NewLine + Environment.NewLine + p.ToString();
        }

        public void insertar(Producto p, int pos)
        {
            Producto temp = primero;
            int i = 1;
            while (i<pos)
            {
                temp = temp.quienSigue;
                i++;
            }
            p.quienSigue = temp.quienSigue;
            p.anterior = temp;
            temp.quienSigue = p;
        }

        public override string ToString()
        {
            return numeroProductos.ToString();
        }
    }
}
