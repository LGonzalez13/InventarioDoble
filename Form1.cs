using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyControlInv
{
    public partial class Form1 : Form
    {
        Inventario inventario;
        Producto producto;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string nombre = txtNombre.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            int costo = Convert.ToInt32(txtCosto.Text);

            producto = new Producto(codigo, nombre, cantidad, costo);
            inventario.agregar(producto);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inventario = new Inventario();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            producto = inventario.buscar(txtNombre.Text);
            if(producto==null)
            {
                txtReporte.Text = "No encontrado";
            }
            else
            {
                txtReporte.Text = producto.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            inventario.eliminar(txtNombre.Text);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = inventario.reporte();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string nombre = txtNombre.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            int costo = Convert.ToInt32(txtCosto.Text);

            producto = new Producto(codigo, nombre, cantidad, costo);
            inventario.insertar(producto, Convert.ToInt32(txtPosicion.Text));
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            string nombre = txtNombre.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            int costo = Convert.ToInt32(txtCosto.Text);

            producto = new Producto(codigo, nombre, cantidad, costo);
            inventario.agregarEnInicio(producto);
        }

        private void btnReporteInverso_Click(object sender, EventArgs e)
        {
            inventario.reporteInverso();
        }

        private void btnEliminarInicio_Click(object sender, EventArgs e)
        {
            inventario.eliminarInicio();
        }

        private void btnEliminarUlt_Click(object sender, EventArgs e)
        {
            inventario.eliminarUltimo();
        }
    }
}
