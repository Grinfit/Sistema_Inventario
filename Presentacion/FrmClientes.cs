using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmClientes : Form
    {
        Conexion cn = new Conexion();

        Logger log = new Logger();

        int IdCliente = 0;

        public FrmClientes()
        {
            InitializeComponent();
        }

        // =====================================================
        // MOSTRAR CLIENTES
        // =====================================================

        private void MostrarClientes()
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_MostrarClientes",
                        cn.AbrirConexion());

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvClientes.DataSource = dt;

                // ============================================
                // OCULTAR ID
                // ============================================

                if (dgvClientes.Columns.Count > 0)
                {
                    dgvClientes.Columns["IdCliente"].Visible = false;
                }

                // ============================================
                // ESTILOS COLUMNAS
                // ============================================

                dgvClientes.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvClientes.DefaultCellStyle.Alignment =
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
                    "ERROR_CLIENTES",
                    SesionUsuario.Usuario,
                    ex.Message);
            }
        }

        // =====================================================
        // LIMPIAR CAMPOS
        // =====================================================

        private void LimpiarCampos()
        {
            txtNombre.Clear();

            txtTelefono.Clear();

            txtCorreo.Clear();

            txtBuscar.Clear();

            txtNombre.Focus();
        }

        // =====================================================
        // VALIDAR CAMPOS
        // =====================================================

        private bool ValidarCampos()
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el nombre del cliente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();

                return false;
            }

            if (txtTelefono.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el teléfono",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelefono.Focus();

                return false;
            }

            if (txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el correo",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();

                return false;
            }

            // VALIDAR EMAIL

            if (!txtCorreo.Text.Contains("@"))
            {
                MessageBox.Show(
                    "Correo electrónico inválido",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();

                return false;
            }

            return true;
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void FrmClientes_Load(
            object sender,
            EventArgs e)
        {
            MostrarClientes();

            // ============================================
            // EFECTO HOVER BOTONES
            // ============================================

            btnNuevo.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnNuevo.BackColor);

            btnGuardar.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnGuardar.BackColor);

            btnEditar.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnEditar.BackColor);

            btnEliminar.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnEliminar.BackColor);

            btnBuscar.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(22, 52, 88);
        }

        // =====================================================
        // GUARDAR
        // =====================================================

        private void btnGuardar_Click(
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
                        "sp_InsertarCliente",
                        cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    txtNombre.Text);

                cmd.Parameters.AddWithValue(
                    "@Telefono",
                    txtTelefono.Text);

                cmd.Parameters.AddWithValue(
                    "@Correo",
                    txtCorreo.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Cliente guardado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                log.RegistrarLog(
    "CLIENTE_CREATE",
    SesionUsuario.Usuario,
    "Cliente agregado: " + txtNombre.Text);

                MostrarClientes();

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
                    "ERROR CLIENTE",
                    SesionUsuario.Usuario,
                    ex.Message);
            }
        }

        // =====================================================
        // SELECCIONAR GRID
        // =====================================================

        private void dgvClientes_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow == null)
                {
                    return;
                }

                IdCliente =
                    Convert.ToInt32(
                        dgvClientes.CurrentRow.Cells[0].Value);

                txtNombre.Text =
                    dgvClientes.CurrentRow.Cells[1]
                    .Value
                    .ToString();

                txtTelefono.Text =
                    dgvClientes.CurrentRow.Cells[2]
                    .Value
                    .ToString();

                txtCorreo.Text =
                    dgvClientes.CurrentRow.Cells[3]
                    .Value
                    .ToString();
            }
            catch
            {

            }
        }

        // =====================================================
        // EDITAR
        // =====================================================

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (IdCliente == 0)
                {
                    MessageBox.Show(
                        "Seleccione un cliente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!ValidarCampos())
                {
                    return;
                }

                SqlCommand cmd =
                    new SqlCommand(
                        "sp_EditarCliente",
                        cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@IdCliente",
                    IdCliente);

                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    txtNombre.Text);

                cmd.Parameters.AddWithValue(
                    "@Telefono",
                    txtTelefono.Text);

                cmd.Parameters.AddWithValue(
                    "@Correo",
                    txtCorreo.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Cliente actualizado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                log.RegistrarLog(
    "CLIENTE_UPDATE",
    SesionUsuario.Usuario,
    "Cliente actualizado: " + txtNombre.Text);

                MostrarClientes();

                LimpiarCampos();

                IdCliente = 0;

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
                    "ERROR_CLIENTE_UPDATE",
                    SesionUsuario.Usuario,
                    ex.Message);
            }
        }

        // =====================================================
        // ELIMINAR
        // =====================================================

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (IdCliente == 0)
                {
                    MessageBox.Show(
                        "Seleccione un cliente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult resultado;

                resultado =
                    MessageBox.Show(
                        "¿Desea eliminar este cliente?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_EliminarCliente",
                            cn.AbrirConexion());

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@IdCliente",
                        IdCliente);

                    cmd.ExecuteNonQuery();

                    log.RegistrarLog(
    "CLIENTE_DELETE",
    SesionUsuario.Usuario,
    "Cliente eliminado: " + txtNombre.Text);

                    MessageBox.Show(
                        "Cliente eliminado correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    MostrarClientes();

                    LimpiarCampos();

                    IdCliente = 0;

                    cn.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                log.RegistrarLog(
                    "ERROR_CLIENTE_DELETE",
                    SesionUsuario.Usuario,
                    ex.Message);
            }
        }

        // =====================================================
        // BUSCAR
        // =====================================================

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_BuscarCliente",
                        cn.AbrirConexion());

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue(
                    "@Texto",
                    txtBuscar.Text);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvClientes.DataSource = dt;

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
                    "ERROR_CLIENTE_SEARCH",
                    SesionUsuario.Usuario,
                    ex.Message);
            }
        }

        // =====================================================
        // NUEVO
        // =====================================================

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();

            MostrarClientes();

            IdCliente = 0;
        }
    }
}