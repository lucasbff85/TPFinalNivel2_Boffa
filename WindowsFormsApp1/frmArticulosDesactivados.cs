using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace WindowsFormsApp1
{
    public partial class frmArticulosDesactivados : Form
    {
        private List<Articulo> listaArticulosDesactivados;

        public frmArticulosDesactivados()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmArticulosDesactivados_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulosDesactivados = negocio.listarSuspendidos();
                dgvSuspendidos.DataSource = listaArticulosDesactivados;
                ocultarColumnas();
                cargarImagen(listaArticulosDesactivados[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        private void ocultarColumnas()
        {
            dgvSuspendidos.Columns["UrlImagen"].Visible = false;
            dgvSuspendidos.Columns["Id"].Visible = false;
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxSuspendidos.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxSuspendidos.Load("https://www.nycourts.gov/courts/ad4/assets/Placeholder.png");
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Validaciones validaciones = new Validaciones();
            Articulo seleccionado = null;
            try
            {
                //Las comas se reemplazan acá porque sino no funciona modularizando...
                txtPrecioNuevo.Text = txtPrecioNuevo.Text.Replace(',', '.');

                if (!decimal.TryParse(txtPrecioNuevo.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal nuevoPrecio))
                {
                    MessageBox.Show("Formato de precio inválido");
                    return;
                }

                if (validaciones.validarPrecio(txtPrecioNuevo.Text))
                    return;


                seleccionado = (Articulo)dgvSuspendidos.CurrentRow.DataBoundItem;
                //seleccionado.Precio = decimal.Parse(txtPrecioNuevo.Text);
                decimal precio = nuevoPrecio;
                seleccionado.Precio = precio;

                negocio.modificarPrecio(seleccionado);
                MessageBox.Show("Modificado exitosamente");

                if (seleccionado == null)
                    MessageBox.Show("Debes seleccionar el artículo que deseas activar...");
                
                Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvSuspendidos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSuspendidos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvSuspendidos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }

        }
    }
}
