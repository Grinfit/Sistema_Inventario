// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Sistema_Inventario.Logica;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO PRINCIPAL DE GESTION DE PROVEEDORES
    public partial class FrmProveedores : Form
    {
        // CAPA LOGICA DE PROVEEDORES
        LProveedores lProveedores = new LProveedores();

        // ID DEL PROVEEDOR SELECCIONADO EN LA GRILLA
        int idProveedor = 0;

        // CONSTRUCTOR
        public FrmProveedores()
        {
            InitializeComponent();
            AplicarEstilos();
        }

        // APLICA ESTILOS A BOTONES Y GRILLA
        private void AplicarEstilos()
        {
            ConfigurarBoton(btnNuevo,    Color.FromArgb(52,  152, 219));
            ConfigurarBoton(btnEditar,   Color.FromArgb(241, 196,  15));
            ConfigurarBoton(btnEliminar, Color.FromArgb(231,  76,  60));
            ConfigurarBoton(btnBuscar,   Color.FromArgb( 10,  31,  58));
            ConfigurarBoton(btnExportar, Color.FromArgb( 39, 174,  96));
            ConfigurarGrid();
        }

        // CONFIGURA ESTILO UNIFICADO DE BOTON
        private void ConfigurarBoton(IconButton btn, Color color)
        {
            btn.BackColor                 = color;
            btn.ForeColor                 = Color.White;
            btn.FlatStyle                 = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.IconColor                 = Color.White;
            btn.IconSize                  = 24;
            btn.TextImageRelation         = TextImageRelation.ImageBeforeText;
            btn.ImageAlign                = ContentAlignment.MiddleLeft;
            btn.Padding                   = new Padding(12, 0, 0, 0);
            btn.Cursor                    = Cursors.Hand;

            btn.MouseEnter += (s, e) => { btn.BackColor = ControlPaint.Dark(color); };
            btn.MouseLeave += (s, e) => { btn.BackColor = color; };
        }

        // CONFIGURA ESTILO DE LA GRILLA
        private void ConfigurarGrid()
        {
            dgvProveedores.BorderStyle                               = BorderStyle.None;
            dgvProveedores.BackgroundColor                           = Color.White;
            dgvProveedores.EnableHeadersVisualStyles                 = false;
            dgvProveedores.ColumnHeadersBorderStyle                  = DataGridViewHeaderBorderStyle.None;
            dgvProveedores.ColumnHeadersDefaultCellStyle.BackColor   = Color.FromArgb(11, 31, 58);
            dgvProveedores.ColumnHeadersDefaultCellStyle.ForeColor   = Color.White;
            dgvProveedores.ColumnHeadersDefaultCellStyle.Font        = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvProveedores.ColumnHeadersHeight                       = 45;
            dgvProveedores.DefaultCellStyle.Font                     = new Font("Segoe UI", 10F);
            dgvProveedores.DefaultCellStyle.SelectionBackColor       = Color.FromArgb(52, 152, 219);
            dgvProveedores.DefaultCellStyle.SelectionForeColor       = Color.White;
            dgvProveedores.RowsDefaultCellStyle.BackColor            = Color.White;
            dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvProveedores.RowTemplate.Height                        = 38;
            dgvProveedores.AutoSizeColumnsMode                       = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.SelectionMode                             = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.MultiSelect                               = false;
            dgvProveedores.RowHeadersVisible                         = false;
            dgvProveedores.GridColor                                 = Color.LightGray;
        }

        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
        }

        // CARGA TODOS LOS PROVEEDORES EN LA GRILLA
        private void MostrarProveedores()
        {
            try
            {
                dgvProveedores.DataSource = lProveedores.MostrarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // SELECCION EN LA GRILLA
        // ─────────────────────────────────────────

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    idProveedor = Convert.ToInt32(
                        dgvProveedores.Rows[e.RowIndex].Cells["IdProveedor"].Value);
                }
            }
            catch { }
        }

        // ─────────────────────────────────────────
        // BOTON NUEVO — abre modal en modo creación
        // ─────────────────────────────────────────

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmProveedorModal modal = new FrmProveedorModal())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    MostrarProveedores();
                    idProveedor = 0;
                }
            }
        }

        // ─────────────────────────────────────────
        // BOTON EDITAR — abre modal en modo edición
        // ─────────────────────────────────────────

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idProveedor == 0 || dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un proveedor de la lista antes de editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow fila = dgvProveedores.SelectedRows[0];

                using (FrmProveedorModal modal = new FrmProveedorModal(
                    idProveedor,
                    fila.Cells["Nombre"].Value?.ToString()    ?? "",
                    fila.Cells["Empresa"].Value?.ToString()   ?? "",
                    fila.Cells["Telefono"].Value?.ToString()  ?? "",
                    fila.Cells["Correo"].Value?.ToString()    ?? "",
                    fila.Cells["Direccion"].Value?.ToString() ?? ""))
                {
                    if (modal.ShowDialog(this) == DialogResult.OK)
                        MostrarProveedores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON ELIMINAR
        // ─────────────────────────────────────────

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProveedor == 0 || dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un proveedor de la lista antes de eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombre = "";
                try { nombre = dgvProveedores.SelectedRows[0].Cells["Nombre"].Value?.ToString() ?? ""; }
                catch { }

                DialogResult resultado = MessageBox.Show(
                    "¿Desea eliminar el proveedor: " + nombre + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    lProveedores.EliminarProveedor(idProveedor);

                    MessageBox.Show(
                        "Proveedor eliminado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    MostrarProveedores();
                    idProveedor = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON BUSCAR
        // ─────────────────────────────────────────

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProveedores.DataSource = lProveedores.BuscarProveedor(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON EXPORTAR EXCEL
        // ─────────────────────────────────────────

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarExcel.Exportar(dgvProveedores, "Reporte_Proveedores");
        }
    }
}
