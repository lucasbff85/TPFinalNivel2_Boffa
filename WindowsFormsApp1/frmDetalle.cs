using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmDetalle : Form
    {
        private Articulo articulo = null;

        public frmDetalle()
        {
            InitializeComponent();
        }

        public frmDetalle(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;   
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            txtNombre.Text = articulo.Nombre;
            txtCodigo.Text = articulo.Codigo;
            txtMarca.Text = articulo.Marca.Descripcion;
            txtCategoria.Text = articulo.Categoria.Descripcion;
            txtDescripcion.Text = articulo.Descripcion;
            txtPrecio.Text = articulo.Precio.ToString();
            cargarImagen(articulo.UrlImagen);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxDetalle.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxDetalle.Load("https://www.nycourts.gov/courts/ad4/assets/Placeholder.png");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
