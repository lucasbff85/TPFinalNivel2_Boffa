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
    public partial class formPrincipal : Form
    {
        private List<Articulo> listaArticulos;
        private List<Articulo> listaArticulosDesactivados;
        public formPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoría");
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }

        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                ocultarColumnas();
                cargarImagen(listaArticulos[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["UrlImagen"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxArticulo.Load("https://www.nycourts.gov/courts/ad4/assets/Placeholder.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           eliminar();
        }

        private void btnSuspender_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void eliminar(bool suspender = false)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Querés eliminar el artículo seleccionado?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                    if (suspender)
                        negocio.suspender(seleccionado.Id);
                    else
                        negocio.eliminar(seleccionado.Id);
                    cargar();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            switch (opcion)
            {
                case "Precio":
                    lblFiltroAvanzado.Visible = true;
                    txtFiltroAvanzado.Visible = true;
                    cboCriterio.DataSource = null;
                    cboCriterio.Items.Clear();
                    cboCriterio.Items.Add("Mayor a");
                    cboCriterio.Items.Add("Menor a");
                    cboCriterio.Items.Add("Igual a");
                    cboCriterio.SelectedItem = "Menor a";
                    break;

                case "Marca":
                    lblFiltroAvanzado.Visible = false;
                    txtFiltroAvanzado.Visible = false;
                    cboCriterio.DataSource = null;
                    cboCriterio.Items.Clear();
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    cboCriterio.DataSource = marcaNegocio.listar();
                    break;

                case "Categoría":
                    lblFiltroAvanzado.Visible = false;
                    txtFiltroAvanzado.Visible = false;
                    cboCriterio.DataSource = null;
                    cboCriterio.Items.Clear();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    cboCriterio.DataSource = categoriaNegocio.listar();
                    break;

            }
            
        }

        private bool validarFiltro()
        {
            Validaciones validar = new Validaciones();

            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione el campo para filtrar.");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                //esto  se tiene que hacer directamente acá, sino no funciona
                txtFiltroAvanzado.Text = txtFiltroAvanzado.Text.Replace(',', '.');

                if (!decimal.TryParse(txtFiltroAvanzado.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal nuevoPrecio))
                {
                    MessageBox.Show("Formato de precio inválido");
                    return true;
                }

                if (validar.validarPrecio(txtFiltroAvanzado.Text))
                {
                    return true;
                }              
            }
                

            return false;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            

            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                
                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
                
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cargar();
            cboCriterio.DataSource = null;
            cboCampo.DataSource = null;
            cboCriterio.Items.Clear();
            cboCampo.Items.Clear();
            txtFiltroAvanzado.Text = "";

            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoría");
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {           
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            frmDetalle detalle = new frmDetalle(seleccionado);
            detalle.ShowDialog();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulosDesactivados = negocio.listarSuspendidos();
            if (listaArticulosDesactivados.Count>0)
            {
                frmArticulosDesactivados desactivados = new frmArticulosDesactivados();
                desactivados.ShowDialog();

                cargar();
            }
            else
            {
                MessageBox.Show("No hay artículos en suspensión en este momento");
            }
           
        }
    }
}
