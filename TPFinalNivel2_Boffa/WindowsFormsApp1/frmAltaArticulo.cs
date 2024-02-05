using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
using System.Configuration;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;

        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        public frmAltaArticulo( Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Artículo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();
            Validaciones validar = new Validaciones();
            try 
            {
                //se reemplazan las comas directamente acá para que funcione...
                txtPrecio.Text = txtPrecio.Text.Replace(',', '.');

                if (!decimal.TryParse(txtPrecio.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal nuevoPrecio))
                {
                    MessageBox.Show("Formato de precio inválido");
                    return;
                }


                if (validar.validarPrecio(txtPrecio.Text))
                    return;
                if (articulo == null)
                    articulo = new Articulo();
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;  
                articulo.Descripcion = txtDescripcion.Text;
                articulo.UrlImagen = txtUrlImagen.Text;
                articulo.Precio = nuevoPrecio;
                //articulo.Precio = decimal.Parse(txtPrecio.Text);
                //articulo.Precio = decimal.Round(articulo.Precio, 2);
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem; 

                if(articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente");
                }

                if(archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")))
                {

                    if (File.Exists(articulo.UrlImagen))
                    {
                        File.Delete(articulo.UrlImagen);
                    }

                    guardarImagen();
                }

                


                Close();

            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null ) 
                {
                    txtCodigo.Text = articulo.Codigo.ToString();    
                    txtNombre.Text = articulo.Nombre.ToString();
                    txtDescripcion.Text = articulo.Descripcion.ToString();
                    txtUrlImagen.Text = articulo.UrlImagen.ToString();
                    cargarImagen(articulo.UrlImagen);
                    txtPrecio.Text = articulo.Precio.ToString();
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxNuevoArticulo.Load(imagen);
            }
            catch (Exception ex)
            {

                pbxNuevoArticulo.Load("https://www.nycourts.gov/courts/ad4/assets/Placeholder.png");
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*png";
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
                
            }
        }

        private void guardarImagen()
        {
            File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
        }
    }
}
