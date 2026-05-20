using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmVentas : Form
    {
        Conexion cn = new Conexion();

        Logger log = new Logger();

        public FrmVentas()
        {
            InitializeComponent();
        }

        // =====================================================
        // CARGAR CLIENTES
        // =====================================================

        private void CargarClientes()
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "SELECT * FROM Clientes",
                        cn.AbrirConexion());

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                cbClientes.DataSource = dt;

                cbClientes.DisplayMember =
                    "Nombre";

                cbClientes.ValueMember =
                    "IdCliente";

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // CARGAR PRODUCTOS
        // =====================================================

        private void CargarProductos()
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "SELECT * FROM Productos",
                        cn.AbrirConexion());

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                cbProductos.DataSource = dt;

                cbProductos.DisplayMember =
                    "Nombre";

                cbProductos.ValueMember =
                    "IdProducto";

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // MOSTRAR VENTAS
        // =====================================================

        private void MostrarVentas()
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_MostrarVentas",
                        cn.AbrirConexion());

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvVentas.DataSource = dt;

                // ============================================
                // OCULTAR ID
                // ============================================

                if (dgvVentas.Columns.Count > 0)
                {
                    dgvVentas.Columns["IdVenta"].Visible = false;
                }

                // ============================================
                // FORMATO MONEDA
                // ============================================

                dgvVentas.Columns["PrecioUnitario"]
                    .DefaultCellStyle.Format = "C2";

                dgvVentas.Columns["Subtotal"]
                    .DefaultCellStyle.Format = "C2";

                // ============================================
                // ALINEACION
                // ============================================

                dgvVentas.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvVentas.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                log.RegistrarLog(
                    "ERROR MOSTRAR VENTAS",
                    SesionUsuario.Usuario,
                    ex.Message);
            }
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void FrmVentas_Load(
            object sender,
            EventArgs e)
        {
            CargarClientes();

            CargarProductos();

            MostrarVentas();

            // ============================================
            // EFECTOS HOVER
            // ============================================

            btnNuevo.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnNuevo.BackColor);

            btnRegistrarVenta.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnRegistrarVenta.BackColor);
        }

        // =====================================================
        // PRODUCTO SELECCIONADO
        // =====================================================

        private void cbProductos_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlCommand cmd =
                    new SqlCommand(
                        "SELECT Precio FROM Productos WHERE IdProducto=@Id",
                        cn.AbrirConexion());

                cmd.Parameters.AddWithValue(
                    "@Id",
                    cbProductos.SelectedValue);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    decimal precio =
                        Convert.ToDecimal(dr["Precio"]);

                    txtPrecio.Text =
                        precio.ToString("0.00");
                }

                dr.Close();

                cn.CerrarConexion();
            }
            catch
            {

            }
        }

        // =====================================================
        // CALCULAR TOTAL
        // =====================================================

        private void txtCantidad_TextChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                decimal precio =
                    Convert.ToDecimal(txtPrecio.Text);

                int cantidad =
                    Convert.ToInt32(txtCantidad.Text);

                decimal total =
                    precio * cantidad;

                txtTotal.Text =
                    total.ToString("0.00");
            }
            catch
            {
                txtTotal.Text = "";
            }
        }

        // =====================================================
        // VALIDAR CAMPOS
        // =====================================================

        private bool ValidarCampos()
        {
            if (txtCantidad.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese la cantidad",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCantidad.Focus();

                return false;
            }

            int cantidad;

            if (!int.TryParse(
                txtCantidad.Text,
                out cantidad))
            {
                MessageBox.Show(
                    "Ingrese una cantidad válida",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCantidad.Focus();

                return false;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show(
                    "La cantidad debe ser mayor a cero",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCantidad.Focus();

                return false;
            }

            return true;
        }

        // =====================================================
        // REGISTRAR VENTA
        // =====================================================

        private void btnRegistrarVenta_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                {
                    return;
                }

                SqlCommand cmd =
                    new SqlCommand(
                        "sp_InsertarVenta",
                        cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@IdCliente",
                    cbClientes.SelectedValue);

                cmd.Parameters.AddWithValue(
                    "@IdProducto",
                    cbProductos.SelectedValue);

                cmd.Parameters.AddWithValue(
                    "@Cantidad",
                    txtCantidad.Text);

                cmd.Parameters.AddWithValue(
                    "@Precio",
                    txtPrecio.Text);

                cmd.Parameters.AddWithValue(
                    "@Total",
                    txtTotal.Text);

                cmd.ExecuteNonQuery();

                log.RegistrarLog(
    "VENTA_CREATE",
    SesionUsuario.Usuario,
    "Venta registrada | Cliente: " +
    cbClientes.Text +
    " | Producto: " +
    cbProductos.Text +
    " | Cantidad: " +
    txtCantidad.Text +
    " | Total: $" +
    txtTotal.Text);

                MessageBox.Show(
                    "Venta registrada correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarVentas();

                LimpiarCampos();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                log.RegistrarLog(
                    "ERROR_VENTA_CREATE",
                    SesionUsuario.Usuario,
                    ex.Message);
            }
        }

        // =====================================================
        // LIMPIAR CAMPOS
        // =====================================================

        private void LimpiarCampos()
        {
            txtCantidad.Clear();

            txtPrecio.Clear();

            txtTotal.Clear();

            cbClientes.SelectedIndex = 0;

            cbProductos.SelectedIndex = 0;

            txtCantidad.Focus();
        }

        // =====================================================
        // NUEVO
        // =====================================================

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();
        }
    }
}