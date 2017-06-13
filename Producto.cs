using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyControlInv
{
    class Producto
    {
        private int _codigo;
        public int codigo { get { return _codigo; } }

        private string _nombre;
        public string nombre { get { return _nombre; } }

        private int _cantidad;
        public int cantidad { get { return _cantidad; } }

        private int _costo;
        public int costo { get { return _costo; } }

        private Producto _quienSigue;
        public Producto quienSigue { get { return _quienSigue; } set { _quienSigue = value; } }

        private Producto _anterior;
        public Producto anterior { get { return _anterior; } set { _anterior = value; } }

        public Producto(int codigo, string nombre, int cantidad, int costo)
        {
            _codigo = codigo;
            _nombre = nombre;
            _cantidad = cantidad;
            _costo = costo;
            _quienSigue = null;
            _anterior = null;
        }

        public override string ToString()
        {
            return codigo.ToString() + Environment.NewLine + nombre + Environment.NewLine + cantidad.ToString() + " pza(s)" + Environment.NewLine + "$" + costo.ToString();
        }
    }
}
