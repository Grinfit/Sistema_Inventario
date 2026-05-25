// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Sistema_Inventario.Logica;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO PRINCIPAL DE GESTION DE BODEGAS
    public partial class FrmBodegas : Form
    {
        // CAPA LOGICA DE BODEGAS
        LBodegas lBodegas = new LBodegas();

        // ID DE LA BODEGA SELECCIONADA EN LA GRILLA
        int idBodega = 0;

        // CONSTRUCTOR
        public FrmBodegas()
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
            dgvBodegas.BorderStyle                               = BorderStyle.None;
            dgvBodegas.BackgroundColor                           = Color.White;
            dgvBodegas.EnableHeadersVisualStyles                 = false;
            dgvBodegas.ColumnHeadersBorderStyle                  = DataGridViewHeaderBorderStyle.None;
            dgvBodegas.ColumnHeadersDefaultCellStyle.BackColor   = Color.FromArgb(11, 31, 58);
            dgvBodegas.ColumnHeadersDefaultCellStyle.ForeColor   = Color.White;
            dgvBodegas.ColumnHeadersDefaultCellStyle.Font        = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvBodegas.ColumnHeadersHeight                       = 45;
            dgvBodegas.DefaultCellStyle.Font                     = new Font("Segoe UI", 10F);
            dgvBodegas.DefaultCellStyle.SelectionBackColor       = Color.FromArgb(52, 152, 219);
            dgvBodegas.DefaultCellStyle.SelectionForeColor       = Color.White;
            dgvBodegas.RowsDefaultCellStyle.BackColor            = Color.White;
            dgvBodegas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvBodegas.RowTemplate.Height                        = 38;
            dgvBodegas.AutoSizeColumnsMode                       = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBodegas.SelectionMode                             = DataGridViewSelectionMode.FullRowSelect;
            dgvBodegas.MultiSelect                               = false;
            dgvBodegas.RowHeadersVisible                         = false;
            dgvBodegas.GridColor                                 = Color.LightGray;
        }

        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────

        private void FrmBodegas_Load(object sender, EventArgs e)
        {
            MostrarBodegas();
        }

        // CARGA TODAS LAS BODEGAS EN LA GRILLA
        private void MostrarBodegas()
        {
            try
            {
                dgvBodegas.DataSource = lBodegas.MostrarBodegas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // SELECCION EN LA GRILLA
        // ─────────────────────────────────────────

        private void dgvBodegas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    idBodega = Convert.ToInt32(
                        dgvBodegas.Rows[e.RowIndex].Cells["IdBodega"].Value);
                }
            }
            catch { }
        }

        // ─────────────────────────────────────────
        // BOTON NUEVO — abre modal en modo creación
        // ─────────────────────────────────────────

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmBodegaModal modal = new FrmBodegaModal())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    MostrarBodegas();
                    idBodega = 0;
                }
            }
        }

        // ─────────────────────────────────────────
        // BOTON EDITAR — abre modal en modo edición
        // ─────────────────────────────────────────

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idBodega == 0 || dgvBodegas.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione una bodega de la lista antes de editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow fila = dgvBodegas.SelectedRows[0];

                using (FrmBodegaModal modal = new FrmBodegaModal(
                    idBodega,
                    fila.Cells["Nombre"].Value?.ToString()    ?? "",
                    fila.Cells["Direccion"].Value?.ToString() ?? ""))
                {
                    if (modal.ShowDialog(this) == DialogResult.OK)
                        MostrarBodegas();
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
            if (idBodega == 0 || dgvBodegas.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione una bodega de la lista antes de eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombre = "";
                try { nombre = dgvBodegas.SelectedRows[0].Cells["Nombre"].Value?.ToString() ?? ""; }
                catch { }

                DialogResult resultado = MessageBox.Show(
                    "¿Desea eliminar la bodega: " + nombre + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    lBodegas.EliminarBodega(idBodega);

                    MessageBox.Show(
                        "Bodega eliminada correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    MostrarBodegas();
                    idBodega = 0;
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
                dgvBodegas.DataSource = lBodegas.BuscarBodega(txtBuscar.Text);
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
            ExportarExcel.Exportar(dgvBodegas, "Reporte_Bodegas");
        }
    }
}
