// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO MODAL PARA CREAR Y EDITAR PRODUCTOS
    public partial class FrmProductoModal : Form
    {
        // OBJETO DE CONEXION
        Conexion cn = new Conexion();

        // OBJETO LOGGER
        Logger log = new Logger();

        // ESTADO DEL MODAL
        bool _modoEdicion;
        int  _idProducto;

        // ─────────────────────────────────────────
        // CONSTRUCTOR PARA NUEVO PRODUCTO
        // ─────────────────────────────────────────
        public FrmProductoModal()
        {
            InitializeComponent();
            _modoEdicion    = false;
            _idProducto     = 0;
            AplicarHovers();
        }

        // ─────────────────────────────────────────
        // CONSTRUCTOR PARA EDITAR PRODUCTO
        // ─────────────────────────────────────────
        public FrmProductoModal(
            int    idProducto,
            string nombre,
            string categoria,
            string precio,
            string stock)
        {
            InitializeComponent();
            _modoEdicion = true;
            _idProducto  = idProducto;
            AplicarHovers();

            // CAMBIA EL TITULO AL MODO EDICION
            lblTitulo.Text = "Editar Producto";
            this.Text      = "Editar Producto";

            // PRE-CARGA LOS DATOS
            txtNombre.Text    = nombre;
            txtCategoria.Text = categoria;
            txtPrecio.Text    = precio;
            txtStock.Text     = stock;
        }

        // EFECTO HOVER EN BOTONES
        private void AplicarHovers()
        {
            Color cGuardar   = Color.FromArgb(46,  204, 113);
            Color cCancelar  = Color.FromArgb(149, 165, 166);

            btnGuardar.MouseEnter  += (s, e) => { btnGuardar.BackColor  = ControlPaint.Dark(cGuardar);  };
            btnGuardar.MouseLeave  += (s, e) => { btnGuardar.BackColor  = cGuardar;  };
            btnCancelar.MouseEnter += (s, e) => { btnCancelar.BackColor = ControlPaint.Dark(cCancelar); };
            btnCancelar.MouseLeave += (s, e) => { btnCancelar.BackColor = cCancelar; };
        }

        // ─────────────────────────────────────────
        // VALIDACION DE CAMPOS
        // ─────────────────────────────────────────
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "El nombre del producto es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                MessageBox.Show(
                    "La categoría es obligatoria.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoria.Focus();
                return false;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio < 0)
            {
                MessageBox.Show(
                    "Ingrese un precio válido (número positivo).",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            int stock;
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                MessageBox.Show(
                    "Ingrese un stock válido (número entero positivo).",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            return true;
        }

        // ─────────────────────────────────────────
        // BOTON GUARDAR — INSERT o UPDATE
        // ─────────────────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                if (!_modoEdicion)
                {
                    // INSERTAR NUEVO PRODUCTO
                    SqlCommand cmd = new SqlCommand(
                        "sp_InsertarProducto", cn.AbrirConexion());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre",    txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text.Trim());
                    cmd.Parameters.AddWithValue("@Precio",    txtPrecio.Text.Trim());
                    cmd.Parameters.AddWithValue("@Stock",     txtStock.Text.Trim());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Producto guardado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    log.RegistrarLog(
                        "PRODUCTO_CREATE",
                        SesionUsuario.Usuario,
                        "Producto agregado: " + txtNombre.Text.Trim());

                    cn.CerrarConexion();
                }
                else
                {
                    // ACTUALIZAR PRODUCTO EXISTENTE
                    SqlCommand cmd = new SqlCommand(
                        "sp_EditarProducto", cn.AbrirConexion());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", _idProducto);
                    cmd.Parameters.AddWithValue("@Nombre",     txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Categoria",  txtCategoria.Text.Trim());
                    cmd.Parameters.AddWithValue("@Precio",     txtPrecio.Text.Trim());
                    cmd.Parameters.AddWithValue("@Stock",      txtStock.Text.Trim());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Producto actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    log.RegistrarLog(
                        "PRODUCTO_UPDATE",
                        SesionUsuario.Usuario,
                        "Producto actualizado: " + txtNombre.Text.Trim());

                    cn.CerrarConexion();
                }

                // CIERRA EL MODAL CON RESULTADO OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
